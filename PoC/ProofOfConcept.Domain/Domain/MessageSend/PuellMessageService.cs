using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Code;
using ProofOfConcept.Domain.Const.Message;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.MessageSend
{
    public class PuellMessageService : IMessageSenderService<Puell>
    {
        private IMessageApiService _messageApiService;
        private Dictionary<string, string> _codeMessageDictionary = new Dictionary<string, string>();

        public PuellMessageService(IMessageApiService messageApiService)
        {
            _messageApiService = messageApiService;

            _codeMessageDictionary.Add(PuellEventCode.ENTER_BUY_ZONE, PuellEventMessage.PUELL_BUY_ENTER);
            _codeMessageDictionary.Add(PuellEventCode.ESCAPE_BUY_ZONE, PuellEventMessage.PUELL_BUY_ESCAPE);
            _codeMessageDictionary.Add(PuellEventCode.ENTER_SELL_ZONE, PuellEventMessage.PUELL_SELL_ENTER);
            _codeMessageDictionary.Add(PuellEventCode.ESCAPE_SELL_ZONE, PuellEventMessage.PUELL_SELL_ESCAPE);
        }

        public async Task SendEventMessageAsync(StockEvent<Puell> data)
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
    }
}
