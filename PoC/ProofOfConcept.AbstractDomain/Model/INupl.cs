using System;

namespace ProofOfConcept.AbstractDomain.Model
{
    public interface INupl
    {
        DateTimeOffset Date { get; set; }
        float Value { get; set; }
    }
}
