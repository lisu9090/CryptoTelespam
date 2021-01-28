using ProofOfConcept.Abstract.ApiClient;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.ApiClient.Service
{
    public class TestConsoleMessageApiService : IMessageApiService
    {
        public async Task SendAsync(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
