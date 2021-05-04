using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Zone.StfDeflectionZone
{
    public class StfDeflectionZoneService
    {
        private readonly IEnumerable<IZoneRange<IndicatorZone<StfDeflection>, StfDeflection, float>> _zoneRanges;

        public StfDeflectionZoneService()
        {
            _zoneRanges = new List<IZoneRange<IndicatorZone<StfDeflection>, StfDeflection, float>>
            {
                new StfDeflectionAcceptableZone.ZoneRange(),
                new StfDeflectionUnacceptableZone.ZoneRange()
            };
        }

        public IndicatorZone<StfDeflection> GetZone(float value)
        {
            IZoneRange<IndicatorZone<StfDeflection>, StfDeflection, float> zoneRange = _zoneRanges
                .Where(range => range.IsInZone(value))
                .FirstOrDefault();

            return new IndicatorZoneActivator()
                .CreateZoneInstance(zoneRange);
        }
    }
}