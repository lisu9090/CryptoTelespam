using ProofOfConcept.ServiceWorker.Abstract;
using System;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class DataAnalysisWorkItemQueue : IWorkItemEnqueuer<object>, IWorkItemDequeuer<object>
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
