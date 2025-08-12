using Ludrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
            if (searchParams.GenreIds.Any())
            {
                string genreString =string.Join(",", searchParams.GenreIds);
                url += $"&genres={genreString}";
            }
            if (searchParams.PlatformIds.Any())
            {
                string platformString = string.Join(",", searchParams.PlatformIds);
                url += $"&platforms={platformString}";
            }
            if (searchParams.TagIds.Any())
            {
                string tagString = string.Join(",", searchParams.TagIds);
                url += $"&tags={tagString}";
                url += "&tags_all=true";
            }
            if (searchParams.StartYear.HasValue || searchParams.EndYear.HasValue)
            {
                var startDate = $"{searchParams.StartYear ?? 1960}-01-01";
                var endDate = $"{searchParams.EndYear ?? DateTime.Now.Year}-12-31";
                url += $"&dates={startDate},{endDate}";
            }            
            if (!string.IsNullOrEmpty(searchParams.SearchText))
            {
                url += $"&search={searchParams.SearchText}";
            }
            if (!string.IsNullOrEmpty(searchParams.Ordering))
            {
                url += $"&ordering={searchParams.Ordering}";
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

        public async Task<List<Game>> GetGamesInSeriesAsync(int gameId)
        {
            var url = $"games/{gameId}/game-series?key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonContent=await response.Content.ReadAsStringAsync() ;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var similarGameResponse = JsonSerializer.Deserialize<GameListResponse>(jsonContent, options);

            return similarGameResponse.Games;
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            var url = $"genres?key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<GenreListResponse>(jsonContent, options);
            return result.Genres;
        }

        public async Task<List<Platform>> GetPlatformsAsync()
        {
            var url = $"platforms?key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<PlatformListResponse>(jsonContent, options);
            return result.Platforms;
        }
    }
}
