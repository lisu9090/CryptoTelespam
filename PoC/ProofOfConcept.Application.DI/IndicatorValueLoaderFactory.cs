using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Application.Service.DataLoad.Abstract;
using System;

namespace ProofOfConcept.Application.DI
{
    internal class IndicatorValueLoaderFactory : IndicatorValueLoaderFactoryBase
    {
        private IServiceProvider _serviceProvider;

        public IndicatorValueLoaderFactory(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
        }

        protected override IIndicatorValueLoader<TValue> GetService<TImplementation, TValue>() =>
            _serviceProvider.GetService<TImplementation>();
    }
}