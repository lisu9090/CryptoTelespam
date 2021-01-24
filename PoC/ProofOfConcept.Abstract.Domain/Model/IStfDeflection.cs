using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.AbstractDomain.Model
{
    public interface IStfDeflection : ICryptocurrencyIndicator
    {
        float Value { get; set; }
    }
}
