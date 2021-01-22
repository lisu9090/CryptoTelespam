using ProofOfConcept.AbstractApiClient.Dto;
using ProofOfConcept.Common.Const;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractApiClient
{
    public interface IRestApiService
    {
        Task<IEnumerable<INuplDto>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
    }
}
