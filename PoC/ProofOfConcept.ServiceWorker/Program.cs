using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProofOfConcept.ApiClientDomain;
using ProofOfConcept.DomainWorker;
using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Helpers;
using ProofOfConcept.ServiceWorker.Worker;
using Quartz;
using Serilog;

namespace ProofOfConcept.ServiceWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MainWorker>();

                    RegisterServiceWorker(services);

                    services.RegisterDomain();
                    services.RegisterApiClients(hostContext.Configuration);
                })
                .UseSerilog();

        private static void RegisterServiceWorker(IServiceCollection services)
        {
            services.AddSingleton<IActionEnqueuer<IAction>, ActionQueue>();
            services.AddSingleton<IActionDequeuer<IAction>, ActionQueue>();

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory(options =>
                {
                    options.AllowDefaultConstructor = true;
                });
            });
        }
    }
}
