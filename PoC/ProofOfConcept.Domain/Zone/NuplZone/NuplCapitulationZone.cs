﻿using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplCapitulationZone : IndicatorZone<Nupl>
    {
        internal class ZoneRange : IZoneRange<NuplCapitulationZone, Nupl, float>
        {
            private Range _range = Range.And(x => x >= double.MinValue, x => x < 0);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Capitulation";
    }
}