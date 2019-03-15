using System.Text.RegularExpressions;

namespace Subtitler.Models
{
    class Movies
    {
        public string Name { get; set; }
        public string Url { get; set; }
        private string imgSrc;
        public string ImgSrc
        {
            get => Regex.Replace(imgSrc, @"\.\d\d\d\-", ".");
            set { imgSrc = value; }
        }
        public string ImdbUrl { get; set; }
        public string NumberOfSubtitle { get; set; } = "0 subtitle";
    }
}
