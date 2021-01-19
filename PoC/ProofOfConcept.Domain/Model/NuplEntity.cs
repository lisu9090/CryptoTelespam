using System;

namespace ProofOfConcept.Domain.Model
{
    public class NuplEntity : Entity
    {
        public DateTimeOffset Date { get; set; }
        public float Value { get; set; }
    }
}
