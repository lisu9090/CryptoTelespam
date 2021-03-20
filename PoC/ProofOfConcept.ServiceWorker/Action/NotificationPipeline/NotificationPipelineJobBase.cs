using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action.NotificationPipeline
{
    abstract class NotificationPipelineJobBase<T> : IJob where T : CryptocurrencyIndicator
    {
        protected readonly IDataLoaderService<T> _dataLoaderService;
        protected readonly IMessageSenderService<T> _messageSenderService;
        protected readonly ILogger<NotificationPipelineJobBase<T>> _logger;
        protected IEnumerable<string> _cryptocurrencySymbols;


        public async Task Execute(IJobExecutionContext context)
        {
            if (_cryptocurrencySymbols == null || _cryptocurrencySymbols.Count() < 1)
            {
                _logger.LogWarning("Cryptocurrncy symbol array of job {0} is null or contains no elements.", typeof(T).Name);
                return;
            }

            foreach (var cryptocurrencySymbol in _cryptocurrencySymbols)
            {
                T data = await _dataLoaderService.LoadDataAsync(cryptocurrencySymbol);
                await _messageSenderService.SendNotificationAsync(data);
            }
        }
    }
}
