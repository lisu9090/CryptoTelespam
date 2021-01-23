﻿using AutoMapper;
using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Helper;
using ProofOfConcept.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataLoad
{
    public class NewAddressesLoaderService : IDataLoaderService<INewAddresses>
    {
        private IRestApiService _apiService;
        private IMapper _mapper;

        public NewAddressesLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<INewAddresses> LoadDataAsync(string cryptocurrencySymbol)
        {
            var since = DateTimeBuilder.UtcNow()
                .AddDays(-1)
                .Truncate()
                .Build();

            var dtos = await _apiService.GetNewAddressesAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
            var dto = dtos.OrderBy(item => item.T).LastOrDefault();
            var entity = _mapper.Map<NewAddressesEntity>(dto);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
