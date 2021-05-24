using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MvrvZScoreZone
{
    internal class MvrvZScoreHopeSelector : ZoneSelectorBase, IZoneSelector
    {
        public MvrvZScoreHopeSelector() : base(Range.And(x => x >= 0.0, x => x < 2.5), ZoneId.Hope)
        {
        }
    }
}