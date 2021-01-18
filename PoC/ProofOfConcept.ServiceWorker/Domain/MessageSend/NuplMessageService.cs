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
        private IMessageApiAdapter _messageApiAdapter;

        public NuplMessageService(IMessageApiAdapter messageApiAdapter)
        {
            _messageApiAdapter = messageApiAdapter;
        }

        public async Task SendEventMessageAsync(NuplEntity data)
        {
            await _messageApiAdapter.SendAsync($"Nupl event detected: Euphoria; Nupl value {data.Value}.");
        }
    }
}
