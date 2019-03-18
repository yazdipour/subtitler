using System;
using Subtitler.Models;
using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class SettingsDialog : ContentDialog
    {
        private Settings settings = Handlers.SettingsHandler.Settings;
        public SettingsDialog() => InitializeComponent();

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Hide();
            await new LangDialog().ShowAsync();
        }

        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
            => await Handlers.SettingsHandler.CacheSettingsAsync();
    }
}
