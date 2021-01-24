using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Model
{
    class DateEntity : Entity
    {
        public DateTimeOffset Date { get; set; }
    }
}
