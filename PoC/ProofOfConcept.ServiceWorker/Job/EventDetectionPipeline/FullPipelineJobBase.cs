using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Extensions;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal abstract class FullPipelineJobBase<T> : IJob where T : CryptoIndicatorBase
    {
        protected const int RETRY_MAX_COUNT = 1;
        protected readonly IDataLoaderService<T> _dataLoaderService;
        protected readonly IDataProcessorService<T> _dataProcessorService;
        protected readonly IMessageSenderService<T> _messageSenderService;
        protected readonly ILogger<FullPipelineJobBase<T>> _logger;
        protected IEnumerable<string> _cryptocurrencySymbols;

        public FullPipelineJobBase(IDataLoaderService<T> dataLoaderService,
            IDataProcessorService<T> dataProcessorService,
            IMessageSenderService<T> messageSenderService,
            ILogger<FullPipelineJobBase<T>> logger)
        {
            _dataLoaderService = dataLoaderService;
            _dataProcessorService = dataProcessorService;
            _messageSenderService = messageSenderService;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            for (int i = 0; i <= RETRY_MAX_COUNT; i++)
            {
                try
                {
                    await ExecutePipeline(context);
                    break;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error at attempt no. {i} - {e}");
                }
            }
        }

        private async Task ExecutePipeline(IJobExecutionContext context)
        {
            if (_cryptocurrencySymbols.IsNullOrEmpty())
            {
                _logger.LogWarning("Cryptocurrncy symbol array of job {0} is null or contains no elements.", typeof(T).Name);

                return;
            }

            foreach (var cryptocurrencySymbol in _cryptocurrencySymbols)
            {
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
}