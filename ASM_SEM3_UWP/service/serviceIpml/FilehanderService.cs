using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ASM_SEM3_UWP.service.serviceIpml
{
    public class FilehanderService
    {
        public static async Task<String> Readfile(String filename)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var sampleFile = await storageFolder.GetFileAsync(filename);
            return await FileIO.ReadTextAsync(sampleFile);
            
        }

        public static async Task WriteFile(String fileName, String content)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var sampleFile = await storageFolder.CreateFileAsync(fileName,
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, content);
        }
       
        public static async Task deleteFile(String fileName)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var sampleFile = await storageFolder.GetFileAsync(fileName);
                await sampleFile.DeleteAsync(StorageDeleteOption.PermanentDelete);
             
        }
       
    }
}
