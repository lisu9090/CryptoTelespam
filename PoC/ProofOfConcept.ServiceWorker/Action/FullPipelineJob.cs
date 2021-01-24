﻿using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using Quartz;
using System;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action
{
    class FullPipelineJob<T> : IJob where T : ICryptocurrencyIndicator
    {
        protected readonly IDataLoaderService<T> _dataLoaderService;
        protected readonly IDataProcessorService<T> _dataProcessorService;
        protected readonly IMessageSenderService<T> _messageSenderService;
        private readonly string _cryptocurrencySymbol;

        public FullPipelineJob(IDataLoaderService<T> dataLoaderService,
            IDataProcessorService<T> dataProcessorService,
            IMessageSenderService<T> messageSenderService,
            string cryptocurrencySymbol)
        {
            _dataLoaderService = dataLoaderService;
            _dataProcessorService = dataProcessorService;
            _messageSenderService = messageSenderService;
            _cryptocurrencySymbol = cryptocurrencySymbol;
        }

        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}