using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Message;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class NewAddressesMessageService : IMessageSenderService<NewAddresses>
    {
        private IMessageApiService _messageApiService;

        public NewAddressesMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(StockEvent<NewAddresses> data)
        {
            if (data == null)
            {
                return;
            }
            
            var msg = string.Format(NuplEventMessage.NUPL_STATE_CHANGED,
                data.Code,
                data.Indicator.Value,
                data.Indicator.CryptocurrencySymbol);

            await _messageApiService.SendAsync(msg);
        }
    }
}
