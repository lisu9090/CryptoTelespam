using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MvrvZScoreZone
{
    internal class MvrvZScoreBeliefSelector : ZoneSelectorBase, IZoneSelector
    {
        public MvrvZScoreBeliefSelector() : base(Range.And(x => x >= 4.5, x => x < 7.0), ZoneId.Beliefe)
        {
        }
    }
}