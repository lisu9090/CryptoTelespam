using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend
{
    public class TotalAddressesMessageService : IMessageSenderService<TotalAddresses>
    {
        private readonly IMessageApiService _messageApiService;

        public TotalAddressesMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(ZoneChageEvent<TotalAddresses> data)
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

        public async Task SendNotificationAsync(TotalAddresses notification)
        {
            string msg = string.Format(AddressesEventMessage.TOTAL_ADDRESSES_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}