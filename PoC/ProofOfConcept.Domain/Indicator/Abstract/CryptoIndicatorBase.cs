using ProofOfConcept.Domain.Entity;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptoIndicatorBase
    {
        public int AssetId { get; set; }

        public virtual Asset Asset { get; set; }
    }
}