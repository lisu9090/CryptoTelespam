using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.StfDeflectionZone
{
    internal class StfDeflectionAcceptableSelector : ZoneSelectorBase, IZoneSelector
    {
        public StfDeflectionAcceptableSelector() : base(Range.And(x => x >= double.MinValue, x => x <= 0), ZoneId.Accptable)
        {
        }
    }
}