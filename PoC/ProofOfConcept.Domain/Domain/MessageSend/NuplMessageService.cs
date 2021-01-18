using ProofOfConcept.AbstractDomain;
using ProofOfConcept.Domain.Abstract;
using ProofOfConcept.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
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
