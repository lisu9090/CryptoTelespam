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
    public class StfDeflectionLoaderService : IDataLoaderService<StfDeflection>
    {
        private readonly IRestApiService _apiService;

        public StfDeflectionLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<StfDeflection> LoadDataAsync(int assetId)
        {
            assetId = (int)AssetId.Btc; //Restrict to BTC

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<float>> values = await _apiService.GetStfDefectionAsync(
                "BTC", //TODO get asset from db
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new StfDeflection(assetId, values);
        }
    }
}