using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Application.Service.ZoneChange.Abstract;
using System;

namespace ProofOfConcept.Application.DI
{
    internal class DataProcessorFactory : ZoneChangeDetectorFactoryBase
    {
        private IServiceProvider _serviceProvider;

        public DataProcessorFactory(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
        }

        protected override IZoneChangeDetector<TValue> GetService<TImplementation, TValue>() =>
            _serviceProvider.GetService<TImplementation>();
    }
}