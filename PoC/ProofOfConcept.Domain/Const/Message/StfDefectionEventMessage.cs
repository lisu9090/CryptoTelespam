using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Const.Message
{
    internal class StfDefectionEventMessage
    {
        public const string STF_STATE_CHANGED = "The price on {0} market turns into {1}. The Stock-to-Flow Deflection value is {2}.";
        public const string STF_NOTIFICATION = "No Stock-to-Flow Deflection event detected at {0} market. The Stock-to-Flow Deflection value is {1}.";
    }
}
