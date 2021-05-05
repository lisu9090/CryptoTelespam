using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Entity.Enum;
using ProofOfConcept.Domain.Indicator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class MvrvZScoreLoaderService : IDataLoaderService<MvrvZScore>
    {
        private readonly IRestApiService _apiService;

        public MvrvZScoreLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<MvrvZScore> LoadDataAsync(int assetId)
        {
            assetId = (int)AssetId.Btc; //Restrict to BTC

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<float>> values = await _apiService.GetMvrvZScoreAsync(
                "BTC",
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new MvrvZScore(assetId, values);
        }
    }
}