using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Net.Http;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace Subtitler.Views
{
    public sealed partial class DevDialog : ContentDialog
    {
        public DevDialog()
        {
            InitializeComponent();
            Loaded += DevDialog_Loaded;
        }

        private async void DevDialog_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Uri uri = new Uri("https://raw.githubusercontent.com/yazdipour/subtitler/master/DEVNOTE.md");
            using (var client = new HttpClient())
            {
                try
                {
                    markdownControl.Text = await client.GetStringAsync(uri);
                }
                catch { }
            }

        }

        private async void MarkdownText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (Uri.TryCreate(e.Link, UriKind.Absolute, out Uri link))
                await Launcher.LaunchUriAsync(link);
        }
    }
}
