﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Abstract
{
    public interface IMessageApiAdapter
    {
        Task SendAsync(string msg);
    }
}
