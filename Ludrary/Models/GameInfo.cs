using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class GameInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description_raw")]
        public string Description { get; set; }

        [JsonPropertyName("metacritic")]
        public int? Metacritic { get; set; }

        [JsonPropertyName("background_image")]
        public string BackgroundImage { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("developers")]
        public List<Developer> Developers { get; set; }

        [JsonPropertyName("platforms")]
        public List<PlatformEntry> Platforms { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }
    }

    public class Developer
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Genre
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }


    public class PlatformEntry
    {
        [JsonPropertyName("platform")]
        public Platform Platform { get; set; }
    }

    public class Platform
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}