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
    public class TotalAddressesLoaderService : IIndicatorValueLoader<int>
    {
        private readonly IRestApiService _apiService;

        public TotalAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<IndicatorValueCollection<int>> LoadAsync(AssetId assetId)
        {
            throw new NotImplementedException();
        }

        public async Task<TotalAddresses> LoadDataAsync(int assetId)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<int>> values = await _apiService.GetTotalAddressesAsync(
                "BTC",
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new TotalAddresses(assetId, values);
        }
    }
}