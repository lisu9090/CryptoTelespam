using ProofOfConcept.Abstract.Database;
using ProofOfConcept.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Database
{
    public class ZoneRepository : IZoneRepository
    {
        public Task<IEnumerable<Zone>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Zone> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zone>> GetByIdsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}