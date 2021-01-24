using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    internal class LthNuplEntity : DateEntity, ILthNupl
    {
        public float Value { get; set; }
    }
}
