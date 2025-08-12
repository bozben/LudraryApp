using System.Text.Json.Serialization;

namespace Ludrary.Models
{
    public class TagListResponse
    {
        [JsonPropertyName("results")]
        public List<Tag> Tags{ get; set; }
    }
}
