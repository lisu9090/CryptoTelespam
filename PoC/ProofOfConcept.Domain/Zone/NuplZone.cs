using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone
{
    public class NuplZone : IndicatorZone<Nupl, float>
    {
        public override string Name => "Test1";

        public override bool IsInZone(IndicatorValue<float> value)
        {
            throw new System.NotImplementedException();
        }
    }
}