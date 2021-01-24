using ProofOfConcept.AbstractDomain.Model;
using System;

namespace ProofOfConcept.Domain.Model
{
    class TotalAddressesEntity : DateEntity, ITotalAddresses
    {
        public int Value { get; set; }
    }
}
