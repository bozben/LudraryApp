using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class Tag
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
}
