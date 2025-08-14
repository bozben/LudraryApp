using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class ShortScreenshot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }
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
        
    }
}
