namespace Subtitler.Models
{
    class Settings
    {
        //public Windows.UI.Xaml.ElementTheme Theme { get; set; } = Windows.UI.Xaml.ElementTheme.Dark;
        public bool ZipIt { get; set; } = false;
        public int Language { get; set; } = 0;
        public string LanguageString => Handlers.R.LANGUAGES[Language];
    }
}
