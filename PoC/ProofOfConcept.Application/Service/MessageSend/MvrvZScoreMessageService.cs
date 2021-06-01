using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Application.Const.Code;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Application.Service.MessageSend.Abstract;
using ProofOfConcept.Domain.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend
{
    public class MvrvZScoreMessageService : IMessageSender<float>
    {
        private readonly IMessageApiService _messageApiService;
        private Dictionary<string, string> _codeMessageDictionary = new Dictionary<string, string>();

        public MvrvZScoreMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;

            _codeMessageDictionary.Add(PuellEventCode.ENTER_BUY_ZONE, PuellEventMessage.PUELL_BUY_ENTER);
            _codeMessageDictionary.Add(PuellEventCode.ESCAPE_BUY_ZONE, PuellEventMessage.PUELL_BUY_ESCAPE);
            _codeMessageDictionary.Add(PuellEventCode.ENTER_SELL_ZONE, PuellEventMessage.PUELL_SELL_ENTER);
            _codeMessageDictionary.Add(PuellEventCode.ESCAPE_SELL_ZONE, PuellEventMessage.PUELL_SELL_ESCAPE);
        }

        public async Task SendEventMessageAsync(ZoneChageEvent<Puell> data)
        {
            if (data == null)
            {
                return;
            }

            var msg = string.Format(_codeMessageDictionary[data.Code],
                data.Indicator.CryptocurrencySymbol,
                data.Indicator.Value);

            await _messageApiService.SendAsync(msg);
        }

        public Task SendEventMessageAsync(ZoneChageEvent<MvrvZScore> data)
        {
            throw new System.NotImplementedException();
        }

        public Task SendEventMessageAsync(ZoneChangeEvent<float> zoneChangeEvent)
        {
            throw new System.NotImplementedException();
        }

        public async Task SendNotificationAsync(Puell notification)
        {
            string msg = string.Format(PuellEventMessage.PUELL_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }

        public Task SendNotificationAsync(MvrvZScore notification)
        {
            throw new System.NotImplementedException();
        }

        public Task SendNotificationAsync(IndicatorValueCollection<float> indicatorValues)
        {
            throw new System.NotImplementedException();
        }
    }
}