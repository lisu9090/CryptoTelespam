using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Domain;
using System;
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

        public async Task<NewAddresses> LoadDataAsync(string cryptocurrencySymbol)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            NewAddresses entity = await _apiService.GetNewAddressesAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}