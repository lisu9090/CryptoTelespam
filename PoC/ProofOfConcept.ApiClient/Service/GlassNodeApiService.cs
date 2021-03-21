using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.ApiClient.Helpers;
using ProofOfConcept.Common.Const;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProofOfConcept.ApiClient.Service
{
    public class GlassNodeApiService : IRestApiService
    {
        private readonly string _apiBase;
        private readonly string _apiKeyParamName;
        private readonly string _key;
        private readonly JsonSerializerOptions _jsonDefaults;
        private readonly ILogger<GlassNodeApiService> _logger;
        private HttpClient _httpClient;

        public GlassNodeApiService(int timeout, 
            string apiBase, 
            string apiKeyParamName,
            string key,
            HttpClient httpClient, 
            ILogger<GlassNodeApiService> logger)
        {
            _apiBase = apiBase;
            _apiKeyParamName = apiKeyParamName;
            _key = key;
            _httpClient = httpClient;
            _logger = logger;

            _jsonDefaults = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _httpClient.Timeout = System.TimeSpan.FromSeconds(timeout);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<FloatValueTimestampDto>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            //todo add error handling + retry;
            return await GetIndicatorAsync<IEnumerable<FloatValueTimestampDto>>("/v1/metrics/indicators/net_unrealized_profit_loss",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<FloatValueTimestampDto>> GetPuellMultipleAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IEnumerable<FloatValueTimestampDto>>("v1/metrics/indicators/puell_multiple",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IntValueTimestampDto>> GetNewAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IEnumerable<IntValueTimestampDto>>("/v1/metrics/addresses/sending_to_exchanges_count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IntValueTimestampDto>> GetTotalAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IEnumerable<IntValueTimestampDto>>("/v1/metrics/addresses/count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IntValueTimestampDto>> GetActiveAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IEnumerable<IntValueTimestampDto>>("/v1/metrics/addresses/active_count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<FloatValueTimestampDto>> GetStfDefectionAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IEnumerable<FloatValueTimestampDto>>("/v1/metrics/indicators/stock_to_flow_deflection",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<FloatValueTimestampDto>> GetLthNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IEnumerable<FloatValueTimestampDto>>("/v1/metrics/indicators/nupl_more_155",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<FloatValueTimestampDto>> GetMarketCapThermocapRatioAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IEnumerable<FloatValueTimestampDto>>("/v1/metrics/mining/marketcap_thermocap_ratio",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        private async Task<TResult> GetIndicatorAsync<TResult>(string endpoint, string asset, int sinceTimeStamp, int untilTimeStamp, string interval, string format)
        {
            string uri = new UriBuilder(_apiBase, _apiKeyParamName, _key)
                 .SetEndpoint(endpoint)
                 .AddParameter("a", asset)
                 .AddParameter("s", sinceTimeStamp)
                 .AddParameter("u", untilTimeStamp)
                 .AddParameter("i", interval)
                 .AddParameter("f", format)
                 .Biuld();

            _logger.LogInformation(uri);

            string responseString = await _httpClient.GetStringAsync(uri);

            return JsonSerializer.Deserialize<TResult>(responseString, _jsonDefaults);
        }
    }
}
