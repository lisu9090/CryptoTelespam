﻿using AutoMapper;
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
    public class PuellLoaderService : IDataLoaderService<Puell>
    {
        private readonly IRestApiService _apiService;
        private readonly IMapper _mapper;

        public PuellLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<Puell> LoadDataAsync(string cryptocurrencySymbol)
        {
            if (!cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            DateTimeOffset since = DateTimeBuilder.UtcNow()
                .AddDays(-2)
                .Truncate()
                .Build();

            IEnumerable<FloatValueTimestampDto> dtos = await _apiService.GetPuellMultipleAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));

            Puell entity = _mapper.DtoOrderedMap<FloatValueTimestampDto, Puell>(dtos);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}