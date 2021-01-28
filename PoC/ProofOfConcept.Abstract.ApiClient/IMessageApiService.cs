using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.ApiClient
{
    public interface IMessageApiService
    {
        Task SendAsync(string msg);
    }
}
