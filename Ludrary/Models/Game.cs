using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace Ludrary.Models
{
    public class ShortScreenshot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }
    }
    public class Store
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
    public class StoreEntry
    {
        [JsonPropertyName("store")]
        public Store Store { get; set; }
    }
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("background_image")]
        public string BackgroundImage { get; set; }
        [JsonPropertyName("metacritic")]
        public int? Metacritic { get; set; }
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }
        [JsonPropertyName("short_screenshots")]
        public List<ShortScreenshot> ShortScreenshots { get; set; }

        [JsonPropertyName("released")] 
        public string Released { get; set; }
        [JsonPropertyName("stores")]
        public List<StoreEntry> Stores { get; set; }
    }
}
