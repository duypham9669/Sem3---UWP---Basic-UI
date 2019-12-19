using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void btn_register(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.Register));

        }

        private void btn_Submit(object sender, RoutedEventArgs e)
        {

        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
        private void validate()
        {
            String email2 = email.Text;
            String pass2 = pass.Password.ToString();
            if (email2 is null || email2.Length < 11)
            {
                vld_email.Text = "input email";
            }
            bool match;

            if ((match = Regex.IsMatch(email2, "@gmail.com")) == false)
            {
                vld_email.Text = "input again email";
            }
            if (pass2 is null || pass2.Length < 1)
            {
                vld_pass.Text = "input pass";
            }

        }
    }
}
