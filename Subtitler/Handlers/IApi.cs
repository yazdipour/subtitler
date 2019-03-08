using Refit;
using System.Threading.Tasks;
using Subtitler.Models;
using System.Collections.ObjectModel;

namespace Subtitler.Handlers
{
    interface IApi
    {
        [Get("/home.php")]
        Task<ObservableCollection<Movies>> GetHome();

        [Get("/search.php")]
        Task<ObservableCollection<Movies>> GetRetItem([AliasAs("q")] string query);

        [Get("/movie.php")]
        //Task<T> GetMovieItems<T>([AliasAs("url")] string movieUrl, [AliasAs("lang")] int language = 0);
        Task<(Movies, Subtitle[])> GetMovieItems([AliasAs("url")] string movieUrl, [AliasAs("lang")] int language = 0);

        [Get("/links.php")]
        Task<string[]> GetSubtitleLinks([AliasAs("url")] string subtitleUrl);
    }
}
