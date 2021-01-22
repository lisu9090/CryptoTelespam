using AutoMapper;
using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Helper;
using ProofOfConcept.Domain.Model;
using System;
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

        public async Task<INupl> LoadDataAsync(string cryptocurrencySymbol)
        {
            if(!(cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC) || cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC)))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            var since = DateTimeBuilder.UtcNow()
                .AddDays(-1)
                .Truncate()
                .Build();

            var dtos = await _apiAdapter.GetNuplAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
            var dto = dtos.OrderBy(item => item.T).LastOrDefault();
            var entity = _mapper.Map<NuplEntity>(dto);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
