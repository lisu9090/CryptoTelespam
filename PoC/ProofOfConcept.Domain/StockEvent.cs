using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain
{
    public class StockEvent<T> where T : CryptocurrencyIndicator
    {
        public StockEvent(T indicator, string code)
        {
            Indicator = indicator;
            Code = code;
            AdditionalData = new List<object>();
        }

        public StockEvent(T indicator, string code, params object[] data)
        {
            Indicator = indicator;
            Code = code;
            AdditionalData = new List<object>(data);
        }

        public T Indicator { get; private set; }
        public string Code { get; private set; }
        public IEnumerable<object> AdditionalData { get; private set; }
    }
}
