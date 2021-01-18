﻿using ProofOfConcept.AbstractDomain;
using ProofOfConcept.Domain.Abstract;
using ProofOfConcept.Domain.Const;
using ProofOfConcept.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataLoad
{
    public class NuplLoaderService : IDataLoaderService<NuplEntity>
    {
        private IRestApiAdapter _apiAdapter;

        public NuplLoaderService(IRestApiAdapter apiAdapter)
        {
            _apiAdapter = apiAdapter;
        }

        public async Task<NuplEntity> LoadDataAsync()
        {
            var dto = await _apiAdapter.GetNuplAsync(AssetSymbol.BTC);

            //todo import mapper, map to entity

            return new NuplEntity();
        }
    }
}
