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
    public class StfDeflectionLoaderService : IDataLoaderService<StfDeflection>
    {
        private IRestApiService _apiService;
        private IMapper _mapper;

        public StfDeflectionLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<StfDeflection> LoadDataAsync(string cryptocurrencySymbol)
        {
            if(!cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<FloatValueTimestampDto> dtos = await _apiService.GetStfDefectionAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
           
            StfDeflection entity = _mapper.DtoOrderedMap<FloatValueTimestampDto, StfDeflection>(dtos);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
