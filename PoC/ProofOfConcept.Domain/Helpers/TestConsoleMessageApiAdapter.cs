using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Helpers
{
    class TestConsoleMessageApiAdapter : IMessageApiAdapter
    {
        public async Task SendAsync(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
