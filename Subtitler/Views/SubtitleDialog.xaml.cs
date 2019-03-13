using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class SubtitleDialog : ContentDialog
    {
        public SubtitleDialog()
        {
            this.InitializeComponent();
        }
        
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void Close_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Hide();
        }

        private void Dl_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //if (BDl.Content?.ToString() != "Cancel")
            //{
            //    BClose.IsEnabled = false;
            //    BDl.Content = "Cancel";
            //    BDl.Background = new SolidColorBrush(Colors.Red);
            //    PBar.IsIndeterminate = true;
            //    PBar.Visibility = Visibility.Visible;
            //    try
            //    {
            //        //START 
            //        ToastIt(await HandleOnlineServices.DownloadSubtitle(_dlLink, _item.Name,
            //            new CancellationToken(false)) ? "✔Completed" : "✖Failed!", _item.Name);
            //    }
            //    catch { }
            //    CancelEffect();
            //}
            //else
            //{
            //    CancelEffect();
            //}
        }

        private void ContentDialog_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //BDl.IsEnabled = false;
            //try
            //{
            //    var byteArray = await BlobCache.InMemory.DownloadUrl(App.BASE_URL + "/dl_page.php?url=" + _item.Url);
            //    string str = System.Text.Encoding.UTF8.GetString(byteArray);
            //    var res = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(str);
            //    Releaseinfo.Text = res[0].Replace("\t", "").Trim();
            //    var pos = res[1].LastIndexOf(@"?mac=", StringComparison.Ordinal);
            //    _dlLink = App.BASE_URL + "/downloadlink.php" + res[1].Substring(pos);
            //    BDl.IsEnabled = true;
            //}
            //catch (TimeoutException)
            //{
            //    Releaseinfo.Text = "Error! TimeOut!";
            //    Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Exception in DlPage 1");
            //}
            //catch (Exception)
            //{
            //    Releaseinfo.Text = "Error just happened!";
            //    Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Exception in DlPage 2");
            //}
            //PBar.Visibility = Visibility.Collapsed;
            //_cts = null;
        }

        private void DownloadPage_OnSizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            //sc.Height = e.NewSize.Height - 180;
        }

        private void ContentDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {

        }
    }
}
