using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Event.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Service.Event
{
    public class LthNuplZoneChangeService : IZoneChangeService
    {
        public MessageTemplateId? GetMessageTemplateId(ZoneId currentZoneId, ZoneId previousZoneId)
        {
            throw new NotImplementedException();
        }
    }
}