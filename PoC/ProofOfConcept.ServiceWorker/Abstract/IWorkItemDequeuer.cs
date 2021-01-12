using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IWorkItemDequeuer<out T> // where T : base for work items
    {
        T DequeueWorkItem();
    }
}
