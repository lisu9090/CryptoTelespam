using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain
{
    public class Asset : Entity
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }
}