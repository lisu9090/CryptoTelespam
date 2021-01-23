using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.AbstractApiClient.Dto
{
    public interface IActiveAddressesDto
    {
        long T { get; set; }
        int V { get; set; }
    }
}
