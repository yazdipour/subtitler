using Akavache;
using System;
using System.Reactive;
using Windows.ApplicationModel;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Subtitler.Handlers
{
    class CacheHandler : ICacheHandler
    {
        private static CacheHandler cache;

        public static CacheHandler Cache
        {
            get => cache ?? (cache = new CacheHandler());
            set { cache = value; }
        }

        private CacheHandler() => Registrations.Start(Package.Current.DisplayName);

        //var toaster = await GetObject<Toaster>("toaster");
        //GetObject<Toaster>("toaster").Subscribe(x => toaster = x, ex => Console.WriteLine("No Key!"));

        public async Task<T> GetObject<T>(string key)
            => await BlobCache.LocalMachine.GetObject<T>(key);

        public async Task<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null)
            => await BlobCache.LocalMachine.InsertObject(key, value, absoluteExpiration);

        public async Task<Unit> InvalidateAsync(string key)
            => await BlobCache.LocalMachine.Invalidate(key);

        public async Task<bool> Exist(string key)
        {
            try
            {
                var result = await GetObject<object>(key);
                return (result == null) ? false : true;
            }
            catch
            {
                return false;
            }
        }
    }
}
