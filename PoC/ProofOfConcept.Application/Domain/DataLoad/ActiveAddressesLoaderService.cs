using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataLoad
{
    public class ActiveAddressesLoaderService : IDataLoaderService<ActiveAddresses>
    {
        private readonly IRestApiService _apiService;

        public ActiveAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ActiveAddresses> LoadDataAsync(string cryptocurrencySymbol)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            ActiveAddresses entity = await _apiService.GetActiveAddressesAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}