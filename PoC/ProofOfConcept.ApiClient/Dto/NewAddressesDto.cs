using ProofOfConcept.AbstractApiClient.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.ApiClient.Dto
{
    class NewAddressesDto : INewAddressesDto
    {
        public long T { get; set; }
        public int V { get; set; }
    }
}
