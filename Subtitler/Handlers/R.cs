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
        public const string STORE_RATE = "ms-windows-store:REVIEW?PFN=3783mindprojects.Subtitler_6c8ydbw054cyy";
        public static string[] LANGUAGES = new string[] {
            "English", "Farsi/Persian", "Arabic", "Brazillian Portuguese",
            "Danish", "Dutch", "Finnish", "French", "Hebrew",
            "Indonesian", "Italian", "Norwegian", "Romanian",
            "Spanish", "Swedish", "Vietnamese", "Hindi", "Russian" };
        //url = "https://www.payping.ir/yazdipour";
        //await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
    }
}
