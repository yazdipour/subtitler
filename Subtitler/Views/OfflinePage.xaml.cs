using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class OfflinePage : Page
    {
        private string ErrText = "No Connection";
        public OfflinePage()
        {
            this.InitializeComponent();
        }


        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //    ErrText = ((string)e.Parameter);
        //    changeStatusBarColor();
        //}

        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    base.OnNavigatedFrom(e);
        //    changeStatusBarColor(false);
        //}
        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    
    }
}
