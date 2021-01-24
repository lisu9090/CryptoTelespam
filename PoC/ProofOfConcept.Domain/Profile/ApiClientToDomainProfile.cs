using AutoMapper;
using ProofOfConcept.AbstractApiClient.Dto;
using ProofOfConcept.Domain.Model;
using System;

namespace ProofOfConcept.ApiClientDomain
{
    public class ApiClientToDomainProfile : Profile
    {
        public ApiClientToDomainProfile()
        {
            CreateMap<ITimestampDto, DateEntity>(MemberList.Source)
                 .ForMember(n => n.Date, opt => opt.MapFrom(d => DateTimeOffset.FromUnixTimeSeconds(d.T)));

            CreateMap<IFloatValueTimestampDto, NuplEntity>(MemberList.Source)
                .IncludeBase<ITimestampDto, DateEntity>()
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V));

            CreateMap<IIntValueTimestampDto, NewAddressesEntity>(MemberList.Source)
                .IncludeBase<ITimestampDto, DateEntity>()
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V));

            CreateMap<IIntValueTimestampDto, TotalAddressesEntity>(MemberList.Source)
                .IncludeBase<ITimestampDto, DateEntity>()
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V));

            CreateMap<IIntValueTimestampDto, ActiveAddressesEntity>(MemberList.Source)
                .IncludeBase<ITimestampDto, DateEntity>()
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V));

        }
    }
}
