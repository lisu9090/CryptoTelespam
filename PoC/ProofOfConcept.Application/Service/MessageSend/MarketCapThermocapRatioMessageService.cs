using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Application.Service.MessageSend.Abstract;
using ProofOfConcept.Domain.ValueObject;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend
{
    public class MarketCapThermocapRatioMessageService : IMessageSender<float>
    {
        private readonly IMessageApiService _messageApiService;

        public MarketCapThermocapRatioMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(ZoneChageEvent<MarketCapThermocapRatio> data)
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

        public Task SendEventMessageAsync(ZoneChangeEvent<float> zoneChangeEvent)
        {
            throw new System.NotImplementedException();
        }

        public async Task SendNotificationAsync(MarketCapThermocapRatio notification)
        {
            string msg = string.Format(MarketCapEventMessage.MARKET_CAP_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }

        public Task SendNotificationAsync(IndicatorValueCollection<float> indicatorValues)
        {
            throw new System.NotImplementedException();
        }
    }
}