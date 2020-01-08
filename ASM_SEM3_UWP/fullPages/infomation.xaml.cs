using ASM_SEM3_UWP.model;
using ASM_SEM3_UWP.service;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM_SEM3_UWP.fullPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class infomation : Page
    {
        infomationService infomationservice = new infomationService();
        private song currentSong;
        public infomation()
        {

            this.InitializeComponent();
            run();
        }
        private async void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            Songs.ItemsSource = await infomationservice.GetListSong(Login.token);


        }
        private async System.Threading.Tasks.Task run()
        {
            user member = await this.infomationservice.GetMemberInformation(Login.token);
            memberName.Text = member.firstName +" "+ member.lastName;
            memberAddress.Text = member.address;
            memberPhone.Text = member.phone;
            memberEmail.Text = member.email;
        }
        private void Songs_OnItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
    }
}
