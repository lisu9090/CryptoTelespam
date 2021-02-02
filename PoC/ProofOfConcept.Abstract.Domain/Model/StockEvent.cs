using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Abstract.Domain.Model
{
    public class StockEvent<T> where T : CryptocurrencyIndicator
    {
        public StockEvent(T indicator, string code)
        {
            Indicator = indicator;
            Code = code;
        }

        public T Indicator { get; private set; }
        public string Code { get; private set; }
    }
}
