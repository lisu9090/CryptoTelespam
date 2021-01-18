using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Domain.DataProcess
{
    class NuplEventDetectorService : IDataProcessorService<NuplEntity>
    {
        public Task<bool> DetectEventAsync(NuplEntity data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
