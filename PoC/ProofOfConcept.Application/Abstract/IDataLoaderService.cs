using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.ValueObject;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataLoaderService
    {
        Task<IndicatorValueCollection<float>> LoadDataAsync(AssetId assetId);
    }
}