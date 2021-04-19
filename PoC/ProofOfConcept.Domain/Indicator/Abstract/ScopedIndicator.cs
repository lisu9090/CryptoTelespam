namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class ScopedIndicator<T> : CryptocurrencyIndicator
    {
        //TODO Add constructor or factory wchich accept IEnumerable<T>

        public IndicatorValue<T> Current { get; set; }

        public IndicatorValue<T> Previous { get; set; }
    }
}