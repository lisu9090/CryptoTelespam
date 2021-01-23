using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    class NewAddressesEntity : Entity, INewAddresses
    {
        public DateTimeOffset Date { get; set; }
        public int Value { get; set; }
    }
}
