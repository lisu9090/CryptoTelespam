using ProofOfConcept.AbstractApiClient.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.ApiClient.Dto
{
    class TimestampDto : ITimestampDto
    {
        public long T { get; set; }
    }
}
