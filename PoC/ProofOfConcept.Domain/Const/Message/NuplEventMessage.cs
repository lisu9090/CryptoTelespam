using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Const.Message
{
    internal class NuplEventMessage
    {
        public const string NUPL_STATE_CHANGED = " The state on {0} market turns into {1} (was {2}). The Net Unrealized Profit/Loss value is {3}.";
    }
}
