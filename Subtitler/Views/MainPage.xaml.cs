using Subtitler.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Microsoft.Toolkit.Uwp.UI.Controls;

namespace Subtitler
{
    public sealed partial class MainPage : Page
    {
        private static Loading loadingControl;

        public MainPage()
        {
            InitializeComponent();
            Loaded += async (s, e) =>
            {
                await Handlers.SettingsHandler.InitAsync();
                iframe.Navigate(typeof(HomePage));
            };
            loadingControl = LoadingControl;
        }

        public static bool IsLoading
        {
            set => loadingControl.IsLoading = value;
            get => loadingControl.IsLoading;
        }

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
