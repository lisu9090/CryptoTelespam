using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Domain.DataLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Worker
{
    class MainWorker : BackgroundService
    {
        private const int REQUEST_OFFSET = 500; //TODO take from config
        private readonly ILogger<MainWorker> _logger;
        private IActionEnqueuer<object> _workItemQueue;
        private ICollection<IRestApiAdapter> _services;

        public MainWorker(ILogger<MainWorker> logger, IActionEnqueuer<object> workItemQueue)
        {
            _logger = logger;
            _workItemQueue = workItemQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach(var service in _services)
                {
                    if (stoppingToken.IsCancellationRequested)
                    {
                        break;
                    }

                    //var data = await service.QueryAsync();

                    //if(data != null)
                    //{
                    //    _workItemQueue.EnqueueWorkItem(data);
                    //}

                    await Task.Delay(REQUEST_OFFSET, stoppingToken);
                }
            }
        }
    }
}
