using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.MessageSend
{
    public class MarketCapThermocapRatioMessageService : IMessageSenderService<MarketCapThermocapRatio>
    {
        private readonly IMessageApiService _messageApiService;

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

        public async Task SendNotificationAsync(MarketCapThermocapRatio notification)
        {
            string msg = string.Format(MarketCapEventMessage.MARKET_CAP_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}