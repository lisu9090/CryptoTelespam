using ProofOfConcept.AbstractApiClient.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractApiClient
{
    public interface IRestApiService
    {
        Task<IEnumerable<INuplDto>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = "24h", string format = "JSON");
    }
}
