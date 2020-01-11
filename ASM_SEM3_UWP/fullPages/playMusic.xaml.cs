using ASM_SEM3_UWP.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM_SEM3_UWP.fullPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class playMusic : Page
    {
        public static playMusic playLayout;
        private static song currentSong=null;
        public static bool _isPlaying = false;
        private static List<song> listsongs = null;

        public playMusic()
        {
            playLayout = this;
            this.InitializeComponent();
            run();
        }
        private void run()
        {
            if (currentSong!= null)
            {
            StatusText.Text = "Now Playing: " + currentSong.name;
            }
        }
        public void listend(List<song> listSongInput, long idSong)
        {
            listsongs = listSongInput;
            for(int i=0; i< listsongs.Count; i++)
            {
                Debug.WriteLine("song" + i + "=" +listsongs[i].link);
            }
            Debug.WriteLine("is go to listend in site playMusic");
            
            for(int i=0; i<listsongs.Count; i++)
            {
                if (idSong==(listsongs[i].id))
                {
                    currentSong = listsongs[i];
                }
            }
            Debug.WriteLine("currentSong.link=" + currentSong.link);
            MyPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
                        playcliked();

        }
        private void playcliked()
        {

            if (listsongs == null)
            {
                result.Text = "List empty";
            }
            else
            {
                if (currentSong == null)
                {
                    currentSong = listsongs[0];
                    MyPlayer.Source = MediaSource.CreateFromUri(new Uri(listsongs[0].link));
                }
                if (_isPlaying)
                {
                    MyPlayer.MediaPlayer.Pause();
                    PlayButton.Icon = new SymbolIcon(Symbol.Play);
                    StatusText.Text = "Paused";
                    _isPlaying = false;
                }
                else
                {
                    MyPlayer.MediaPlayer.Play();
                    PlayButton.Icon = new SymbolIcon(Symbol.Pause);
                    StatusText.Text = "Now Playing: " + currentSong.name;
                    _isPlaying = true;
                }
            }
            
        }
        private void PlayButton_Clicked(object sender, RoutedEventArgs e)
        {
            playcliked();
        }
        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            int currentIndex=0;
            for(int i=0; i<listsongs.Count; i++)
            {
                if (currentSong.id.Equals(listsongs[i].id))
                {
                    currentIndex = i;
                    break;
                }
            }
            currentIndex++;
            if (currentIndex >= listsongs.Count)
            {
                currentIndex = 0;
            }
            setDataSite(listsongs[currentIndex]);
            playMusic2(currentIndex);
            Debug.WriteLine("link=" + currentSong.link);
        }

        private void Previous_OnClick(object sender, RoutedEventArgs e)
        {
            var currentIndex=0;
            for (int i = 0; i < listsongs.Count; i++)
            {
                if (currentSong.id.Equals(listsongs[i].id))
                {
                    currentIndex = i;
                    break;
                }
            }
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = listsongs.Count-1;
            }
            setDataSite(listsongs[currentIndex]);
            playMusic2(currentIndex);
            Debug.WriteLine("link=" + currentSong.link);
        }
       
        private void playMusic2(int index)
        {
            currentSong = listsongs[index];
            MyPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
            MyPlayer.MediaPlayer.Play();
            PlayButton.Icon = new SymbolIcon(Symbol.Pause);
            _isPlaying = true;
            StatusText.Text = "Now Playing: " + currentSong.name;

        }
        private void setDataSite(song currentSong)
        {
            songName.Text = currentSong.name;
            if (currentSong.description != null)
            {
                songDescription.Text = currentSong.description;

            }
            ImageControl.Source = new BitmapImage(new Uri(currentSong.thumbnail, UriKind.Absolute));
            imageHome.ImageSource = new BitmapImage(new Uri(currentSong.thumbnail, UriKind.Absolute));

        }
    }
}

