using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.ServiceWorker.Abstract;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action
{
    class FullPipelineAction<T> : IAction where T : CryptocurrencyIndicator
    {
        protected readonly IDataLoaderService<T> _dataLoaderService;
        protected readonly IDataProcessorService<T> _dataProcessorService;
        protected readonly IMessageSenderService<T> _messageSenderService;
        private readonly string _cryptocurrencySymbol;

        public FullPipelineAction(IDataLoaderService<T> dataLoaderService, 
            IDataProcessorService<T> dataProcessorService, 
            IMessageSenderService<T> messageSenderService,
            string cryptocurrencySymbol)
        {
            _dataLoaderService = dataLoaderService;
            _dataProcessorService = dataProcessorService;
            _messageSenderService = messageSenderService;
            _cryptocurrencySymbol = cryptocurrencySymbol;
        }

        public virtual async Task ExecuteAsync()
        {
            //var data = await _dataLoaderService.LoadDataAsync(_cryptocurrencySymbol);

            //if(await _dataProcessorService.DetectEventAsync(data))
            //{
            //   await _messageSenderService.SendEventMessageAsync(data);
            //}
        }
    }
}
