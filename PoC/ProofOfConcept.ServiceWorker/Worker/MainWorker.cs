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
        private readonly ILogger<MainWorker> _logger;
        private IActionDequeuer<IAction> _actionQueue;

        public MainWorker(ILogger<MainWorker> logger, IActionDequeuer<IAction> actionQueue)
        {
            _logger = logger;
            _actionQueue = actionQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_actionQueue.HasAction())
                {
                    var work = _actionQueue.DequeueWorkItem();

                    try
                    {
                        await work.ExecuteAsync();
                    }
                    catch(Exception e)
                    {
                        _logger.LogError($"{e.GetType().Name} - {e.Message} - {e.StackTrace}");
                    }
                }
            }
        }
    }
}
