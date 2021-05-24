using ProofOfConcept.Domain.Entity.Enum;
using ProofOfConcept.Domain.Enum;
using System.Threading;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IStockEventPipeline
    {
        Task ExecutePipelineAsync(IndicatorId indicatorId, AssetId assetId, CancellationToken cancellationToken);
    }
}