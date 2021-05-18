using LiteDB;
using ProofOfConcept.Domain.Entity;

namespace ProofOfConcept.Database
{
    public class CryptoDbContext
    {
        private LiteDatabase _db;

        public ILiteCollection<Asset> Asset { get => _db.GetCollection<Asset>(); }

        public ILiteCollection<Indicator> Indicator { get => _db.GetCollection<Indicator>(); }

        public ILiteCollection<MessageTemplate> MessageTemplate { get => _db.GetCollection<MessageTemplate>(); }

        public ILiteCollection<Zone> Zone { get => _db.GetCollection<Zone>(); }
    }
}