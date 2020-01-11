using ASM_SEM3_UWP.model;
using ASM_SEM3_UWP.service;
using ASM_SEM3_UWP.service.serviceIpml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        public static string token;

        private loginServiceImpl loginService = new loginServiceImpl();
        public Login()
        {
            this.InitializeComponent();
            readDataFile();
        }

        private void btn_register(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.Register));

        }
        private async void btn_Submit(object sender, RoutedEventArgs e)
        {
            progress1.IsActive = true;
            await validateAsync();
            
        }
        private void checkRemember(String email, String pass)
        {
            //CheckBox checkbox = new CheckBox(remember);
            if (remember.IsChecked == true)
            {
                writeDataUser(email, pass);
            }
        }
       
        private async System.Threading.Tasks.Task validateAsync()
        {
            String email2 = email.Text;
            String pass2 = pass.Password.ToString();
            Boolean check = true;
            if (email2 is null || email2.Length < 11)
            {
                vld_email.Text = "input email";
                check = false;
                progress1.IsActive = false;
            }
            bool match;
            if ((match = Regex.IsMatch(email2, "@gmail.com")) == false)
            {
                vld_email.Text = "input again email";
                check = false;
                progress1.IsActive = false;
            }
            if (pass2 is null || pass2.Length < 1)
            {
                vld_pass.Text = "input pass";
                check = false;
                progress1.IsActive = false;
            }
            if (check == true)
            {
                await loginAsync(email2, pass2);
                checkRemember(email2, pass2);
                checkStatus.status = true;
                progress1.IsActive = false;
            }
        }
        private async System.Threading.Tasks.Task loginAsync(String email, String pass)
        {
            
            token = await this.loginService.LoginTask(email, pass);
            if (token != null)
            {
            await FilehanderService.WriteFile("token.txt", token);
            navigation.currentLayout.checkToken();
            this.Frame.Navigate(typeof(MainPage));
                progress1.IsActive = false;

            }
            else
            {
                loginfail.Text = "Invalid information, Please login again!";
                progress1.IsActive = false;
            }

        }
        private async void writeDataUser(String email, String pass)
        {
            await FilehanderService.WriteFile("email", email);
            await FilehanderService.WriteFile("pass", pass);
        }

        private async void readDataFile()
        {
            bool x = await isFilePresent("email");
            Debug.WriteLine("X===" + x);
            if (x == true)
            {
                var resultEmail = await FilehanderService.Readfile("email");
                email.Text = resultEmail;
                var resultPass = await FilehanderService.Readfile("pass");
                pass.Password = resultPass;
            }
        }
        public async Task<bool> isFilePresent(string fileName)
        {
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName);
            return item != null;
        }

    }
    }

