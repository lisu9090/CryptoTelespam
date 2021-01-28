using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class NuplMessageService : IMessageSenderService<Nupl>
    {
        private IMessageApiService _messageApiAdapter;

        public NuplMessageService(IMessageApiService messageApiAdapter)
        {
            _messageApiAdapter = messageApiAdapter;
        }

        public async Task SendEventMessageAsync(Nupl data)
        {
            await _messageApiAdapter.SendAsync($"Nupl event detected: Euphoria; Nupl value {data.Value}.");
        }
    }
}
