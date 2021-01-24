using System;

namespace ProofOfConcept.AbstractDomain.Model
{
    public interface INupl : ICryptocurrencyIndicator
    {
        DateTimeOffset Date { get; set; }
        float Value { get; set; }
    }
}
