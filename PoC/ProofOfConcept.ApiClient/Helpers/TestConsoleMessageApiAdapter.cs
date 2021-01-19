using ProofOfConcept.AbstractApiClient;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.ApiClient.Helpers
{
    class TestConsoleMessageApiAdapter : IMessageApiAdapter
    {
        public async Task SendAsync(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
