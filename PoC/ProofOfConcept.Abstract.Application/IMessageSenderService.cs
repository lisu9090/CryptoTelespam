﻿using ProofOfConcept.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IMessageSenderService<T> where T : CryptocurrencyIndicator
    {
        Task SendEventMessageAsync(ZoneChageEvent<T> data);

        Task SendNotificationAsync(T notification);
    }
}