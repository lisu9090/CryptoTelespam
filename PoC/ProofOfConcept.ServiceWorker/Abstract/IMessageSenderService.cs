﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IMessageSenderService<T>
    {
        void SendEventMessage(T data);
    }
}
