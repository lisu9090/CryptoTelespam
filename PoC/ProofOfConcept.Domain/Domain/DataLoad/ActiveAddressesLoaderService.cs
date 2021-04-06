using AutoMapper;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Application.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataLoad
{
    public class ActiveAddressesLoaderService : IDataLoaderService<ActiveAddresses>
    {
        private readonly IRestApiService _apiService;
        private readonly IMapper _mapper;

        public ActiveAddressesLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<ActiveAddresses> LoadDataAsync(string cryptocurrencySymbol)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IntValueTimestampDto> dtos = await _apiService.GetActiveAddressesAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
            
            ActiveAddresses entity = _mapper.DtoOrderedMap<IntValueTimestampDto, ActiveAddresses>(dtos);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
