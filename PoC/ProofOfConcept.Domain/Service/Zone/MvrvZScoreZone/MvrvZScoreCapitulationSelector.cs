using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MvrvZScoreZone
{
    internal class MvrvZScoreCapitulationSelector : ZoneSelectorBase, IZoneSelector
    {
        public MvrvZScoreCapitulationSelector() : base(Range.And(x => x >= double.MinValue, x => x < 0.0), ZoneId.Capitulation)
        {
        }
    }
}