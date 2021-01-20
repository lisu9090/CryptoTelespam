using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class ActionQueue : IActionEnqueuer<IAction>, IActionDequeuer<IAction>
    {
        private static Queue<IAction> _queue = new Queue<IAction>();
        private static object _locker = new object();

        public IAction DequeueAction()
        {
            lock (_locker)
            {
                return _queue.Dequeue();
            }
        }

        public void EnqueueAction(IAction workItem)
        {
            lock (_locker)
            {
                _queue.Enqueue(workItem);
            }
        }

        public bool HasAction()
        {
            lock (_locker)
            {
                return _queue.Any();
            }
        }
    }
}
