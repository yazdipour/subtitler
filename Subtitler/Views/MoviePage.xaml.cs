using Newtonsoft.Json;
using Subtitler.Handlers;
using Subtitler.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Subtitler.Views
{
    public sealed partial class MoviePage : Page
    {
        private Movie Movie { get; set; }
        private ObservableCollection<Subtitle> SubtitleList = new ObservableCollection<Subtitle>();

        public MoviePage() => InitializeComponent();

        private void ReloadPage()
        {
            try { Frame.Navigate(typeof(MoviePage), Movie); }
            finally { Frame.BackStack.Remove(Frame.BackStack.Last()); }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Movie movie) await LoadItemsAsync(Movie = movie);
        }

        private async Task LoadItemsAsync(Movie movie)
        {
            try
            {
                var json = await ApiHandler.Api.GetMovieItems<MovieWithSubtitles>(movie.Url);
                if (!string.IsNullOrWhiteSpace(json.Movie.ImgSrc)) Movie.ImgSrc = json.Movie.ImgSrc;
                if (!string.IsNullOrWhiteSpace(json.Movie.Year)) Movie.Year = json.Movie.Year;
                foreach (var item in json.Subtitles) SubtitleList.Add(item);
            }
            catch { }
        }

        private void SearchBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
            => SubtitlesListView.ItemsSource = SubtitleList.Where(e => e.Name.Contains(sender?.QueryText?.Trim(), StringComparison.OrdinalIgnoreCase));

        private async void Body_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Subtitle subtitle)
                await new SubtitleDialog(subtitle).ShowAsync();
        }

        private async void ChangeLanguage_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var pg = new LangDialog();
            await pg.ShowAsync();
            if ((bool)pg.Tag) ReloadPage();
        }

        private void Refresh_OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e) => ReloadPage();

        private void BackButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) => Frame.GoBack();

        private void Fav_OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }

    class MovieWithSubtitles
    {
        [JsonProperty("movie")]
        public Movie Movie { get; set; }
        [JsonProperty("items")]
        public Subtitle[] Subtitles { get; set; }
    }
}
