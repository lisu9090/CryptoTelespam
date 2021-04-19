using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend
{
    public class NuplMessageService : IMessageSenderService<Nupl>
    {
        private readonly IMessageApiService _messageApiService;

        public NuplMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(ZoneChageEvent<Nupl> data)
        {
            if (data == null)
            {
                return;
            }

            var msg = string.Format(NuplEventMessage.NUPL_STATE_CHANGED,
                data.Indicator.CryptocurrencySymbol,
                data.Code,
                data.AdditionalData.FirstOrDefault(),
                data.Indicator.Value);

            await _messageApiService.SendAsync(msg);
        }

        public async Task SendNotificationAsync(Nupl notification)
        {
            string msg = string.Format(NuplEventMessage.NUPL_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}