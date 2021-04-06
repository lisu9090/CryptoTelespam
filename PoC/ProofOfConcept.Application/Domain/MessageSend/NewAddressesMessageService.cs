using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.MessageSend
{
    public class NewAddressesMessageService : IMessageSenderService<NewAddresses>
    {
        private readonly IMessageApiService _messageApiService;

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

            var msg = string.Format("TODO", //TODO fix
                data.Code,
                data.Indicator.Value,
                data.Indicator.CryptocurrencySymbol);

            await _messageApiService.SendAsync(msg);
        }

        public async Task SendNotificationAsync(NewAddresses notification)
        {
            string msg = string.Format(AddressesEventMessage.NEW_ADDRESSES_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}