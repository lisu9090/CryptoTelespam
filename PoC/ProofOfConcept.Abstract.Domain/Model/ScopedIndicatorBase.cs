using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Abstract.Application.Model
{
    public abstract class ScopedIndicatorBase<T> : CryptocurrencyIndicator
    {
        public DateTimeOffset Time { get; set; }
        public T Value { get; set; }
        public DateTimeOffset PreviousTime { get; set; }
        public T PreviousValue { get; set; }
    }
}
