using Newtonsoft.Json;
using TradingEconomicsApp.Models;

namespace TradingEconomicsApp.Services
{
    public class TradingEconomicsService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.tradingeconomics.com/historical/country/{0}/indicator/GDP?c={1}:{2}";

        public TradingEconomicsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GdpData>> GetGdpDataAsync(string country, string username, string password)
        {
            var url = string.Format(BaseUrl, country, username, password);
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GdpData>>(json);
            }

            return null;
        }
    }
    
}
