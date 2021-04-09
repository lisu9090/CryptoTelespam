﻿using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class MvrvRatioLoaderService : IDataLoaderService<MvrvRatio>
    {
        private readonly IRestApiService _apiService;

        public MvrvRatioLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<MvrvRatio> LoadDataAsync(string cryptocurrencySymbol)
        {
            if (!cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            MvrvRatio entity = await _apiService.GetMvrvRatioAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}