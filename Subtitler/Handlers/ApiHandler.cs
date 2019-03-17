using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Subtitler.Handlers
{
    class ApiHandler
    {
        private static IApi api;

        public static IApi Api => api ?? (api = Refit.RestService.For<IApi>(new HttpClient
        {
            BaseAddress = new Uri(R.BASE_URL),
            Timeout = TimeSpan.FromMinutes(1)
        }));

        private static async Task<bool> Download(string url, string fileName,
            StorageFolder destinationFolder, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(url) || !Uri.TryCreate(url, UriKind.Absolute, out Uri source))
                throw new Exception("Invalid URI");
            try
            {
                StorageFile destinationFile = await (destinationFolder ?? KnownFolders.VideosLibrary)
                    .CreateFileAsync(fileName, CreationCollisionOption.GenerateUniqueName);
                var downloader = new BackgroundDownloader().CreateDownload(source, destinationFile);
                downloader.Priority = BackgroundTransferPriority.Default;
                await downloader.StartAsync().AsTask(token);
                return true;
            }
            catch (TaskCanceledException e) { throw e; }
            catch { return false; }
        }

        public static async Task<bool> DownloadSubtitle(string url, string name,
            bool unzipIt, CancellationToken token)
        {
            StorageFolder folder = await new FolderPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.Downloads,
                FileTypeFilter = { "*" }
            }.PickSingleFolderAsync();
            if (folder == null) return false;
            try
            {
                name = Path.GetFileNameWithoutExtension(name) + ".zip";
                var result = await Download(url, name, folder, token);
                if (result && unzipIt) Utils.Unzip(name, folder);
                return result;
            }
            catch { }
            return false;
        }
    }
}
