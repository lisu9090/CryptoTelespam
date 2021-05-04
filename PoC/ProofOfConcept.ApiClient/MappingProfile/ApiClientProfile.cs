using AutoMapper;
using ProofOfConcept.ApiClient.Dto;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Indicator;
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

            CreateMap<IEnumerable<TimestampedFloatValueDto>, Nupl>()
                .IncludeBase<IEnumerable<TimestampedFloatValueDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<TimestampedFloatValueDto>, Puell>()
                .IncludeBase<IEnumerable<TimestampedFloatValueDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<TimestampedIntValueDto>, NewAddresses>()
                .IncludeBase<IEnumerable<TimestampedIntValueDto>, ScopedIndicator<int>>();

            CreateMap<IEnumerable<TimestampedIntValueDto>, TotalAddresses>()
                .IncludeBase<IEnumerable<TimestampedIntValueDto>, ScopedIndicator<int>>();

            CreateMap<IEnumerable<TimestampedIntValueDto>, ActiveAddresses>()
                .IncludeBase<IEnumerable<TimestampedIntValueDto>, ScopedIndicator<int>>();

            CreateMap<IEnumerable<TimestampedFloatValueDto>, LthNupl>()
                .IncludeBase<IEnumerable<TimestampedFloatValueDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<TimestampedFloatValueDto>, MarketCapThermocapRatio>()
                .IncludeBase<IEnumerable<TimestampedFloatValueDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<TimestampedFloatValueDto>, StfDeflection>()
                .IncludeBase<IEnumerable<TimestampedFloatValueDto>, ScopedIndicator<float>>();
        }
    }
}