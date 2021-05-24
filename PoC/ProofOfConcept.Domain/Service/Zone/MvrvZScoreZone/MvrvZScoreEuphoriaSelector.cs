using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MvrvZScoreZone
{
    internal class MvrvZScoreEuphoriaSelector : ZoneSelectorBase, IZoneSelector
    {
        public MvrvZScoreEuphoriaSelector() : base(Range.And(x => x >= 7.0, x => x <= double.MaxValue), ZoneId.Euphoria)
        {
        }
    }
}