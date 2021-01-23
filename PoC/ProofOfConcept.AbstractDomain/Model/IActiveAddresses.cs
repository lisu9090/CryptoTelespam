using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.AbstractDomain.Model
{
    public interface IActiveAddresses : ICryptocurrencyIndicator
    {
        DateTimeOffset Date { get; set; }
        int Value { get; set; }
    }
}
