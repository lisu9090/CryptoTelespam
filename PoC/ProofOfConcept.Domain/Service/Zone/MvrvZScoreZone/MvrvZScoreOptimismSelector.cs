using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MvrvZScoreZone
{
    internal class MvrvZScoreOptimismSelector : ZoneSelectorBase, IZoneSelector
    {
        public MvrvZScoreOptimismSelector() : base(Range.And(x => x >= 2.5, x => x < 4.5), ZoneId.Optimism)
        {
        }
    }
}