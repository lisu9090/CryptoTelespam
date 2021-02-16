using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Message;
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
                data.Code, //todo add previos state
                data.Indicator.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}
