using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Message;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class ActiveAddressesMessageService : IMessageSenderService<ActiveAddresses>
    {
        private readonly IMessageApiService _messageApiService;

        public ActiveAddressesMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(StockEvent<ActiveAddresses> data)
        {
            if (data == null)
            {
                return;
            }
            
            string msg = string.Format("TODO", //TODO fix
                data.Code,
                data.Indicator.Value,
                data.Indicator.CryptocurrencySymbol);

            await _messageApiService.SendAsync(msg);
        }

        public async Task SendNotificationAsync(ActiveAddresses notification)
        {
            string msg = string.Format(AddressesEventMessage.ACTIVE_ADDRESSES_NOTIFICATION,
                notification.CryptocurrencySymbol, 
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}
