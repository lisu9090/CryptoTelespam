using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.AbstractDomain.Model
{
    public interface ICryptocurrencyIndicator
    {
        string CryptocurrencySymbol { get; set; }
    }
}
