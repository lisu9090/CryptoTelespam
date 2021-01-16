using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class DataAnalysisWorkItemQueue : IWorkItemEnqueuer<object>, IWorkItemDequeuer<object>
    {
        //private List<WorkItemBase<object>> test = new List<WorkItemBase<object>>();

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
