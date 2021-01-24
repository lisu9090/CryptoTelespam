﻿using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    internal class NuplEntity : DateEntity, INupl
    {
        public float Value { get; set; }
    }
}
