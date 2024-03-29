﻿using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Message;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class StfDeflectionMessageService : IMessageSenderService<StfDeflection>
    {
        private IMessageApiService _messageApiService;

        public StfDeflectionMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(StockEvent<StfDeflection> data)
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
