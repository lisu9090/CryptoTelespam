using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class ActionQueue : IActionEnqueuer<IAction>, IActionDequeuer<IAction>
    {
        public IAction DequeueWorkItem()
        {
            throw new NotImplementedException();
        }

        public void EnqueueWorkItem(IAction workItem)
        {
            throw new NotImplementedException();
        }
    }
}
