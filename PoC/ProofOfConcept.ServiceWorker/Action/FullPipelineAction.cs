using ProofOfConcept.AbstractDomain;
using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action
{
    class FullPipelineAction<T> : IAction
    {
        protected IDataLoaderService<T> _dataLoaderService;
        protected IDataProcessorService<T> _dataProcessorService;
        protected IMessageSenderService<T> _messageSenderService;

        public FullPipelineAction(IDataLoaderService<T> dataLoaderService, 
            IDataProcessorService<T> dataProcessorService, 
            IMessageSenderService<T> messageSenderService)
        {
            _dataLoaderService = dataLoaderService;
            _dataProcessorService = dataProcessorService;
            _messageSenderService = messageSenderService;
        }

        public virtual async Task ExecuteAsync()
        {
            var data = await _dataLoaderService.LoadDataAsync();

            if(await _dataProcessorService.DetectEventAsync(data))
            {
               await _messageSenderService.SendEventMessageAsync(data);
            }
        }
    }
}
