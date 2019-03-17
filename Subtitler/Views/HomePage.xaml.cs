using Subtitler.Handlers;
using Subtitler.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class HomePage : Page
    {
        private ObservableCollection<Movie> HomeList = new ObservableCollection<Movie>();
        public HomePage() => InitializeComponent();
        private void Grid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
            => Frame.Navigate(typeof(MoviePage), HomeList[lightStone.SelectedIndex]);

        private async void HomePage_LoadedAsync(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                if (HomeList.Count != 0) return;
                if (!Microsoft.Toolkit.Uwp.Connectivity.NetworkHelper.Instance.ConnectionInformation.IsInternetAvailable)
                    throw new System.Exception("The Internet is not Available");
                MainPage.IsLoading = true;
                foreach (var m in await ApiHandler.Api.GetHome()) HomeList.Add(m);
            }
            catch (System.Exception ex)
            {
                Frame.Navigate(typeof(OfflinePage), ex.Message);
            }
            finally
            {
                MainPage.IsLoading = false;
            }
        }
    }
}
