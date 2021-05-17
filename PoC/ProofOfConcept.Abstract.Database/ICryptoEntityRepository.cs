using ProofOfConcept.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Database
{
    internal interface ICryptoEntityRepository<T> where T : CryptoEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);

        Task<IEnumerable<T>> GetAllAsync();
    }
}