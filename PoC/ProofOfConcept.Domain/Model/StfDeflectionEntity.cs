using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    internal class StfDeflectionEntity : DateEntity, IStfDeflection
    {
        public float Value { get; set; }
    }
}
