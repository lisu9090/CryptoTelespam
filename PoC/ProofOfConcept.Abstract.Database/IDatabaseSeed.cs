using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Database
{
    public interface IDatabaseSeed
    {
        Task SeedDataAsync();
    }
}