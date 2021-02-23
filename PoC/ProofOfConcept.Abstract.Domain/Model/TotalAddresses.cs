using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Abstract.Domain.Model
{
    public class TotalAddresses : ScopedIndicatorBase<int>
    {
        public float DailyAverageValue { get; set; }
    }
}
