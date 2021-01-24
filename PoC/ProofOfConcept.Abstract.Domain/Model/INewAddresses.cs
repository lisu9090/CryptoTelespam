using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.AbstractDomain.Model
{
    public interface INewAddresses : ICryptocurrencyIndicator
    {
        DateTimeOffset Date { get; set; }
        int Value { get; set; }
    }
}
