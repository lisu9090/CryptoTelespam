using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Const.Message
{
    internal class NuplEventMessage
    {
        public const string NUPL_STATE_CHANGED = "Event detected: {0}; net unrealized profit/loss value {1} ({2}).";
    }
}
