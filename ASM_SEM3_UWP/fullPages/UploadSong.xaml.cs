using ASM_SEM3_UWP.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
    public sealed partial class UploadSong : Page
    {
        public UploadSong()
        {
            this.InitializeComponent();
        }

        private void btn_ListSong(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(fullPages.ListSong));

        }
        private void btn_upload(object sender, RoutedEventArgs e)
        {
            validate();
        }

       private void validate()
        {
            Debug.WriteLine("validate");
            Boolean check = true;
            String name = songName.Text;
            String Author=songAuthor.Text;
            String Singer=songSinger.Text;
            String Thumbnail=songThumbnail.Text;
            String Link=songLink.Text;
            String Description=songDescription.Text;

            if (name is null || name.Length < 1)
            {
                vld_songName.Text = "input name";
                check = false;
            }
            if (Author is null || Author.Length < 1)
            {
                vld_songAuthor.Text = "input Author";
                check = false;
            }
            if (Description is null || Description.Length < 1)
            {
                vld_songDescription.Text = "input Description";
                check = false;
            }
            if (Singer is null || Singer.Length < 1)
            {
                vld_songSinger.Text = "input singer";
                check = false;
            }
            if (Thumbnail is null || Thumbnail.Length < 1)
            {
                vld_songThumbnail.Text = "input thumbnail";
                check = false;
            }
            if (Link is null || Link.Length < 1)
            {
                vld_songLink.Text = "input link";
                check = false;
            }
            if (check == true)
            {
                uploadMusic(name, Author, Singer, Thumbnail, Link, Description);
            }

        }
      
        private void uploadMusic(String name, String Author, String Singer, String Thumbnail, String Link,
           String Description)
        {
            song newsong = new song()
            {
                name = name,
                author = Author,
                singer = Singer,
                thumbnail = Thumbnail,
                link = Link,
                description = Description
            };
            var songJson = JsonConvert.SerializeObject(newsong);
            HttpContent contendSend = new StringContent(songJson, Encoding.UTF8, "application/json");
            submitData(contendSend, Login.token);
        }
        private async void submitData(HttpContent contendSend, String token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var response = await httpClient.PostAsync(
                "https://2-dot-backup-server-002.appspot.com/_api/v2/songs", contendSend);
            var dataRespon = await response.Content.ReadAsStringAsync();
            var songRespon = JsonConvert.DeserializeObject<song>(dataRespon);
            //id_data.Text = memberRespon.id;
            Debug.WriteLine(songRespon.id);
            if (songRespon.id != null)
            {
               songName.Text="";
                songAuthor.Text="";
                songSinger.Text="";
                songThumbnail.Text="";
                songLink.Text="";
                songDescription.Text="";
                vld_songLink.Text = "SUCESS";
            }
        }
    }
}
