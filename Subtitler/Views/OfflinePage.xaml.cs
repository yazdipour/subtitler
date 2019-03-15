using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Subtitler.Views
{
    public sealed partial class OfflinePage : Page
    {
        public OfflinePage() => InitializeComponent();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Message.Text = ((string)e.Parameter) ?? "Please Try Again";
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }
    }
}
