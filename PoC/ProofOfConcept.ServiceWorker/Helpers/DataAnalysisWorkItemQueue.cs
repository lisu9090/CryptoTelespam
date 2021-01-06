using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class DataAnalysisWorkItemQueue : IWorkItemQueue<object>
    {
        public object DequeueWorkItem()
        {
            throw new NotImplementedException();
        }

        public void EnqueueWorkItem(object workItem)
        {
            throw new NotImplementedException();
        }
    }
}
