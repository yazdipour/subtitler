namespace Subtitler.Models
{
    class Settings
    {
        public bool IsDarkTheme { get; set; } = true;
        public bool ZipIt { get; set; } = false;
        public int Language { get; set; } = 0;
        public string LanguageString => Handlers.R.LANGUAGES[Language];
    }
}
