using System;

namespace ProofOfConcept.AbstractDomain.Model
{
    public class NuplEntity : Entity
    {
        public DateTimeOffset Date { get; set; }
        public float Value { get; set; }
    }
}
