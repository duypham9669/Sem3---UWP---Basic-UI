using ASM_SEM3_UWP.service.serviceIpml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
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
    public sealed partial class fileHander : Page
    {
        String filename;

        public fileHander()
        {
            this.InitializeComponent();
        }

        private async void btn_write_Click(object sender, RoutedEventArgs e)
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            //// Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            //// Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                filename = txt_filename.Text;
                String content = txt_content.Text;
                FilehanderService.WriteFile(filename + ".txt", content);
            }
            
        }

        private async void btn_show_Click(object sender, RoutedEventArgs e)
        {
            filename = txt_filename.Text;
            var result = await FilehanderService.Readfile(filename+".txt");
            txt_result.Text = result;
        }
    }
}
