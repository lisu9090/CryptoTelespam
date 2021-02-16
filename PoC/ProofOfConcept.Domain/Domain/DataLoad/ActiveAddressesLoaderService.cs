using AutoMapper;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Helper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataLoad
{
    public class ActiveAddressesLoaderService : IDataLoaderService<ActiveAddresses>
    {
        private IRestApiService _apiService;
        private IMapper _mapper;

        public ActiveAddressesLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<ActiveAddresses> LoadDataAsync(string cryptocurrencySymbol)
        {
            var since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            var dtos = await _apiService.GetActiveAddressesAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
            
            var entity = _mapper.DtoOrderedMap<IntValueTimestampDto, ActiveAddresses>(dtos);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
