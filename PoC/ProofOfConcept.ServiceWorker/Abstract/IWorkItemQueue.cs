using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IWorkItemQueue<T> // where T : base for work items
    {
        void EnqueueWorkItem(T workItem);
        T DequeueWorkItem();
    }
}
