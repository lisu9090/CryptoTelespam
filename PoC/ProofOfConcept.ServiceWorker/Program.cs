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
using System;

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
                    services.AddTransient<IJob, NuplEthJob>();

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

                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });

                //todo move job & trigger setup to other files

                var nuplKey = new JobKey("nupl-eth", "nupl");
                q.AddJob<NuplEthJob>(j => j
                    .StoreDurably()
                    .WithIdentity(nuplKey)
                    //.WithDescription("my awesome job")
                );

                q.AddTrigger(t => t
                    .WithIdentity("nupl-trigger")
                    .ForJob(nuplKey)
                    .StartNow()
                    .WithSimpleSchedule(x => 
                        x.WithInterval(TimeSpan.FromSeconds(10))
                        .RepeatForever())
                    //.WithDescription("my awesome simple trigger")
                );
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
        }
    }
}
