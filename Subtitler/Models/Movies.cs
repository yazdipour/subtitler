namespace Subtitler.Models
{
    class Movies
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImgSrc { get; set; }
        public string ImdbUrl { get; set; }
        public string NumberOfSubtitle { get; set; } = "0 subtitle";
    }
}
