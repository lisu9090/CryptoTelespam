using AutoMapper;
using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.ApiClient.Dto;
using ProofOfConcept.ApiClient.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
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
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly ILogger<GlassNodeApiService> _logger;

        public GlassNodeApiService(
            int timeout,
            string apiBase,
            string apiKeyParamName,
            string key,
            HttpClient httpClient,
            IMapper mapper,
            ILogger<GlassNodeApiService> logger)
        {
            _apiBase = apiBase;
            _apiKeyParamName = apiKeyParamName;
            _key = key;
            _httpClient = httpClient;
            _mapper = mapper;
            _logger = logger;

            _jsonDefaults = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _httpClient.Timeout = System.TimeSpan.FromSeconds(timeout);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<TResult> GetIndicatorAsync<TDto, TResult>(
            string endpoint,
            string asset,
            int sinceTimeStamp,
            int untilTimeStamp,
            string interval,
            string format) where TDto : TimestampDto
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

            IEnumerable<TDto> dtos = JsonSerializer.Deserialize<IEnumerable<TDto>>(responseString, _jsonDefaults);

            return _mapper.DtoOrderedMap<TDto, TResult>(dtos);
        }

        public async Task<Nupl> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            //todo add error handling + retry;
            return await GetIndicatorAsync<FloatValueTimestampDto, Nupl>("/v1/metrics/indicators/net_unrealized_profit_loss",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<Puell> GetPuellMultipleAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<FloatValueTimestampDto, Puell>("v1/metrics/indicators/puell_multiple",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<NewAddresses> GetNewAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IntValueTimestampDto, NewAddresses>("/v1/metrics/addresses/sending_to_exchanges_count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<TotalAddresses> GetTotalAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IntValueTimestampDto, TotalAddresses>("/v1/metrics/addresses/count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<ActiveAddresses> GetActiveAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<IntValueTimestampDto, ActiveAddresses>("/v1/metrics/addresses/active_count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<StfDeflection> GetStfDefectionAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<FloatValueTimestampDto, StfDeflection>("/v1/metrics/indicators/stock_to_flow_deflection",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<LthNupl> GetLthNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<FloatValueTimestampDto, LthNupl>("/v1/metrics/indicators/nupl_more_155",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<MarketCapThermocapRatio> GetMarketCapThermocapRatioAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<FloatValueTimestampDto, MarketCapThermocapRatio>("/v1/metrics/mining/marketcap_thermocap_ratio",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }
    }
}