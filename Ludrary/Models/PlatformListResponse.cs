using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class PlatformListResponse
    {
        [JsonPropertyName("results")]
        public List<Platform> Platforms{ get; set; }

        
    }
}
