using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Database
{
    public interface IDatabaseInitializer
    {
        Task SeedDataAsync();

        Task<bool> EsureInitialized();
    }
}