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
    public class NuplLoaderService : IIndicatorValueLoader<float>
    {
        private readonly IRestApiService _apiService;

        public NuplLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<IndicatorValueCollection<float>> LoadAsync(AssetId assetId)
        {
            throw new NotImplementedException();
        }

        public async Task<Nupl> LoadDataAsync(int assetId)
        {
            if (assetId != (int)AssetId.Btc && assetId != (int)AssetId.Eth) //TODO create collection with allowed Assets
            {
                assetId = (int)AssetId.Btc;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<float>> values = await _apiService.GetNuplAsync(
                "BTC",
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new Nupl(assetId, values);
        }
    }
}