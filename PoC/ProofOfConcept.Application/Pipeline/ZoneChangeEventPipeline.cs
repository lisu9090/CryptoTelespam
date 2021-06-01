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
        private readonly IIndicatorValueLoaderFactory<float> _indicatorValueLoaderFactory;
        private readonly IDataProcessorFactory<float> _dataProcessorFactory;
        private readonly IMessageSenderFactory<float> _messageSenderFactory;
        private IIndicatorValueLoader<float> _indicatorValueLoaderService;
        private IDataProcessor<float> _dataProcessorService;
        private IMessageSender<float> _messageSenderService;

        public ZoneChangeEventPipeline(
            IIndicatorValueLoaderFactory<float> indicatorValueLoaderFactory,
            IDataProcessorFactory<float> dataProcessorFactory,
            IMessageSenderFactory<float> messageSenderFactory)
        {
            _indicatorValueLoaderFactory = indicatorValueLoaderFactory;
            _dataProcessorFactory = dataProcessorFactory;
            _messageSenderFactory = messageSenderFactory;
        }

        private void SetServices(IndicatorId indicatorId)
        {
            _indicatorValueLoaderService = _indicatorValueLoaderFactory.GetLoader(indicatorId);
            _dataProcessorService = _dataProcessorFactory.GetDataProcessor(indicatorId);
            _messageSenderService = _messageSenderFactory.GetMessageSender(indicatorId);
        }

        public async Task ExecutePipelineAsync(IndicatorId indicatorId, AssetId assetId, CancellationToken cancellationToken)
        {
            SetServices(indicatorId);

            IndicatorValueCollection<float> data = await _indicatorValueLoaderService.LoadAsync(assetId);
            ZoneChangeEvent<float> zoneChangeEvent = _dataProcessorService.DetectEvent(data);

            if (zoneChangeEvent != null)
            {
                await _messageSenderService.SendEventMessageAsync(zoneChangeEvent);
            }
            else
            {
                await _messageSenderService.SendNotificationAsync(data);
            }
        }
    }
}