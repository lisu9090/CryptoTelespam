using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Indicator.Enum;

namespace ProofOfConcept.Domain.Indicator
{
    public class ActiveAddresses : CryptocurrencyIndicator<int>
    {
        public override int Id { get => (int)IndicatorId.ActiveAddresses; }
    }
}