﻿using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Message;
using ProofOfConcept.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.MessageSend
{
    public class LthNuplMessageService : IMessageSenderService<LthNupl>
    {
        private readonly IMessageApiService _messageApiService;

        public LthNuplMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }

        public async Task SendEventMessageAsync(StockEvent<LthNupl> data)
        {
            if (data == null)
            {
                return;
            }

            var msg = string.Format(NuplEventMessage.LTH_NUPL_STATE_CHANGED,
                data.Indicator.CryptocurrencySymbol,
                data.Code,
                data.AdditionalData.FirstOrDefault(),
                data.Indicator.Value);

            await _messageApiService.SendAsync(msg);
        }

        public async Task SendNotificationAsync(LthNupl notification)
        {
            string msg = string.Format(NuplEventMessage.LTH_NUPL_NOTIFICATION,
                notification.CryptocurrencySymbol,
                notification.Value);

            await _messageApiService.SendAsync(msg);
        }
    }
}