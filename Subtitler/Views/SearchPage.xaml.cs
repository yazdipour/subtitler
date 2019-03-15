using Subtitler.Handlers;
using Subtitler.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class SearchPage : Page
    {
        private ObservableCollection<Movies> SearchList = new ObservableCollection<Movies>();
        public SearchPage() => InitializeComponent();

        private void SearchResultList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Movies movies)
                Frame.Navigate(typeof(MoviePage), movies);
        }

        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                var text = sender.Text;
                if (string.IsNullOrWhiteSpace(text)) return;
                MainPage.IsLoading = true;
                sender.IsEnabled = false;
                foreach (var movies in await ApiHandler.Api.GetSearch(text)) SearchList.Add(movies);
            }
            catch
            {
                var dialog = new MessageDialog("Error. Try again later!");
                dialog.Commands.Add(new UICommand("Close"));
                await dialog.ShowAsync();
            }
            finally
            {
                sender.IsEnabled = true;
                MainPage.IsLoading = false;
            }
        }
    }
}
