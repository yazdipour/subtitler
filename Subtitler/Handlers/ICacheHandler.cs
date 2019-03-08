using System;
using System.Reactive;
using System.Threading.Tasks;

namespace Subtitler.Handlers
{
    interface ICacheHandler
    {
        // Get an object serialized via InsertObject
        Task<T> GetObject<T>(string key);

        // Insert a single object
        Task<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null);

        // Delete a single item
        Task<Unit> InvalidateAsync(string key);
    }
}
