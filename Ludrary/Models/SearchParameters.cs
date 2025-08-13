namespace Ludrary.Models
{
    public class SearchParameters
    {
        public List<int> GenreIds { get; set; } = new();
        public List<int> PlatformIds { get; set; } = new();

        public List<int> TagIds { get; set; } = new();
        public string SearchText { get; set; }
        public string Ordering { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string GenreSlug { get; set; }
    }
}
