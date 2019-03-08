using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace Subtitler.Handlers
{
    class Utils
    {
        public static async void Unzip(string file, StorageFolder folder)
        {
            if (folder == null)
                folder = KnownFolders.VideosLibrary;
            try
            {
                using (var zipStream = await folder.OpenStreamForReadAsync(file))
                {
                    using (var zipMemoryStream = new MemoryStream((int)zipStream.Length))
                    {
                        await zipStream.CopyToAsync(zipMemoryStream);
                        using (var archive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Read))
                        {
                            //var newfolder = await folder.CreateFolderAsync(file.Replace(".zip", ""), CreationCollisionOption.OpenIfExists);
                            foreach (var entry in archive.Entries)
                            {
                                if (entry.Name == "")
                                {
                                    //Nested Folder
                                    await CreateRecursiveFolder(folder, entry);
                                }
                                else
                                {
                                    // Files
                                    await ExtractFile(folder, entry);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                var dialog = new MessageDialog("Error.\nSuccessfully download subtitle in zip file.\nbut something happened with unzipping process!");
                dialog.Commands.Add(new UICommand("Cancel"));
                await dialog.ShowAsync();
            }
            //Remove the Zip
            try
            {
                var fl = await folder.GetFileAsync(file);
                await fl.DeleteAsync();
            }
            catch { }
        }

        private static async Task CreateRecursiveFolder(StorageFolder folder, ZipArchiveEntry entry)
        {
            var steps = entry.FullName.Split('/').ToList();
            steps.RemoveAt(steps.Count() - 1);
            foreach (var i in steps)
            {
                await folder.CreateFolderAsync(i, CreationCollisionOption.OpenIfExists);
                folder = await folder.GetFolderAsync(i);
            }
        }

        private static async Task ExtractFile(StorageFolder folder, ZipArchiveEntry entry)
        {
            var steps = entry.FullName.Split('/').ToList();
            steps.RemoveAt(steps.Count() - 1);
            steps.ForEach(async subDir => folder = await folder.GetFolderAsync(subDir));
            using (var fileData = entry.Open())
            {
                var outputFile = await folder.CreateFileAsync(entry.Name, CreationCollisionOption.ReplaceExisting);
                using (var outputFileStream = await outputFile.OpenStreamForWriteAsync())
                {
                    await fileData.CopyToAsync(outputFileStream);
                    await outputFileStream.FlushAsync();
                }
            }
        }
    }
}
