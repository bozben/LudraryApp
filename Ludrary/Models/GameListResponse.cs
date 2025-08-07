using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class GameListResponse
    {
        [JsonPropertyName("results")]
        public List<Game> Games { get; set; }
    }
}
