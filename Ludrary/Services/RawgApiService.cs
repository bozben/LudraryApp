using Ludrary.Models;
using System.Text.Json;

namespace Ludrary.Services
{
    public class RawgApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RawgApiService (HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Game>> GetPopularGamesAsync()
        {
            string apiKey = _configuration["Rawg:ApiKey"];

            var response =await _httpClient.GetAsync($"games?key={apiKey}&page_size=12");
            response.EnsureSuccessStatusCode();

            string jsonContent =  await response.Content.ReadAsStringAsync();
            var GameListResponse = JsonSerializer.Deserialize<GameListResponse>(jsonContent);

            return GameListResponse.Games;
        }
    }
}
