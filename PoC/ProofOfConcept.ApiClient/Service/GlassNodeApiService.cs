using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractApiClient.Dto;
using ProofOfConcept.ApiClient.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProofOfConcept.ApiClient.Service
{
    public class GlassNodeApiService : IRestApiService
    {
        private readonly int _timeout;
        private readonly string _apiBase;
        private readonly string _apiKeyParamName;
        private readonly string _key;
        private HttpClient _httpClient;

        public GlassNodeApiService(int timeout, string apiBase, string apiKeyParamName, string key, HttpClient httpClient)
        {
            _timeout = timeout;
            _apiBase = apiBase;
            _apiKeyParamName = apiKeyParamName;
            _key = key;
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<INuplDto>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = "24h", string format = "JSON")
        {
            var uri = new UriBuilder(_apiBase, _apiKeyParamName, _key)
                .SetEndpoint("/v1/metrics/indicators/net_unrealized_profit_loss")
                .AddParameter("a", asset)
                .AddParameter("s", sinceTimeStamp)
                .AddParameter("u", untilTimeStamp)
                .AddParameter("i", interval)
                .AddParameter("f", format)
                .Biuld();

            var responseString = await _httpClient.GetStringAsync(uri);

            return JsonSerializer.Deserialize<IEnumerable<INuplDto>>(responseString);
        }
    }
}
