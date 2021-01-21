using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    internal class NuplEntity : Entity, INupl
    {
        public DateTimeOffset Date { get; set; }
        public float Value { get; set; }
    }
}
