using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProofOfConcept.ApiClientDomain;
using ProofOfConcept.Domain.DI;
using ProofOfConcept.DomainWorker;
using ProofOfConcept.ServiceWorker.Configuration;
using Quartz;
using Serilog;

namespace ProofOfConcept.ServiceWorker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostContext, loggerConfig) => loggerConfig.ReadFrom.Configuration(hostContext.Configuration))
            .ConfigureServices((hostContext, services) =>
                {
                    services.RegisterServiceWorker(hostContext.Configuration);

                    services.RegisterDomain();

                    services.RegisterApplication();

                    services.RegisterApiClients(hostContext.Configuration);
                });

        private static void RegisterServiceWorker(this IServiceCollection services, IConfiguration config)
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