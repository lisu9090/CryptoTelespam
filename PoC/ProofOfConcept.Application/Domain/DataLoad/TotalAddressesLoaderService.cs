using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataLoad
{
    public class TotalAddressesLoaderService : IDataLoaderService<TotalAddresses>
    {
        private readonly IRestApiService _apiService;

        public TotalAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<TotalAddresses> LoadDataAsync(string cryptocurrencySymbol)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            TotalAddresses entity = await _apiService.GetTotalAddressesAsync(
                cryptocurrencySymbol,
                Convert.ToInt32(since.ToUnixTimeSeconds()),
                interval: Interval.HOUR);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}