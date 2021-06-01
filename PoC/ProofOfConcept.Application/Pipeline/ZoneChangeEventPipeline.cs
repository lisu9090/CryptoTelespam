using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Service.DataLoad.Abstract;
using ProofOfConcept.Application.Service.DataProcess.Abstract;
using ProofOfConcept.Application.Service.MessageSend.Abstract;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.ValueObject;
using System.Threading;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Pipeline
{
    public class ZoneChangeEventPipeline : IZoneChangeEventPipeline
    {
        private readonly IIndicatorValueLoader<float> _dataLoaderService;
        private readonly IDataProcessor _dataProcessorService;
        private readonly IMessageSender _messageSenderService;

        public ZoneChangeEventPipeline(
            IIndicatorValueLoader<float> dataLoaderService,
            IDataProcessor dataProcessorService,
            IMessageSender messageSenderService)
        {
            _dataLoaderService = dataLoaderService;
            _dataProcessorService = dataProcessorService;
            _messageSenderService = messageSenderService;
        }

        public async Task ExecutePipelineAsync(IndicatorId indicatorId, AssetId assetId, CancellationToken cancellationToken)
        {
            //TODO Select service implementation based on indicatorId, pass assetId to pipeline

            IndicatorValueCollection<float> data = await _dataLoaderService.LoadAsync(assetId);
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