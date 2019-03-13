using Subtitler.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;

namespace Subtitler
{
    public sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        private async void Nav_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
                switch (btn.Content)
                {
                    case "Home":
                        if (iframe.SourcePageType != typeof(HomePage)) iframe.Navigate(typeof(HomePage));
                        break;
                    case "Search":
                        if (iframe.SourcePageType != typeof(SearchPage)) iframe.Navigate(typeof(SearchPage));
                        break;
                    case "Settings":
                        await new SettingsDialog().ShowAsync();
                        break;
                }
        }
    }
}
