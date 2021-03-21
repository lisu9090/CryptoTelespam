using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProofOfConcept.ApiClientDomain;
using ProofOfConcept.DomainWorker;
using ProofOfConcept.ServiceWorker.Action.EventDetectionPipeline;
using ProofOfConcept.ServiceWorker.Configuration;
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
                    RegisterService(services);

                    RegisterServiceWorker(services, hostContext.Configuration);

                    services.RegisterDomain();
                    
                    services.RegisterApiClients(hostContext.Configuration);
                });

        private static void RegisterService(IServiceCollection services)
        {
            //TODO register services if necessary 
        }

        private static void RegisterServiceWorker(IServiceCollection services, IConfiguration config)
        {
            services.Configure<QuartzOptions>(config.GetSection("Quartz"));

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory(options =>
                {
                    options.AllowDefaultConstructor = true;
                });

                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });

                q.RegisterJobs();

                q.RegisterTriggers(config);
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
        }
    }
}
