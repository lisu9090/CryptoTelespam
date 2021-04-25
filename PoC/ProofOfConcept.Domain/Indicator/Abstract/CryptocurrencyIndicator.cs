﻿using ProofOfConcept.Domain.Entity;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptocurrencyIndicator<T> : IndicatorBase
    {
        public IEnumerable<IndicatorValue<T>> Values { get; set; }
    }
}