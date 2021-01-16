using System.Net.Http;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IRestApiAdapter
    {
        Task<string> GetNuplAsync(string asset, int sinceTimeStamp = int.MinValue, int untilTimeStamp = int.MaxValue, string interval = "24h", string format = "JSON");
    }
}
