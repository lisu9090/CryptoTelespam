﻿using AutoMapper;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Domain.Helper;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.Common.Const;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Domain.DataLoad
{
    public class TotalAddressesLoaderService : IDataLoaderService<TotalAddresses>
    {
        private IRestApiService _apiService;
        private IMapper _mapper;

        public TotalAddressesLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<TotalAddresses> LoadDataAsync(string cryptocurrencySymbol)
        {
            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<IntValueTimestampDto> dtos = await _apiService.GetTotalAddressesAsync(cryptocurrencySymbol, 
                Convert.ToInt32(since.ToUnixTimeSeconds()), 
                interval: Interval.HOUR);
            
            TotalAddresses entity = _mapper.DtoOrderedMap<IntValueTimestampDto, TotalAddresses>(dtos);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
