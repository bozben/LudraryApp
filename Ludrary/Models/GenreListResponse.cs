using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class GenreListResponse
    {
        [JsonPropertyName("results")]
        public List<Genre> Genres { get; set; }
    }
}
