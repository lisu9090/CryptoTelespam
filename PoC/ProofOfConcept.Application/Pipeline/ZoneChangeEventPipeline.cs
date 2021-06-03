using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Service.DataLoad.Abstract;
using ProofOfConcept.Application.Service.ZoneChange.Abstract;
using ProofOfConcept.Application.Service.MessageSend.Abstract;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.ValueObject;
using System.Threading;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Pipeline
{
    public class ZoneChangeEventPipeline : IZoneChangeEventPipeline
    {
        private const int DATA_RESOLUTION = 2;
        private readonly IIndicatorValueLoaderFactory<float> _indicatorValueLoaderFactory;
        private readonly ZoneChangeDetectorFactory<float> _zoneChangeDetectorFactory;
        private readonly IMessageSenderFactory<float> _messageSenderFactory;
        private IIndicatorValueLoader<float> _indicatorValueLoaderService;
        private IZoneChangeDetector<float> _zoneChangeDetectorService;
        private IMessageSender<float> _messageSenderService;

        public ZoneChangeEventPipeline(
            IIndicatorValueLoaderFactory<float> indicatorValueLoaderFactory,
            ZoneChangeDetectorFactory<float> dataProcessorFactory,
            IMessageSenderFactory<float> messageSenderFactory)
        {
            _indicatorValueLoaderFactory = indicatorValueLoaderFactory;
            _zoneChangeDetectorFactory = dataProcessorFactory;
            _messageSenderFactory = messageSenderFactory;
        }

        private void SetServices(IndicatorId indicatorId)
        {
            _indicatorValueLoaderService = _indicatorValueLoaderFactory.GetLoader(indicatorId);
            _zoneChangeDetectorService = _zoneChangeDetectorFactory.GetDataProcessor(indicatorId);
            _messageSenderService = _messageSenderFactory.GetMessageSender(indicatorId);
        }

        public async Task ExecutePipelineAsync(IndicatorId indicatorId, AssetId assetId, CancellationToken cancellationToken)
        {
            //todo consider add indicatorId restrictions

            SetServices(indicatorId);

            IndicatorValueCollection<float> data = await _indicatorValueLoaderService.LoadAsync(assetId, DATA_RESOLUTION);
            ZoneChangeEvent<float> zoneChangeEvent = _zoneChangeDetectorService.DetectEvent(data);

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