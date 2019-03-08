using Windows.ApplicationModel;

namespace Subtitler.Handlers
{
    class R
    {
        public const string SETTINGS_KEY = "SETTINGS";
        public const string BASE_URL = "https://subtlr.herokuapp.com";
        public const string EMAIL_URI = "mailto:shahriar.yazdipour@outlook.com?subject=Subtitler_";
        public static string VERSION = $"{Package.Current.Id.Version.Major}.{Package.Current.Id.Version.Minor}.{Package.Current.Id.Version.Build}";
        public static string DOWNLOAD_LINK(string mac) => BASE_URL + "/download.php" + mac;
    }
}
