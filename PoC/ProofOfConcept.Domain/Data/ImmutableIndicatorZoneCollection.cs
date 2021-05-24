using ProofOfConcept.Domain.Entity.Relation;
using ProofOfConcept.Domain.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Data
{
    public class ImmutableIndicatorZoneCollection : IEnumerable<IndicatorZone>
    {
        private class ClonableIndicatorZone : IndicatorZone, ICloneable
        {
            public object Clone() => MemberwiseClone();
        }

        private List<ClonableIndicatorZone> _indicatorZones;

        public ImmutableIndicatorZoneCollection()
        {
            _indicatorZones = new List<ClonableIndicatorZone>
            {
                new ClonableIndicatorZone
                {
                    IndicatorId = (int)IndicatorId.StfDeflaction,
                    ZoneId = (int)ZoneId.Accptable
                },
                new ClonableIndicatorZone
                {
                    IndicatorId = (int)IndicatorId.StfDeflaction,
                    ZoneId = (int)ZoneId.Unacceptable
                }
            };

            var indicators = new List<IndicatorId>
            {
                IndicatorId.LthNupl,
                IndicatorId.MarketCapThermocapRatio,
                IndicatorId.MvrvZScore,
                IndicatorId.Nupl,
                IndicatorId.Puell,
            };

            var zones = new List<ZoneId>
            {
                ZoneId.Beliefe,
                ZoneId.Capitulation,
                ZoneId.Euphoria,
                ZoneId.Hope,
                ZoneId.Optimism,
            };

            _indicatorZones.AddRange(
                from indicator in indicators
                from zone in zones
                select new ClonableIndicatorZone
                {
                    IndicatorId = (int)indicator,
                    ZoneId = (int)zone
                });
        }

        public IEnumerator<IndicatorZone> GetEnumerator() => _indicatorZones
            .Select(indicatorZone => (IndicatorZone)indicatorZone.Clone())
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}