using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using ProofOfConcept.ApiClientDomain;
using ProofOfConcept.Domain.Domain.DataLoad;
using ProofOfConcept.Domain.Domain.DataProcess;
using ProofOfConcept.Domain.Domain.MessageSend;

namespace ProofOfConcept.DomainWorker
{
    public static class DependencyInjection
    {
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.RegisterDataLoadServices();
            services.RegisterDataProcessServices();
            services.RegisterMessageSendServices();

            services.AddAutoMapper(typeof(ApiClientToDomainProfile));
        }

        private static void RegisterDataLoadServices(this IServiceCollection services)
        {
            services.AddTransient<IDataLoaderService<INupl>, NuplLoaderService>();
        }

        private static void RegisterDataProcessServices(this IServiceCollection services)
        {
            services.AddTransient<IDataProcessorService<INupl>, NuplEventDetectorService>();
        }

        private static void RegisterMessageSendServices(this IServiceCollection services)
        {
            services.AddTransient<IMessageSenderService<INupl>, NuplMessageService>();
        }
    }
}
