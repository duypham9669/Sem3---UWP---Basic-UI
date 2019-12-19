using ASM_SEM3_UWP.service;
using ASM_SEM3_UWP.service.serviceIpml;
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
    public sealed partial class Register : Page
    {
        private registerService registerservice;
        private DateTime _birthDay;

        public Register()
        {
            this.InitializeComponent();
            this.registerservice = new registerServiceImpl();
        }

        private void btn_Login(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.Login));

        }

        private void btn_Register(object sender, RoutedEventArgs e)
        {
            registerservice.register();
        }
        private void Birthday_OnDateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (sender.Date.HasValue)
            {
                _birthDay = sender.Date.Value.Date;
            }
        }
        private void validateFrom()
        {
            String firstName = vld_firstName.Text;
            String lastName = vld_lastName.Text;
            String pass1 = vld_pass1.Text;
            String pass2 = vld_pass2.Text;
            String address = vld_address.Text;
            String phone = vld_phone.Text;
            String avataLink = vld_avatalink.Text;
/*            String gender = vld_
*/            String email = vld_address.Text;
            if(firstName is null || firstName.Length < 1)
            {
                vld_firstName.Text = "input name";
            }
            if (lastName is null || lastName.Length < 1)
            {
                vld_lastName.Text = "input last name";
            }
            if (pass1 is null || pass1.Length < 1)
            {
                vld_pass1.Text = "input pass";
            }
            if (pass2 is null || pass2.Length < 1)
            {
                vld_pass2.Text = "input pass";
            }
            if (!pass1.Equals(pass2))
            {
                vld_pass2.Text = "unmatch";
            }
            if (address is null || address.Length < 1)
            {
                vld_address.Text = "input address";
            }
            if (email is null || email.Length < 1)
            {
                vld_email.Text = "input email";
            }


        }

    }
}
