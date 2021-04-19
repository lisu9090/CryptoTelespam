namespace ProofOfConcept.Domain.Entity
{
    public class Asset : CryptoEntity
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }
}