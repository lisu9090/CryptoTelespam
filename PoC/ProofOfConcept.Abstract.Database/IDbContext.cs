using ProofOfConcept.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Database
{
    public interface IDbContext
    {
        IQueryable<Asset> Asset { get; set; }

        IQueryable<StockEventMessageTemplate> StockEventMessageTemplate { get; set; }

        Task<bool> SaveChangesAsync();
    }
}