using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Application.Service.MessageSend.Abstract;
using System;

namespace ProofOfConcept.Application.DI
{
    internal class MessageSenderFactory : MessageSenderFactoryBase
    {
        private IServiceProvider _serviceProvider;

        public MessageSenderFactory(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
        }

        protected override IMessageSender<TValue> GetService<TImplementation, TValue>() =>
            _serviceProvider.GetService<TImplementation>();
    }
}