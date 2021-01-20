using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class NuplMessageService : IMessageSenderService<INupl>
    {
        private IMessageApiService _messageApiAdapter;

        public NuplMessageService(IMessageApiService messageApiAdapter)
        {
            _messageApiAdapter = messageApiAdapter;
        }

        public async Task SendEventMessageAsync(INupl data)
        {
            await _messageApiAdapter.SendAsync($"Nupl event detected: Euphoria; Nupl value {data.Value}.");
        }
    }
}
