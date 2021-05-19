using LiteDB;
using ProofOfConcept.Abstract.Database.Domain;
using ProofOfConcept.Database.Abstract;
using ProofOfConcept.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Database.Repository
{
    public class ZoneRepository : CryptoEntityRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(LiteDatabase context) : base(context)
        {
        }
    }
}