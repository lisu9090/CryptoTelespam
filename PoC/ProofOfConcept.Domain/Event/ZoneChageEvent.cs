using ProofOfConcept.Domain.Event.Abstract;
using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain
{
    public class ZoneChageEvent<T> : StockEvent<T> where T : CryptocurrencyIndicator
    {
        public object CurrentZone { get; set; }

        public object PreviousZone { get; set; }
    }
}