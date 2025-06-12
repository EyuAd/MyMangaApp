using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyMangaApp.Services
{
    public class MangaDexApiServices
    {
        private readonly HttpClient _httpClient;
    
    public MangaDexApiServices()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> SearchMangaAsync(string title)
        {
            string url = $"https://api.mangadex.org/manga?title={Uri.EscapeDataString(title)}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}