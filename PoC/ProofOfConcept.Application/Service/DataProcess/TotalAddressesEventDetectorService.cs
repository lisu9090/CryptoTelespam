﻿using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class TotalAddressesEventDetectorService : IDataProcessorService<TotalAddresses>
    {
        public StockEvent<TotalAddresses> DetectEvent(TotalAddresses data)
        {
            return null; //todo
        }
    }
}