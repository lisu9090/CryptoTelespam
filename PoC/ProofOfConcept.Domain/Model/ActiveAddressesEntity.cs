using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    class ActiveAddressesEntity : Entity, IActiveAddresses
    {
        public DateTimeOffset Date { get; set; }
        public int Value { get; set; }
    }
}
