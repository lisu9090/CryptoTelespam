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
    public class LthNuplLoaderService : IIndicatorValueLoarder<float>
    {
        private readonly IRestApiService _apiService;

        public LthNuplLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<IndicatorValueCollection<float>> LoadAsync(AssetId assetId)
        {
            throw new NotImplementedException();
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