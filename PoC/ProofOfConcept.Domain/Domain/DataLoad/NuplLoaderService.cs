using AutoMapper;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Helper;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProofOfConcept.Abstract.ApiClient.Dto;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Domain.DataLoad
{
    public class NuplLoaderService : IDataLoaderService<Nupl>
    {
        private IRestApiService _apiService;
        private IMapper _mapper;

        public NuplLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<Nupl> LoadDataAsync(string cryptocurrencySymbol)
        {
            if(!(cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC) || cryptocurrencySymbol.Equals(CryptocurrencySymbol.ETH)))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<FloatValueTimestampDto> dtos = await _apiService.GetNuplAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
            
            Nupl entity = _mapper.DtoOrderedMap<FloatValueTimestampDto, Nupl>(dtos);
            
            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
