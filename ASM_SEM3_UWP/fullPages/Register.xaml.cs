using ASM_SEM3_UWP.model;
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
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;
using System.Net;
using Windows.Storage;

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
        private int gender_ = 2;
        private StorageFile photo;
        string imageUrl = null;
        public Register()
        {
            this.InitializeComponent();
            this.registerservice = new registerServiceImpl();
        }

        private void btn_Login(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.Login), "login");
            //NavView_Navigate("MUSIC TOWN", args.RecommendedNavigationTransitionInfo);


        }

        private void btn_Register(object sender, RoutedEventArgs e)
        {
            validateFrom();

        }
        private void Gender_Choose(object sender, RoutedEventArgs e)
        {
            var chooseRadioButton = (RadioButton)sender;
            if (chooseRadioButton == null)
            {
                return;
            }
            switch (chooseRadioButton.Tag)
            {
                case "Male":
                    gender_ = 1;
                    break;
                case "Female":
                    gender_ = 0;
                    break;
                case "Other":
                    gender_ = 2;
                    break;
            }
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
            String firstName_ = input_firstName.Text;
            String lastName_ = input_lastName.Text;
            String pass1_ = input_pass1.Password.ToString();
            String pass2_ = input_pass2.Password.ToString(); 
            String address_ = input_address.Text;
            String phone_ = input_phone.Text;
            

            Boolean check = true;
            String email_ = input_email.Text;
            if(firstName_ is null || firstName_.Length < 1)
            {
                vld_firstName.Text = "input name";
                check = false;
            }
            if (lastName_ is null || lastName_.Length < 1)
            {
                vld_lastName.Text = "input last name";
                check = false;

            }
            if (pass1_ is null || pass1_.Length < 1)
            {
                vld_pass1.Text = "input pass";
                check = false;

            }
            if (pass2_ is null || pass2_.Length < 1)
            {
                vld_pass2.Text = "input pass";
                check = false;

            }
            if (!pass1_.Equals(pass2_))
            {
                vld_pass2.Text = "unmatch";
                check = false;

            }
            if (address_ is null || address_.Length < 1)
            {
                vld_address.Text = "input address";
                check = false;

            }
            if (email_ is null || email_.Length < 11)
            {
                vld_email.Text = "input email";
                check = false;

            }
            bool match;

            if ((match = Regex.IsMatch(email_, "@gmail.com")) == false)
            {
                vld_email.Text = "input again email";
                check = false;

            }

            if ((DateTime.Now - _birthDay).TotalDays < 3650)
            {
                vld_dateOfBirth.Text = "input date of birth";
                check = false;

            }
            int i = 0;
            if (phone_.Length<9)
            {
                vld_phone.Text = "input phone again";
                check = false;
            }
            if (imageUrl == null)
            {
                vld_avataLink.Text = "please chose images";
            }
            if (check == true)
            {
                RegisterUser(firstName_, lastName_, pass1_, address_, phone_, imageUrl, gender_, email_, _birthDay);
            }
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
        private void RegisterUser(String firstName_, String lastName_, String password_, String address_, String phone_,
            String avatar_, int gender_, String email_, DateTime birthday_)
        {
            user member = new user()
            {
                firstName = firstName_,
                lastName = lastName_,
                password = password_,
                address = address_,
                phone = phone_,
                avatar = avatar_,
                gender = gender_,
                email = email_,
                birthday = birthday_
            };
            var memberJson = JsonConvert.SerializeObject(member);
            HttpContent contendSend = new StringContent(memberJson, Encoding.UTF8, "application/json");
            submitData(contendSend);
        }
        private async void submitData(HttpContent contendSend)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(
                "https://2-dot-backup-server-002.appspot.com/_api/v2/members",contendSend);
            var dataRespon = await response.Content.ReadAsStringAsync();
            var memberRespon = JsonConvert.DeserializeObject<user>(dataRespon);
            //id_data.Text = memberRespon.id;
            Debug.WriteLine(memberRespon.id);
            if (memberRespon.id != null) {
                input_firstName.Text = "";
                input_lastName.Text="";
                input_pass1.Password = "";
                input_pass2.Password="";
                input_address.Text="";
                input_phone.Text="";
                result.Text = "SUCESS";
            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // get upload url
            HttpClient client = new HttpClient();
            var uploadUrl = client.GetAsync("https://2-dot-backup-server-001.appspot.com/get-upload-token").Result.Content.ReadAsStringAsync().Result;

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            this.photo = await picker.PickSingleFileAsync();
            if (photo != null)
            {

                Debug.WriteLine("photo===" + photo);
            }

            HttpUploadFile(uploadUrl, "myFile", "image/png");

        }

        public async void HttpUploadFile(string url, string paramName, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.
            Stream fileStream = await this.photo.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                //url:
                imageUrl = reader2.ReadToEnd();
                //
                Debug.WriteLine("imageUrl" + imageUrl);
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }
    }
}
