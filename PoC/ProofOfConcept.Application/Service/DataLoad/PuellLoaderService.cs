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
    public class PuellLoaderService : IIndicatorValueLoarder<float>
    {
        private readonly IRestApiService _apiService;

        public PuellLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<IndicatorValueCollection<float>> LoadAsync(AssetId assetId)
        {
            throw new NotImplementedException();
        }

        public async Task<Puell> LoadDataAsync(int assetId)
        {
            assetId = (int)AssetId.Btc; //Restrict to BTC

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<float>> values = await _apiService.GetPuellAsync(
                "BTC", //TODO get asset from db
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new Puell(assetId, values);
        }
    }
}