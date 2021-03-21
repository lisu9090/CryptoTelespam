using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Const.Message
{
    internal class PuellEventMessage
    {
        public const string PUELL_BUY_ENTER = "The Puell Multiple at {0} market has enter buy zone. Indicator value is {1}";
        public const string PUELL_BUY_ESCAPE = "The Puell Multiple at {0} market has escape buy zone. Indicator value is {1}";
        public const string PUELL_SELL_ENTER = "The Puell Multiple at {0} market has enter sell zone. Indicator value is {1}";
        public const string PUELL_SELL_ESCAPE = "The Puell Multiple at {0} market has escape sell zone. Indicator value is {1}";
        public const string PUELL_NOTIFICATION = "No Puell Multiple event detected at {0} market. The Puell Multiple value is {1}.";
    }
}
