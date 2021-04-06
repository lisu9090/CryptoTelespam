using AutoMapper;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataLoad
{
    public class MarketCapThermocapRatioLoaderService : IDataLoaderService<MarketCapThermocapRatio>
    {
        private readonly IRestApiService _apiService;
        private readonly IMapper _mapper;

        public MarketCapThermocapRatioLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<MarketCapThermocapRatio> LoadDataAsync(string cryptocurrencySymbol)
        {
            if (!(cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC) || cryptocurrencySymbol.Equals(CryptocurrencySymbol.ETH)))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<FloatValueTimestampDto> dtos = await _apiService.GetMarketCapThermocapRatioAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            MarketCapThermocapRatio entity = _mapper.DtoOrderedMap<FloatValueTimestampDto, MarketCapThermocapRatio>(dtos);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}