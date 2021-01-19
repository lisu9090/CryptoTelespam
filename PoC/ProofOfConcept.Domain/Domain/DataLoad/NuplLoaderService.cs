using AutoMapper;
using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using ProofOfConcept.Domain.Const;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataLoad
{
    public class NuplLoaderService : IDataLoaderService<NuplEntity>
    {
        private IRestApiService _apiAdapter;
        private IMapper _mapper;

        public NuplLoaderService(IRestApiService apiAdapter, IMapper mapper)
        {
            _apiAdapter = apiAdapter;
            _mapper = mapper;
        }

        public async Task<NuplEntity> LoadDataAsync()
        {
            var dto = await _apiAdapter.GetNuplAsync(AssetSymbol.BTC);


            //todo import mapper, map to entity

            return new NuplEntity();
        }
    }
}
