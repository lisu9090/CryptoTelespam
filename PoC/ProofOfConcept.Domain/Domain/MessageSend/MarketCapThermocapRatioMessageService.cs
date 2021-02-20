using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Message;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class MarketCapThermocapRatioMessageService : IMessageSenderService<MarketCapThermocapRatio>
    {
        private IMessageApiService _messageApiService;

        public MarketCapThermocapRatioMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(StockEvent<MarketCapThermocapRatio> data)
        {
            if (data == null)
            {
                return;
            }

            var msg = string.Format(MarketCapEventMessage.MARKET_CAP_STATE_CHANGED,
                data.Indicator.CryptocurrencySymbol,
                data.Code,
                data.AdditionalData.FirstOrDefault(),
                data.Indicator.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}
