using ProofOfConcept.AbstractApiClient.Dto;

namespace ProofOfConcept.ApiClient.Dto
{
    class NuplDto : INuplDto
    {
        public long T { get; set; }
        public float V { get; set; }
    }
}
