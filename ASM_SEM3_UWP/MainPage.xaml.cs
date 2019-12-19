using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ASM_SEM3_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btn_register(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.Register));

        }

        private void btn_login(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.Login));

        }

        private void btn_uploadSong(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.UploadSong));

        }

        private void btn_allSong(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.ListSong));

        }
    }
}
