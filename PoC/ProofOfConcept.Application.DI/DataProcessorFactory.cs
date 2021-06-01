using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Application.Service.DataProcess.Abstract;
using System;

namespace ProofOfConcept.Application.DI
{
    internal class DataProcessorFactory : DataProcessorFactoryBase
    {
        private IServiceProvider _serviceProvider;

        public DataProcessorFactory(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
        }

        protected override IDataProcessor<TValue> GetService<TImplementation, TValue>() =>
            _serviceProvider.GetService<TImplementation>();
    }
}