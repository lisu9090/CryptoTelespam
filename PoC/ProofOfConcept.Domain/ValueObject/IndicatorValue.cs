using System;

namespace ProofOfConcept.Domain.ValueObject
{
    public class IndicatorValue<T>
    {
        public DateTimeOffset Time { get; }

        public T Value { get; }

        public IndicatorValue(DateTimeOffset time, T value)
        {
            Time = time;
            Value = value;
        }
    }
}