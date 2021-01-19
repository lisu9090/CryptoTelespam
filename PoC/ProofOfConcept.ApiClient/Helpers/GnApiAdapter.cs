using ProofOfConcept.AbstractApiClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProofOfConcept.ApiClient.Helpers
{
    class GnApiAdapter : IRestApiAdapter
    {
        private readonly int _timeout;
        private readonly string _apiBase;
        private readonly string _apiKeyParamName;
        private readonly string _key;
        private HttpClient _httpClient;

        public GnApiAdapter(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _timeout = int.Parse(configuration["Api:Timeout"]);
            _apiBase = configuration["Api:BaseUrl"];
            _apiKeyParamName = configuration["Api:ApiKeyParamName"];
            _key = configuration["Api:Key"];

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<NuplDto>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = "24h", string format = "JSON")
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

            return JsonSerializer.Deserialize<IEnumerable<NuplDto>>(responseString);
        }
    }
}
