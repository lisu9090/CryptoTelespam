using System;

namespace ProofOfConcept.Domain.ValueObject
{
    public class IndicatorValue<T>
    {
        public DateTimeOffset Time { get; private set; }

        public T Value { get; private set; }
    }
}