using Subtitler.Handlers;
using Subtitler.Models;
using System;
using System.Threading;
using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class SubtitleDialog : ContentDialog
    {
        private Subtitle Subtitle { get; set; }
        private string downloadLink;

        public SubtitleDialog(object subtitle)
        {
            InitializeComponent();
            Subtitle = (Subtitle)subtitle;
        }

        private void Close_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) => Hide();

        private async void Dl_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (DownloadButton.Content?.ToString().Equals("Cancel") == true)
            {
                BClose.IsEnabled = true;
                DownloadButton.Content = "Download";
                return;
            }
            BClose.IsEnabled = false;
            DownloadButton.Content = "Cancel";
            try
            {
                if (!string.IsNullOrWhiteSpace(downloadLink))
                {
                    var downloadResult = await ApiHandler.DownloadSubtitle(downloadLink,
                        Subtitle.Name, !SettingsHandler.Settings.ZipIt, new CancellationToken(false));
                    Utils.CreateA2LineToast(Subtitle.Name, downloadResult ? "✔Download Completed" : "✖Failed!");
                }

            }
            finally { Dl_Click(sender, e); }
        }

        private async void ContentDialog_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                var linkAndTitle = await ApiHandler.Api.GetSubtitleLinks(Subtitle.Url);
                Releaseinfo.Text = linkAndTitle[0].Replace("  ", "").Trim();
                var macId = linkAndTitle[1].LastIndexOf(@"?mac=", StringComparison.Ordinal);
                downloadLink = R.DOWNLOAD_LINK(linkAndTitle[1].Substring(macId));
                DownloadButton.IsEnabled = true;
            }
            catch (TimeoutException)
            {
                Releaseinfo.Text = "Error! TimeOut!";
            }
            catch (Exception)
            {
                Releaseinfo.Text = "Error just happened!";
            }
        }
    }
}
