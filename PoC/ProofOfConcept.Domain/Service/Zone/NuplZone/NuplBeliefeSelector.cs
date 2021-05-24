using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.NuplZone
{
    internal class NuplBeliefeSelector : ZoneSelectorBase, IZoneSelector
    {
        public NuplBeliefeSelector() : base(Range.And(x => x >= 0, x => x < 0.25), ZoneId.Beliefe)
        {
        }
    }
}