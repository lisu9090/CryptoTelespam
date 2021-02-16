using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Const.Message
{
    internal class MarketCapEventMessage
    {
        public const string MARKET_CAP_STATE_CHANGED = "The price on {0} market turns into {1} (was {2}). The Market Cap to Thermocap Ratio value is {3}.";
    }
}
