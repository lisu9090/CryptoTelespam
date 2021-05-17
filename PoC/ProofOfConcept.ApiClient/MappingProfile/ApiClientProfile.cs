using AutoMapper;
using ProofOfConcept.ApiClient.Dto;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.IndicatorTmp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.ApiClient.MappingProfile
{
    public class ApiClientProfile : Profile
    {
        public ApiClientProfile()
        {
            CreateMap<TimestampedIntValueDto, IndicatorValue<int>>()
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.T)))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.V));

            CreateMap<TimestampedFloatValueDto, IndicatorValue<float>>()
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.T)))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.V));
        }
    }
}