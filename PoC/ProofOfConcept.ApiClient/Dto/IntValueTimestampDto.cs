using ProofOfConcept.AbstractApiClient.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.ApiClient.Dto
{
    class IntValueTimestampDto : TimestampDto, IIntValueTimestampDto
    {
        public int V { get; set; }
    }
}
