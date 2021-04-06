using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataLoad
{
    public class StfDeflectionLoaderService : IDataLoaderService<StfDeflection>
    {
        private readonly IRestApiService _apiService;

        public StfDeflectionLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<StfDeflection> LoadDataAsync(string cryptocurrencySymbol)
        {
            if (!cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            StfDeflection entity = await _apiService.GetStfDefectionAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}