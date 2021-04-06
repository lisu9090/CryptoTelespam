using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend
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