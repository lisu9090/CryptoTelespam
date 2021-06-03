using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Database.Domain;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Application.Service.DataLoad.Abstract;
using ProofOfConcept.Domain.Entity;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad
{
    public class ActiveAddressesLoaderService : IIndicatorValueLoader<int>
    {
        private readonly IRestApiService _apiService;
        private readonly IAssetRepository _assetRepository;

        public ActiveAddressesLoaderService(IRestApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IndicatorValueCollection<int>> LoadAsync(AssetId assetId, int resolution)
        {
            if (resolution <= 0)
            {
                throw new ArgumentOutOfRangeException("Resolution must be greater than 0");
            }

            Asset asset = await _assetRepository.GetByIdAsync((int)assetId);

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-resolution)
                .Truncate()
                .Build();

            IEnumerable<IndicatorValue<int>> values = await _apiService.GetActiveAddressesAsync(
                asset.Symbol,
                Convert.ToInt32(since.ToUnixTimeSeconds()));

            return new IndicatorValueCollection<int>(
                values,
                IndicatorId.ActiveAddresses,
                assetId);
        }
    }
}