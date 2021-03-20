using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action
{
    abstract class FullPipelineJobBase<T> : IJob where T : CryptocurrencyIndicator
    {
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
            if (_cryptocurrencySymbols == null || _cryptocurrencySymbols.Count() < 1)
            {
                _logger.LogWarning("Cryptocurrncy symbol array of job {0} is null or contains no elements.", typeof(T).Name);
                return;
            }

            foreach (var cryptocurrencySymbol in _cryptocurrencySymbols)
            {
                var data = await _dataLoaderService.LoadDataAsync(cryptocurrencySymbol);
                var stockEvent = _dataProcessorService.DetectEvent(data);
                await _messageSenderService.SendEventMessageAsync(stockEvent);
            }
        }
    }
}
