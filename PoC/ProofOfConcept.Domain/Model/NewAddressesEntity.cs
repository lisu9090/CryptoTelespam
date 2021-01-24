using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    class NewAddressesEntity : DateEntity, INewAddresses
    {
        public int Value { get; set; }
    }
}
