using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Subtitler.Handlers;

namespace Subtitler.Views
{
    public sealed partial class LangDialog : ContentDialog
    {
        public LangDialog()
        {
            this.InitializeComponent();
            Tag = false;
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            LangList.ItemsSource = R.LANGUAGES;
            LangList.SelectedIndex = SettingsHandler.Settings.Language;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            SettingsHandler.Settings.Language = LangList.SelectedIndex;
            Tag = true;
        }
    }
}
