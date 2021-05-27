using ProofOfConcept.Domain.Enum;
using System.Threading;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IZoneChangeEventPipeline
    {
        Task ExecutePipelineAsync(IndicatorId indicatorId, AssetId assetId, CancellationToken cancellationToken);
    }
}