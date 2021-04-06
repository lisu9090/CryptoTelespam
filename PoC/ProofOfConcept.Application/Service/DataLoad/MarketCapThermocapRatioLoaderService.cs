using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class MarketCapThermocapRatioLoaderService : IDataLoaderService<MarketCapThermocapRatio>
    {
        private readonly IRestApiService _apiService;

        public MarketCapThermocapRatioLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<MarketCapThermocapRatio> LoadDataAsync(string cryptocurrencySymbol)
        {
            if (!(cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC) || cryptocurrencySymbol.Equals(CryptocurrencySymbol.ETH)))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            MarketCapThermocapRatio entity = await _apiService.GetMarketCapThermocapRatioAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}