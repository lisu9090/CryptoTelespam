using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataLoad
{
    public class NuplLoaderService : IDataLoaderService<Nupl>
    {
        private readonly IRestApiService _apiService;

        public NuplLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<Nupl> LoadDataAsync(string cryptocurrencySymbol)
        {
            if (!(cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC) || cryptocurrencySymbol.Equals(CryptocurrencySymbol.ETH)))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            Nupl entity = await _apiService.GetNuplAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}