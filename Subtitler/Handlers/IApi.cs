using Refit;
using System.Threading.Tasks;
using Subtitler.Models;
using System.Collections.ObjectModel;

namespace Subtitler.Handlers
{
    interface IApi
    {
        [Get("/home.php")]
        Task<ObservableCollection<Movie>> GetHome();

        [Get("/search.php")]
        Task<ObservableCollection<Movie>> GetSearch([AliasAs("q")] string query);

        [Get("/movie.php")]
        Task<T> GetMovieItems<T>([AliasAs("url")] string movieUrl, [AliasAs("lang")] int language = 0);

        [Get("/links.php")]
        Task<ObservableCollection<string>> GetSubtitleLinks([AliasAs("url")] string subtitleUrl);
    }
}
