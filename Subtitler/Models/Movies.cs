using System.Text.RegularExpressions;

namespace Subtitler.Models
{
    class Movie
    {
        public string Name { get; set; }
        public string year { get; set; }
        public string Year
        {
            get => year?.Replace(" ", "");
            set => year = value;
        }
        public string Url { get; set; }
        private string imgSrc;
        public string ImgSrc
        {
            get => Regex.Replace(imgSrc ?? "", @"\.\d\d\d\-", ".");
            set => imgSrc = value;
        }
        public string ImdbUrl { get; set; }
        public string NumberOfSubtitle { get; set; } = "0 subtitle";
        public string SubsceneUrl => "https://subscene.com" + Url;
        public bool IsFav { get; set; } = false;
    }
}
