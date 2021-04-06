using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Application.Const.Message
{
    internal class MarketCapEventMessage
    {
        public const string MARKET_CAP_STATE_CHANGED = "The price on {0} market turns into {1} (was {2}). The Market Cap to Thermocap Ratio value is {3}.";
        public const string MARKET_CAP_NOTIFICATION = "No Market Cap to Thermocap Ratio event detected at {0} market. The Market Cap to Thermocap Ratio value is {1}.";
    }
}
