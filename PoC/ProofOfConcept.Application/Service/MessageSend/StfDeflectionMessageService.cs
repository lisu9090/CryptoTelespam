using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend
{
    public class StfDeflectionMessageService : IMessageSenderService<StfDeflection>
    {
        private readonly IMessageApiService _messageApiService;

        public StfDeflectionMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(ZoneChageEvent<StfDeflection> data)
        {
            if (data == null)
            {
                return;
            }

            var msg = string.Format(StfDefectionEventMessage.STF_STATE_CHANGED,
                data.Indicator.CryptocurrencySymbol,
                data.Code,
                data.Indicator.Value);

            await _messageApiService.SendAsync(msg);
        }

        public async Task SendNotificationAsync(StfDeflection notification)
        {
            string msg = string.Format(StfDefectionEventMessage.STF_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}