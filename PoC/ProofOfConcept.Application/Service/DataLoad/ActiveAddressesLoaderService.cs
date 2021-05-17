using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Domain.IndicatorTmp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class ActiveAddressesLoaderService : IDataLoaderService<ActiveAddresses>
    {
        private readonly IRestApiService _apiService;

        public ActiveAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ActiveAddresses> LoadDataAsync(int assetId)
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
    }
}