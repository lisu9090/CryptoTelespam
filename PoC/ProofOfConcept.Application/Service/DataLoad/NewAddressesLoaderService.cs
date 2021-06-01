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
    public class NewAddressesLoaderService : IIndicatorValueLoader<int>
    {
        private readonly IRestApiService _apiService;

        public NewAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<IndicatorValueCollection<int>> LoadAsync(AssetId assetId)
        {
            throw new NotImplementedException();
        }

        public async Task<NewAddresses> LoadDataAsync(int assetId)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<int>> values = await _apiService.GetNewAddressesAsync(
                "BTC",
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new NewAddresses(assetId, values);
        }
    }
}