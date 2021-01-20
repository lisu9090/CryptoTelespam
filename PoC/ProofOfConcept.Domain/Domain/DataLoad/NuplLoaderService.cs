using AutoMapper;
using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using ProofOfConcept.Domain.Const;
using ProofOfConcept.Domain.Model;
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
            var dto = await _apiAdapter.GetNuplAsync(AssetSymbol.BTC);
            var nupl = _mapper.Map<INupl>(dto);

            return nupl;
        }
    }
}
