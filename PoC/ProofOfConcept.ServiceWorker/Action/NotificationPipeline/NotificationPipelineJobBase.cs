using ProofOfConcept.Abstract.Domain.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action.NotificationPipeline
{
    abstract class NotificationPipelineJobBase<T> : IJob where T : CryptocurrencyIndicator
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
