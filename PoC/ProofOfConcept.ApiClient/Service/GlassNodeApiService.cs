using AutoMapper;
using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.ApiClient.Dto;
using ProofOfConcept.ApiClient.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Indicator;
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

        private async Task<IEnumerable<TResult>> GetIndicatorAsync<TDto, TResult>(
            string endpoint,
            string asset,
            int sinceTimeStamp,
            int untilTimeStamp,
            string interval,
            string format)
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

            return _mapper.Map<IEnumerable<TDto>, IEnumerable<TResult>>(dtos);
        }

        public async Task<IEnumerable<IndicatorValue<float>>> GetNuplAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            //TODO add error handling + retry;
            return await GetIndicatorAsync<TimestampedFloatValueDto, IndicatorValue<float>>(
                "/v1/metrics/indicators/net_unrealized_profit_loss",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<float>>> GetPuellMultipleAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<TimestampedFloatValueDto, IndicatorValue<float>>(
                "v1/metrics/indicators/puell_multiple",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<int>>> GetNewAddressesAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<TimestampedIntValueDto, IndicatorValue<int>>(
                "/v1/metrics/addresses/sending_to_exchanges_count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<int>>> GetTotalAddressesAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<TimestampedIntValueDto, IndicatorValue<int>>(
                "/v1/metrics/addresses/count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<int>>> GetActiveAddressesAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<TimestampedIntValueDto, IndicatorValue<int>>(
                "/v1/metrics/addresses/active_count",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<float>>> GetStfDefectionAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<TimestampedFloatValueDto, IndicatorValue<float>>(
                "/v1/metrics/indicators/stock_to_flow_deflection",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<float>>> GetLthNuplAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<TimestampedFloatValueDto, IndicatorValue<float>>(
                "/v1/metrics/indicators/nupl_more_155",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<float>>> GetMarketCapThermocapRatioAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = Interval.DAY,
            string format = MediaType.JSON)
        {
            return await GetIndicatorAsync<TimestampedFloatValueDto, IndicatorValue<float>>(
                "/v1/metrics/mining/marketcap_thermocap_ratio",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<float>>> GetMvrvRatioAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = "24h",
            string format = "JSON")
        {
            return await GetIndicatorAsync<TimestampedFloatValueDto, IndicatorValue<float>>(
                "/v1/metrics/market/mvrv",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }

        public async Task<IEnumerable<IndicatorValue<float>>> GetMvrvZScoreAsync(
            string asset,
            int sinceTimeStamp = 0,
            int untilTimeStamp = int.MaxValue,
            string interval = "24h",
            string format = "JSON")
        {
            return await GetIndicatorAsync<TimestampedFloatValueDto, IndicatorValue<float>>(
                "/v1/metrics/market/mvrv_z_score",
                asset,
                sinceTimeStamp,
                untilTimeStamp,
                interval,
                format);
        }
    }
}