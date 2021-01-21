using AutoMapper;
using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using ProofOfConcept.Domain.Const;
using ProofOfConcept.Domain.Helper;
using ProofOfConcept.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataLoad
{
    public class NuplLoaderService : IDataLoaderService<INupl>
    {
        private IRestApiService _apiAdapter;
        private IMapper _mapper;

        public NuplLoaderService(IRestApiService apiAdapter, IMapper mapper)
        {
            _apiAdapter = apiAdapter;
            _mapper = mapper;
        }

        public async Task<INupl> LoadDataAsync()
        {
            var since = DateTimeBuilder.UtcNow()
                .AddDays(-1)
                .Truncate()
                .Build();

            var dtos = await _apiAdapter.GetNuplAsync(AssetSymbol.BTC, Convert.ToInt32(since.ToUnixTimeSeconds()));
            var dto = dtos.OrderBy(item => item.T).LastOrDefault();

            return _mapper.Map<NuplEntity>(dto);
        }
    }
}
