﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Model
{
    class NuplEntity : Entity
    {
        public DateTimeOffset Date { get; set; }
        public float Value { get; set; }
    }
}