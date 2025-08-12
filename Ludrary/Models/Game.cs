using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = new();
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("background_image")]
        public string BackgroundImage { get; set; }
        [JsonPropertyName("metacritic")]
        public int? Metacritic { get; set; }
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }

    }
}
