using ProofOfConcept.AbstractApiClient.Dto;

namespace ProofOfConcept.ApiClient.Dto
{
    class FloatValueTimestampDto : TimestampDto, IFloatValueTimestampDto
    {
        public float V { get; set; }
    }
}
