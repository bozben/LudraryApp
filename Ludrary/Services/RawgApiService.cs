using Ludrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ludrary.Services
{
    public class RawgApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        string apiKey;
        public RawgApiService (HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiKey = _configuration["Rawg:ApiKey"];
        }

        public async Task<List<Game>> GetPopularGamesAsync()
        {
            var url = $"games?key={apiKey}&page_size=12";

            var response =await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonContent =  await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var GameListResponse = JsonSerializer.Deserialize<GameListResponse>(jsonContent, options);

            return GameListResponse.Games;
        }

        public async Task<List<Game>> SearchGamesAsync(SearchParameters searchParams,int page=1)
        {
            var url = $"games?key={apiKey}&page={page}&page_size=12";
            if (!string.IsNullOrEmpty(searchParams.Genres))
            {
                url += $"&genres={searchParams.Genres}";
            }

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync() ;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var SearchListResponse = JsonSerializer.Deserialize<GameListResponse>(jsonContent, options);

            return SearchListResponse.Games;
        }

        public async Task<GameInfo?> GetGameInfoAsync(int id)
        {
            var url = $"games/{id}?key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonContent= await response.Content.ReadAsStringAsync() ;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<GameInfo>(jsonContent, options);

            return result;
        }
    }
}
