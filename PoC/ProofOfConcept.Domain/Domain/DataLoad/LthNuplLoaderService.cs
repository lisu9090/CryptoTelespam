using AutoMapper;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataLoad
{
    public class LthNuplLoaderService : IDataLoaderService<LthNupl>
    {
        private readonly IRestApiService _apiService;
        private readonly IMapper _mapper;

        public LthNuplLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<LthNupl> LoadDataAsync(string cryptocurrencySymbol)
        {
            if(!cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<FloatValueTimestampDto> dtos = await _apiService
                .GetLthNuplAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
            
            LthNupl entity = _mapper.DtoOrderedMap<FloatValueTimestampDto, LthNupl>(dtos);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
