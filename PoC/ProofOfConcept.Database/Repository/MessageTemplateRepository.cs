using LiteDB;
using ProofOfConcept.Abstract.Database;
using ProofOfConcept.Database.Abstract;
using ProofOfConcept.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Database.Repository
{
    public class MessageTemplateRepository : CryptoEntityRepository<MessageTemplate>, IMessageTemplateRepository
    {
        public MessageTemplateRepository(LiteDatabase context) : base(context)
        {
        }
    }
}