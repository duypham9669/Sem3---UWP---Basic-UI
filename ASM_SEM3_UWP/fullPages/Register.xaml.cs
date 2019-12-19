using ASM_SEM3_UWP.service;
using ASM_SEM3_UWP.service.serviceIpml;
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
    public sealed partial class Register : Page
    {
        private registerService registerservice;
        private DateTime _birthDay=DateTime.Now;

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
            validateFrom();
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
            String firstName_ = firstName.Text;
            String lastName_ = lastName.Text;
            String pass1_ = pass1.Password.ToString();
            String pass2_ = pass2.Password.ToString(); 
            String address_ = address.Text;
            String phone_ = phone.Text;
            String avataLink_ = avataLink.Text;
            
            String email_ = email.Text;
            if(firstName_ is null || firstName_.Length < 1)
            {
                vld_firstName.Text = "input name";
            }
            if (lastName_ is null || lastName_.Length < 1)
            {
                vld_lastName.Text = "input last name";
            }
            if (pass1_ is null || pass1_.Length < 1)
            {
                vld_pass1.Text = "input pass";
            }
            if (pass2_ is null || pass2_.Length < 1)
            {
                vld_pass2.Text = "input pass";
            }
            if (!pass1_.Equals(pass2_))
            {
                vld_pass2.Text = "unmatch";
            }
            if (address_ is null || address_.Length < 1)
            {
                vld_address.Text = "input address";
            }
            if (email_ is null || email_.Length < 11)
            {
                vld_email.Text = "input email";
            }
            bool match;

            if ((match = Regex.IsMatch(email_, "@gmail.com")) == false)
            {
                vld_email.Text = "input again email";
            }

            if ((DateTime.Now - _birthDay).TotalDays < 3650)
            {
                vld_dateOfBirth.Text = "input date of birth";
            }
            int i = 0;
            if (!Int32.TryParse(phone_, out i)||phone_.Length<9)
            {
                vld_phone.Text = "input phone again";
            }

        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
    }
}
