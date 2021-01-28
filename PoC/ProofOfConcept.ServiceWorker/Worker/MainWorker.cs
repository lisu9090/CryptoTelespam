using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Common.Const;
using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Action;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Worker
{
    class MainWorker : BackgroundService
    {
        private readonly ILogger<MainWorker> _logger;
        private readonly IActionDequeuer<IAction> _actionDequeuer;
        private readonly IActionEnqueuer<IAction> _actionEnqueuer;
        private readonly IServiceProvider _serviceProvider;

        public MainWorker(ILogger<MainWorker> logger, 
            IActionDequeuer<IAction> actionDequeuer, 
            IActionEnqueuer<IAction> actionEnqueuer,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _actionDequeuer = actionDequeuer;
            _actionEnqueuer = actionEnqueuer;
            _serviceProvider = serviceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Test();

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_actionDequeuer.HasAction())
                {
                    var work = _actionDequeuer.DequeueAction();

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

        private void Test()
        {
            _actionEnqueuer.EnqueueAction(new FullPipelineAction<Nupl>(
                _serviceProvider.GetRequiredService<IDataLoaderService<Nupl>>(),
                _serviceProvider.GetRequiredService<IDataProcessorService<Nupl>>(),
                _serviceProvider.GetRequiredService<IMessageSenderService<Nupl>>(),
                CryptocurrencySymbol.BTC));
        }
    }
}
