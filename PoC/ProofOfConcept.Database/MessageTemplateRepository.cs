using ProofOfConcept.Abstract.Database;
using ProofOfConcept.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Database
{
    public class MessageTemplateRepository : IMessageTemplateRepository
    {
        public Task<IEnumerable<MessageTemplate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MessageTemplate> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MessageTemplate>> GetByIdsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}