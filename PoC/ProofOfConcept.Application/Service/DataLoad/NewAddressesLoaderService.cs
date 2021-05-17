using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.IndicatorTmp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class NewAddressesLoaderService : IDataLoaderService<NewAddresses>
    {
        private readonly IRestApiService _apiService;

        public NewAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
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