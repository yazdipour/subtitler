﻿using Subtitler.Models;
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

        public static async Task InitAsync()
        {
            if (!await CacheHandler.Cache.Exist(R.SETTINGS_KEY)) return;
            settings = await CacheHandler.Cache.GetObject<Settings>(R.SETTINGS_KEY);
        }

        public static async Task CacheSettingsAsync()
            => await CacheHandler.Cache.InsertObject(R.SETTINGS_KEY, settings);
    }
}
