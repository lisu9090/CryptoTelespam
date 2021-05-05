using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Entity.Enum;
using ProofOfConcept.Domain.Indicator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class LthNuplLoaderService : IDataLoaderService<LthNupl>
    {
        private readonly IRestApiService _apiService;

        public LthNuplLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<LthNupl> LoadDataAsync(int assetId)
        {
            assetId = (int)AssetId.Btc; //Restrict to BTC

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<float>> values = await _apiService.GetLthNuplAsync(
                "BTC", //TODO get asset from db
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new LthNupl(assetId, values);
        }
    }
}