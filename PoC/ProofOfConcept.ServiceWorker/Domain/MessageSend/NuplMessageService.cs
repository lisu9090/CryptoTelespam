using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Domain.MessageSend
{
    class NuplMessageService : IMessageSenderService<NuplEntity>
    {
        public Task SendEventMessageAsync(NuplEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
