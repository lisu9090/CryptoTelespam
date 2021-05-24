using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MarketCapZone
{
    internal class MarketCapCapitulationSelector : ZoneSelectorBase, IZoneSelector
    {
        public MarketCapCapitulationSelector() : base(Range.And(x => x >= double.MinValue, x => x < 0.00000004), ZoneId.Capitulation)
        {
        }
    }
}