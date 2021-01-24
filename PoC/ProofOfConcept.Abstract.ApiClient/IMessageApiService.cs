using System.Threading.Tasks;

namespace ProofOfConcept.AbstractApiClient
{
    public interface IMessageApiService
    {
        Task SendAsync(string msg);
    }
}
