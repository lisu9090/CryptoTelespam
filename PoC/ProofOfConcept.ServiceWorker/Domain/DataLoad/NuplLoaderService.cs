using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Const;
using ProofOfConcept.ServiceWorker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Domain.DataLoad
{
    class NuplLoaderService : IDataLoaderService<NuplEntity>
    {
        private IRestApiAdapter _apiAdapter;

        public NuplLoaderService(IRestApiAdapter apiAdapter)
        {
            _apiAdapter = apiAdapter;
        }

        public async Task<NuplEntity> LoadDataAsync()
        {
            var dataString = await _apiAdapter.GetNuplAsync(AssetSymbol.BTC);

            //todo import mapper, create dto

            return new NuplEntity();
        }
    }
}
