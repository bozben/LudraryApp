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
        public List<DetailDevolopers> Developers { get; set; }

        [JsonPropertyName("platforms")]
        public List<DetailPlatformEntry> Platforms { get; set; }

        [JsonPropertyName("genres")]
        public List<DetailGenres> Genres { get; set; }

        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }
    }

    public class DetailDevolopers
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }

    public class DetailGenres
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }


    public class DetailPlatformEntry
    {
        [JsonPropertyName("platform")]
        public DetailPlatform Platform { get; set; }
    }

    public class DetailPlatform
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}