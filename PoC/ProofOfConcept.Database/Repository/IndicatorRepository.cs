using LiteDB;
using ProofOfConcept.Abstract.Database.Domain;
using ProofOfConcept.Database.Abstract;
using ProofOfConcept.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Database.Repository
{
    public class IndicatorRepository : CryptoEntityRepository<Indicator>, IIndicatorRepository
    {
        public IndicatorRepository(LiteDatabase context) : base(context)
        {
        }
    }
}