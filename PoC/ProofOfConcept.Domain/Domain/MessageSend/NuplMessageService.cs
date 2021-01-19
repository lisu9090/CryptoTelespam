using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class NuplMessageService : IMessageSenderService<NuplEntity>
    {
        private IMessageApiService _messageApiAdapter;

        public NuplMessageService(IMessageApiService messageApiAdapter)
        {
            _messageApiAdapter = messageApiAdapter;
        }

        public async Task SendEventMessageAsync(NuplEntity data)
        {
            await _messageApiAdapter.SendAsync($"Nupl event detected: Euphoria; Nupl value {data.Value}.");
        }
    }
}
