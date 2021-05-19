using LiteDB;
using ProofOfConcept.Abstract.Database;
using ProofOfConcept.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Database.Abstract
{
    public abstract class CryptoEntityRepository<T> : ICryptoEntityRepository<T> where T : CryptoEntity
    {
        protected readonly LiteDatabase _context;

        protected CryptoEntityRepository(LiteDatabase context)
        {
            _context = context;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(
                _context.GetCollection<T>()
                    .FindAll());
        }

        public Task<T> GetByIdAsync(int id)
        {
            return Task.FromResult(
                _context.GetCollection<T>()
                    .Find(item => item.Id == id)
                    .SingleOrDefault());
        }

        public Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return Task.FromResult(
                _context.GetCollection<T>()
                    .Find(item => ids.Contains(item.Id)));
        }
    }
}