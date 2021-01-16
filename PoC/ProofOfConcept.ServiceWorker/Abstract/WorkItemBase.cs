using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    class WorkItemBase<T> where T : class
    {
        public string Key { get; set; }
        public DateTimeOffset Offset { get; set; }
        public T Payload { get; set; }
    }
}
