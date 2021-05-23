using ProofOfConcept.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Service.Zone.Abstract
{
    public interface IZoneSelector
    {
        ZoneId? GetZone(double value);
    }
}