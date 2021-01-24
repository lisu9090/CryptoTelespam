using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    internal class MarketCapThermocapRatioEntity : DateEntity, IMarketCapThermocapRatio
    {
        public float Value { get; set; }
    }
}
