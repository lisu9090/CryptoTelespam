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
    public class ActiveAddressesLoaderService : IIndicatorValueLoader<int>
    {
        private readonly IRestApiService _apiService;

        public ActiveAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<int> LoadAsync(int assetId)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<int>> values = await _apiService.GetActiveAddressesAsync(
                "BTC", //TODO get asset from db
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new ActiveAddresses(assetId, values);
        }

        public Task<IndicatorValueCollection<int>> LoadAsync(AssetId assetId)
        {
            throw new NotImplementedException();
        }
    }
}