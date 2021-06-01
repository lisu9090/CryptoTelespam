using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Application.Service.MessageSend.Abstract;
using ProofOfConcept.Domain.ValueObject;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend
{
    public class NewAddressesMessageService : IMessageSender<int>
    {
        private readonly IMessageApiService _messageApiService;

        public NewAddressesMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(ZoneChageEvent<NewAddresses> data)
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

        public Task SendEventMessageAsync(ZoneChangeEvent<int> zoneChangeEvent)
        {
            throw new System.NotImplementedException();
        }

        public async Task SendNotificationAsync(NewAddresses notification)
        {
            string msg = string.Format(AddressesEventMessage.NEW_ADDRESSES_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }

        public Task SendNotificationAsync(IndicatorValueCollection<int> indicatorValues)
        {
            throw new System.NotImplementedException();
        }
    }
}