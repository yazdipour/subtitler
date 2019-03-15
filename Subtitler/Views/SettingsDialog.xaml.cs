using Subtitler.Models;
using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class SettingsDialog : ContentDialog
    {

        Settings settings = Handlers.SettingsHandler.Settings;
        public SettingsDialog()
        {
            this.InitializeComponent();
            //            var list = JsonConvert.DeserializeObject<List<string>>(LocalSettingManager.ReadSetting("SLang2"));

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Close
        }


        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
