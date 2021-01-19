using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain.Model
{
    public class NuplEntity : Entity
    {
        public DateTimeOffset Date { get; set; }
        public float Value { get; set; }
    }
}
