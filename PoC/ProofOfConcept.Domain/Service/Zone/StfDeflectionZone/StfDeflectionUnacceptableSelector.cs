using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.StfDeflectionZone
{
    internal class StfDeflectionUnacceptableSelector : ZoneSelectorBase, IZoneSelector
    {
        public StfDeflectionUnacceptableSelector() : base(Range.And(x => x > 0, x => x <= double.MaxValue), ZoneId.Unacceptable)
        {
        }
    }
}