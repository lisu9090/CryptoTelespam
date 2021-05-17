using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Entity.Enum;
using ProofOfConcept.Domain.IndicatorTmp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class MarketCapThermocapRatioLoaderService : IDataLoaderService<MarketCapThermocapRatio>
    {
        private readonly IRestApiService _apiService;

        public MarketCapThermocapRatioLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
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