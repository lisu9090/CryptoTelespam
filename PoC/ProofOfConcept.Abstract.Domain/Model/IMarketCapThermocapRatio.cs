using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.AbstractDomain.Model
{
    public interface IMarketCapThermocapRatio : ICryptocurrencyIndicator
    {
        float Value { get; set; }
    }
}
