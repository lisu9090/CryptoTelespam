using AutoMapper;
using ProofOfConcept.AbstractApiClient.Dto;
using ProofOfConcept.AbstractDomain.Model;
using System;

namespace ProofOfConcept.ApiClientDomain
{
    public class ApiClientToDomainProfile : Profile
    {
        public ApiClientToDomainProfile()
        {
            CreateMap<INuplDto, INupl>(MemberList.Source)
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V))
                .ForMember(n => n.Date, opt => opt.MapFrom(d => DateTimeOffset.FromUnixTimeMilliseconds(d.T)));

        }
    }
}
