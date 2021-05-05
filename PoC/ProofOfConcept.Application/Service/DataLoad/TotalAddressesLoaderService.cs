using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Indicator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class TotalAddressesLoaderService : IDataLoaderService<TotalAddresses>
    {
        private readonly IRestApiService _apiService;

        public TotalAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
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