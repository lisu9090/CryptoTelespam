using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Application.Const.Message
{
    internal class NuplEventMessage
    {
        public const string NUPL_STATE_CHANGED = "The state on {0} market turns into {1} (was {2}). The Net Unrealized Profit/Loss value is {3}.";
        public const string LTH_NUPL_STATE_CHANGED = "The state on {0} market turns into {1} (was {2}). The Long Term Holder Net Unrealized Profit/Loss value is {3}.";
        public const string NUPL_NOTIFICATION = "No Net Unrealized Profit/Loss event detected at {0} market. The Net Unrealized Profit/Loss value is {1}.";
        public const string LTH_NUPL_NOTIFICATION = "No Long Term Holder Net Unrealized Profit/Loss event detected at {0} market. The Long Term Holder Net Unrealized Profit/Loss value is {1}.";
    }
}
