using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Message;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class ActiveAddressesMessageService : IMessageSenderService<ActiveAddresses>
    {
        private IMessageApiService _messageApiService;

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
            
            string msg = string.Format(NuplEventMessage.NUPL_STATE_CHANGED, //todo fix
                data.Code,
                data.Indicator.Value,
                data.Indicator.CryptocurrencySymbol);

            await _messageApiService.SendAsync(msg);
        }

        public Task SendNotificationAsync(ActiveAddresses notification)
        {
            throw new System.NotImplementedException();
        }
    }
}
