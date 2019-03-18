using Subtitler.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;

namespace Subtitler
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            Loaded += async (s, e) =>
            {
                await Handlers.SettingsHandler.InitAsync();
                iframe.Navigate(typeof(HomePage));
            };
        }

        public static bool IsLoading { get; internal set; }

        private async void Nav_Click(object sender, RoutedEventArgs e)
        {
            if (sender is AppBarButton btn)
            {
                switch (btn.Tag.ToString())
                {
                    case "Home":
                        if (iframe.SourcePageType != typeof(HomePage))
                            iframe.Navigate(typeof(HomePage));
                        break;
                    case "Find":
                        if (iframe.SourcePageType != typeof(SearchPage))
                            iframe.Navigate(typeof(SearchPage));
                        break;
                    case "Setting":
                        await new SettingsDialog().ShowAsync();
                        break;
                }
            }
        }
    }
}
