using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.AbstractApiClient.Dto
{
    public interface IIntValueTimestampDto : ITimestampDto
    {
        int V { get; set; }
    }
}
