﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain.Model
{
    public abstract class Entity
    {
        public DateTimeOffset CreatedOn { get; set; }
    }
}
