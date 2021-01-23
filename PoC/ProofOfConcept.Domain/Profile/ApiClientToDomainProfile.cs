﻿using AutoMapper;
using ProofOfConcept.AbstractApiClient.Dto;
using ProofOfConcept.Domain.Model;
using System;

namespace ProofOfConcept.ApiClientDomain
{
    public class ApiClientToDomainProfile : Profile
    {
        public ApiClientToDomainProfile()
        {
            CreateMap<INuplDto, NuplEntity>(MemberList.Source)
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V))
                .ForMember(n => n.Date, opt => opt.MapFrom(d => DateTimeOffset.FromUnixTimeSeconds(d.T)));

            CreateMap<INewAddressesDto, NewAddressesEntity>(MemberList.Source)
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V))
                .ForMember(n => n.Date, opt => opt.MapFrom(d => DateTimeOffset.FromUnixTimeSeconds(d.T)));

            CreateMap<ITotalAddressesDto, TotalAddressesEntity>(MemberList.Source)
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V))
                .ForMember(n => n.Date, opt => opt.MapFrom(d => DateTimeOffset.FromUnixTimeSeconds(d.T)));

            CreateMap<IActiveAddressesDto, ActiveAddressesEntity>(MemberList.Source)
                .ForMember(n => n.Value, opt => opt.MapFrom(d => d.V))
                .ForMember(n => n.Date, opt => opt.MapFrom(d => DateTimeOffset.FromUnixTimeSeconds(d.T)));

        }
    }
}
