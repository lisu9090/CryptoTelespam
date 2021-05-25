using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.ValueObject;
using System.Threading;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service
{
    public class StockEventPipeline : IStockEventPipeline
    {
        private readonly IDataLoaderService _dataLoaderService;
        private readonly IDataProcessorService _dataProcessorService;
        private readonly IMessageSenderService _messageSenderService;

        public StockEventPipeline(
            IDataLoaderService dataLoaderService,
            IDataProcessorService dataProcessorService,
            IMessageSenderService messageSenderService)
        {
            _dataLoaderService = dataLoaderService;
            _dataProcessorService = dataProcessorService;
            _messageSenderService = messageSenderService;
        }

        public async Task ExecutePipelineAsync(IndicatorId indicatorId, AssetId assetId, CancellationToken cancellationToken)
        {
            //TODO Select service implementation based on indicatorId, pass assetId eo pipeline

            IndicatorValueCollection<float> data = await _dataLoaderService.LoadDataAsync(assetId);
            ZoneChangeEvent<float> stockEvent = _dataProcessorService.DetectEvent(data);

            if (stockEvent != null)
            {
                await _messageSenderService.SendEventMessageAsync(stockEvent);
            }
            else
            {
                await _messageSenderService.SendNotificationAsync(data);
            }
        }
    }
}