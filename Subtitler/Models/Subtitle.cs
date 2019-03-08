namespace Subtitler.Models
{
    class Subtitle
    {
        public string Lang { get; set; } = "English";
        public string Name { get; set; } = "_film_";
        public string Owner { get; set; } = "Owner";
        public string Url { get; set; } = "";
        public string Rate { get; set; } = "#4FC3F7";
        public bool HearingImpaired { get; set; } = false;
    }
}
