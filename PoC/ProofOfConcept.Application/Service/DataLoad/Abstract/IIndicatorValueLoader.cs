using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.ValueObject;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.DataLoad.Abstract
{
    public interface IIndicatorValueLoader<T>
    {
        Task<IndicatorValueCollection<T>> LoadAsync(AssetId assetId, int resolution);
    }
}