using ProofOfConcept.AbstractDomain.Model;
using System;

namespace ProofOfConcept.Domain.Model
{
    class TotalAddressesEntity : Entity, ITotalAddresses
    {
        public DateTimeOffset Date { get; set; }
        public int Value { get; set; }
    }
}
