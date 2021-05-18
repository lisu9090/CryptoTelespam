using ProofOfConcept.Abstract.Database;
using ProofOfConcept.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Database
{
    public class IndicatorRepository : IIndicatorRepository
    {
        public Task<IEnumerable<Indicator>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Indicator> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Indicator>> GetByIdsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}