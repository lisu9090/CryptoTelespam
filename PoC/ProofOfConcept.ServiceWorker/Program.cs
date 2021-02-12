using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.ApiClientDomain;
using ProofOfConcept.DomainWorker;
using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Action;
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
            .UseSerilog()
            .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IActionEnqueuer<IAction>, ActionQueue>();
                    services.AddSingleton<IActionDequeuer<IAction>, ActionQueue>();
                    services.AddSingleton<IJob, FullPipelineJob<Nupl>>();

                    RegisterServiceWorker(services, hostContext.Configuration);

                    services.RegisterDomain();
                    services.RegisterApiClients(hostContext.Configuration);
                });

        private static void RegisterServiceWorker(IServiceCollection services, IConfiguration config)
        {
            services.Configure<QuartzOptions>(config.GetSection("Quartz"));

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory(options =>
                {
                    options.AllowDefaultConstructor = true;
                });

                //q.UseDefaultThreadPool();

            });
        }
    }
}
