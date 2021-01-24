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
    public class LthNuplLoaderService : IDataLoaderService<ILthNupl>
    {
        private IRestApiService _apiService;
        private IMapper _mapper;

        public LthNuplLoaderService(IRestApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<ILthNupl> LoadDataAsync(string cryptocurrencySymbol)
        {
            if(!cryptocurrencySymbol.Equals(CryptocurrencySymbol.BTC))
            {
                cryptocurrencySymbol = CryptocurrencySymbol.BTC;
            }

            var since = DateTimeBuilder.UtcNow()
                .AddDays(-1)
                .Truncate()
                .Build();

            var dtos = await _apiService.GetLthNuplAsync(cryptocurrencySymbol, Convert.ToInt32(since.ToUnixTimeSeconds()));
            var dto = dtos.OrderBy(item => item.T).LastOrDefault();
            var entity = _mapper.Map<LthNuplEntity>(dto);

            entity.CryptocurrencySymbol = cryptocurrencySymbol;

            return entity;
        }
    }
}
