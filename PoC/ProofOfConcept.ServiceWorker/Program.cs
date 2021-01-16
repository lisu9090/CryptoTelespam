using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProofOfConcept.ServiceWorker.Abstract;
using ProofOfConcept.ServiceWorker.Domain.DataLoad;
using ProofOfConcept.ServiceWorker.Helpers;
using ProofOfConcept.ServiceWorker.Worker;

namespace ProofOfConcept.ServiceWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MainWorker>();
                    services.AddHttpClient<IRestApiAdapter, GnApiAdapter>();

                    RegisterDataLoadDomain(services);
                    RegisterDataProcessDomain(services);
                    RegisterMessageSendDomain(services);
                });

        private static void RegisterDataLoadDomain(IServiceCollection services)
        {
            services.AddScoped<IDataLoaderService, NuplLoaderService>();
        }

        private static void RegisterDataProcessDomain(IServiceCollection services)
        {

        }

        private static void RegisterMessageSendDomain(IServiceCollection services)
        {

        }
    }

}
