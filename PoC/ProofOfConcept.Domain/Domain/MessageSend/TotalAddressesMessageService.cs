using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Message;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class TotalAddressesMessageService : IMessageSenderService<TotalAddresses>
    {
        private IMessageApiService _messageApiService;

        public TotalAddressesMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(StockEvent<TotalAddresses> data)
        {
            if (data == null)
            {
                return;
            }
            
            var msg = string.Format(NuplEventMessage.NUPL_STATE_CHANGED, //todo fix
                data.Code,
                data.Indicator.Value,
                data.Indicator.CryptocurrencySymbol);

            await _messageApiService.SendAsync(msg);
        }
    }
}
