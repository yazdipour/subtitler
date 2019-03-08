using Subtitler.Models;
using System.Threading.Tasks;

namespace Subtitler.Handlers
{
    class SettingsHandler
    {
        private static Settings settings;
        public static Settings Settings
        {
            get => settings ?? (settings = new Settings());
            set { settings = value; }
        }

        public static async Task InitSettingsAsync()
        {
            if (!await CacheHandler.Cache.Exist(R.SETTINGS_KEY)) return;
            settings = await CacheHandler.Cache.GetObject<Settings>(R.SETTINGS_KEY);
        }
    }
}
