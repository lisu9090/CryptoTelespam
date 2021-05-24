using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.NuplZone
{
    internal class NuplEuphoriaSelector : ZoneSelectorBase, IZoneSelector
    {
        public NuplEuphoriaSelector() : base(Range.And(x => x >= 0.75, x => x <= double.MaxValue), ZoneId.Euphoria)
        {
        }
    }
}