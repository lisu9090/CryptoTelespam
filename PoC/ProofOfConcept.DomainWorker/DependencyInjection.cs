using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.AbstractDomain;
using ProofOfConcept.Domain.Domain.DataLoad;
using ProofOfConcept.Domain.Model;
using System;

namespace ProofOfConcept.DomainWorker
{
    public static class DependencyInjection
    {
        public static void RegisterDataLoadDomain(this IServiceCollection services)
        {
            services.AddScoped<IDataLoaderService<NuplEntity>, NuplLoaderService>();
        }

        public static void RegisterDataProcessDomain(this IServiceCollection services)
        {

        }

        public static void RegisterMessageSendDomain(this IServiceCollection services)
        {

        }
    }
}
