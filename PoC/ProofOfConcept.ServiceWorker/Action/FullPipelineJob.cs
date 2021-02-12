using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using Quartz;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action
{
    class FullPipelineJob<T> : IJob where T : CryptocurrencyIndicator
    {
        protected readonly IDataLoaderService<T> _dataLoaderService;
        protected readonly IDataProcessorService<T> _dataProcessorService;
        protected readonly IMessageSenderService<T> _messageSenderService;
        private readonly string _cryptocurrencySymbol;

        public FullPipelineJob(IDataLoaderService<T> dataLoaderService,
            IDataProcessorService<T> dataProcessorService,
            IMessageSenderService<T> messageSenderService,
            string cryptocurrencySymbol)
        {
            _dataLoaderService = dataLoaderService;
            _dataProcessorService = dataProcessorService;
            _messageSenderService = messageSenderService;
            _cryptocurrencySymbol = cryptocurrencySymbol;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var data = await _dataLoaderService.LoadDataAsync(_cryptocurrencySymbol);
            var stockEvent = await _dataProcessorService.DetectEventAsync(data);

            if (stockEvent != null)
            {
                await _messageSenderService.SendEventMessageAsync(stockEvent);
            }
        }
    }
}
