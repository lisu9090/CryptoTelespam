using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Entity.Enum;
using ProofOfConcept.Domain.Enum;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service
{
    public class StockEventPipeline : IStockEventPipeline
    {
        public async Task ExecutePipelineAsync(IndicatorId indicatorId, AssetId assetId)
        {
            //TODO Select service implementation based on indicatorId, pass assetId eo pipeline

            T data = await _dataLoaderService.LoadDataAsync(cryptocurrencySymbol);
            ZoneChageEvent<T> stockEvent = _dataProcessorService.DetectEvent(data);

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