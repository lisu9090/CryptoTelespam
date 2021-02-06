using ProofOfConcept.Abstract.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Abstract
{
    internal interface INuplLevelChangeDetector
    {
        string Detect(Nupl data);
    }
}
