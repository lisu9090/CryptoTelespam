using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Application.Service.DataLoad.Abstract;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class MarketCapThermocapRatioLoaderService : IIndicatorValueLoarder<float>
    {
        private readonly IRestApiService _apiService;

        public MarketCapThermocapRatioLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<IndicatorValueCollection<float>> LoadAsync(AssetId assetId)
        {
            throw new NotImplementedException();
        }

        public async Task<MarketCapThermocapRatio> LoadDataAsync(int assetId)
        {
            if (assetId != (int)AssetId.Btc && assetId != (int)AssetId.Eth) //TODO create collection with allowed Assets
            {
                assetId = (int)AssetId.Btc;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<float>> values = await _apiService.GetMarketCapThermocapRatioAsync(
                "BTC",
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new MarketCapThermocapRatio(assetId, values);
        }
    }
}