using System;

namespace ProofOfConcept.Domain.Indicator
{
    public class IndicatorValue<T>
    {
        public DateTimeOffset Time { get; set; }

        public T Value { get; set; }
    }
}