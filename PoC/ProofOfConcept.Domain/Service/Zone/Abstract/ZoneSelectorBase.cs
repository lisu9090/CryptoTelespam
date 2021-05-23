using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;

namespace ProofOfConcept.Domain.Service.Zone.Abstract
{
    internal abstract class ZoneSelectorBase : IZoneSelector
    {
        protected readonly Range _range;
        protected readonly ZoneId _zoneId;

        protected ZoneSelectorBase(Range range, ZoneId zoneId)
        {
            _range = range;
            _zoneId = zoneId;
        }

        public virtual ZoneId? GetZone(double value) => _range.IsInRange(value)
            ? _zoneId
            : (ZoneId?)null;
    }
}