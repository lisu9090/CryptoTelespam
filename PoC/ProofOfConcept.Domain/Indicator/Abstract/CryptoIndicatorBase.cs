using ProofOfConcept.Domain.Entity;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptoIndicatorBase
    {
        public CryptoIndicatorBase(int assetId)
        {
            AssetId = assetId;
        }

        public int AssetId { get; }

        public virtual Asset Asset { get; set; }
    }
}