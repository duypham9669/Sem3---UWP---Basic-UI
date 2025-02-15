﻿using ASM_SEM3_UWP.fullPages;
using ASM_SEM3_UWP.model;
using ASM_SEM3_UWP.service.serviceIpml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM_SEM3_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class navigation : Page
    {

        public static navigation currentLayout;
        public navigation()
        {
            this.InitializeComponent();
            currentLayout = this;
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

        }
      

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
{
    ("home", typeof(MainPage)),
    ("upload", typeof(fullPages.UploadSong)),
    ("user", typeof(fullPages.infomation)),
    ("nowPlaying", typeof(fullPages.playMusic)),
    ("Newmusic", typeof(fullPages.listSongAll)),
    ("music", typeof(fullPages.ListSong)),
    ("Register", typeof(fullPages.Register)),
    ("Login", typeof(fullPages.Login)),
    ("LogOut", typeof(MainPage))
    };


        
        public async void checkToken()
        {
            var tokenFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync("token.txt");
            if (tokenFile != null)
            {
                LogOut.Visibility = Visibility.Visible;
                information.Visibility = Visibility.Visible;
                Login2.Visibility = Visibility.Collapsed;
                Login.token = await FilehanderService.Readfile("token.txt");
            }
            else
            {
                Login2.Visibility = Visibility.Visible;
                information.Visibility = Visibility.Collapsed;
                LogOut.Visibility = Visibility.Collapsed;
            }
        }
        private async void NavView_Loaded(object sender, RoutedEventArgs e)
        {

            //NavView.MenuItems.Add(new NavigationViewItemSeparator());

            //_pages.Add(("Register", typeof(fullPages.Register)));

            ContentFrame.Navigated += On_Navigated;

            // NavView doesn't load any page by default, so load home page.
            NavView.SelectedItem = NavView.MenuItems[0];
            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.
            NavView_Navigate("home", new EntranceNavigationTransitionInfo());

            // Add keyboard accelerators for backwards navigation.
            var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
            goBack.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(goBack);

            // ALT routes here
            var altLeft = new KeyboardAccelerator
            {
                Key = VirtualKey.Left,
                Modifiers = VirtualKeyModifiers.Menu
            };
            altLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(altLeft);
            checkToken();
        }

        private async void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {


            var navItemTag2 = args.InvokedItemContainer.Tag.ToString();
            if (navItemTag2.Equals("LogOut"))
            {
                
                infomation info = new infomation();
                info.stopmusic();
                LogOut2();
            }

            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("MUSIC TOWN", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                try
                {
                    var navItemTag = args.InvokedItemContainer.Tag.ToString();
                    NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private async void LogOut2()
        {

                var tokenDelete = await ApplicationData.Current.LocalFolder.TryGetItemAsync("token.txt");
                if (tokenDelete != null)
                {
                    await FilehanderService.deleteFile("token.txt");
                }
                var emailDelete = await ApplicationData.Current.LocalFolder.TryGetItemAsync("email");
                if (emailDelete != null)
                {
                await FilehanderService.deleteFile("email");
                }
                var passDelete = await ApplicationData.Current.LocalFolder.TryGetItemAsync("email");
                if (passDelete != null)
                {
                    await FilehanderService.deleteFile("pass");
                }
            checkToken();


        }
        // NavView_SelectionChanged is not used in this example, but is shown for completeness.
        // You will typically handle either ItemInvoked or SelectionChanged to perform navigation,
        // but not both.
        private void NavView_SelectionChanged(NavigationView sender,
                                              NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                NavView_Navigate("MUSIC TOWN", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.SelectedItemContainer != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {

            Type _page = null;
            if (navItemTag == "MUSIC TOWN")
            {
                _page = typeof(MainPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private void NavView_BackRequested(NavigationView sender,
                                           NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }

        private void BackInvoked(KeyboardAccelerator sender,
                                 KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private bool On_BackRequested()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavView.IsPaneOpen &&
                (NavView.DisplayMode == NavigationViewDisplayMode.Compact ||
                 NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            ContentFrame.GoBack();
            return true;
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType == typeof(MainPage))
            {
                // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
                NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
                NavView.Header = "MUSIC TOWN";
            }
            else if (ContentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);
                NavView.SelectedItem = NavView.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));
                NavView.Header =
                    ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }
        }

    }
}