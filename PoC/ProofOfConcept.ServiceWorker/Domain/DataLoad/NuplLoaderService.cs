using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Domain.DataLoad
{
    class NuplLoaderService : IDataLoaderService
    {
        public Task<object> QueryAsync()
        {
            return Task.Run(() => new object());
        }
    }
}
