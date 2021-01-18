using ProofOfConcept.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Abstract
{
    public interface IRestApiAdapter
    {
        Task<IEnumerable<NuplDto>> GetNuplAsync(string asset, int sinceTimeStamp = int.MinValue, int untilTimeStamp = int.MaxValue, string interval = "24h", string format = "JSON");
    }
}
