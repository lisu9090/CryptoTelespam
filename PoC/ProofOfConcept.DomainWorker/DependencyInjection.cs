using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.Domain.Domain.DataLoad;
using ProofOfConcept.Domain.Model;
using System;

namespace ProofOfConcept.DomainWorker
{
    public class DependencyInjection
    {
        public static void RegisterDataLoadDomain(IServiceCollection services)
        {
            services.AddScoped<IDataLoaderService<NuplEntity>, NuplLoaderService>();
        }

        public static void RegisterDataProcessDomain(IServiceCollection services)
        {

        }

        public static void RegisterMessageSendDomain(IServiceCollection services)
        {

        }
    }
}
