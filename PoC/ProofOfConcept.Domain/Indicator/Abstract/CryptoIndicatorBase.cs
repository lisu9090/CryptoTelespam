using ProofOfConcept.Domain.Entity;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptoIndicatorBase
    {
        public Asset Asset { get; set; } //TODO consider change to AssetId
    }
}