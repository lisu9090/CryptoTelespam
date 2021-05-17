using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Entity.Enum;
using ProofOfConcept.Domain.IndicatorTmp;
using System;
using System.Collections.Generic;
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

        public async Task<MvrvRatio> LoadDataAsync(int assetId)
        {
            assetId = (int)AssetId.Btc; //Restrict to BTC

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<float>> values = await _apiService.GetMvrvRatioAsync(
                "BTC",
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new MvrvRatio(assetId, values);
        }
    }
}