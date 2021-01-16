using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class ActionQueue<T> : IActionEnqueuer<T>, IActionDequeuer<T> where T : IAction
    {
        public T DequeueWorkItem()
        {
            throw new NotImplementedException();
        }

        public void EnqueueAction(T workItem)
        {
            throw new NotImplementedException();
        }

        public bool HasAction()
        {
            throw new NotImplementedException();
        }
    }
}
