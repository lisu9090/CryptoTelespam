using AutoMapper;
using ProofOfConcept.ApiClient.Dto;
using ProofOfConcept.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.ApiClient.MappingProfile
{
    public class ApiClientProfile : Profile
    {
        public ApiClientProfile()
        {
            CreateMap<IEnumerable<IntValueTimestampDto>, ScopedIndicator<int>>()
                .BeforeMap((s, d) =>
                {
                    if (s.Count() < 2)
                    {
                        throw new Exception("Mapping error, collection must contain 2 or more items.");
                    }
                })
                .ForMember(d => d.Time, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.First().T)))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.First().V))
                .ForMember(d => d.PreviousTime, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.ElementAt(1).T)))
                .ForMember(d => d.PreviousValue, opt => opt.MapFrom(s => s.ElementAt(1).V));

            CreateMap<IEnumerable<FloatValueTimestampDto>, ScopedIndicator<float>>()
                .BeforeMap((s, d) =>
                {
                    if (s.Count() < 2)
                    {
                        throw new Exception("Mapping error, collection must contain 2 or more items.");
                    }
                })
                .ForMember(d => d.Time, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.First().T)))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.First().V))
                .ForMember(d => d.PreviousTime, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.ElementAt(1).T)))
                .ForMember(d => d.PreviousValue, opt => opt.MapFrom(s => s.ElementAt(1).V));

            CreateMap<IEnumerable<FloatValueTimestampDto>, Nupl>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<FloatValueTimestampDto>, Puell>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<IntValueTimestampDto>, NewAddresses>()
                .IncludeBase<IEnumerable<IntValueTimestampDto>, ScopedIndicator<int>>();

            CreateMap<IEnumerable<IntValueTimestampDto>, TotalAddresses>()
                .IncludeBase<IEnumerable<IntValueTimestampDto>, ScopedIndicator<int>>();

            CreateMap<IEnumerable<IntValueTimestampDto>, ActiveAddresses>()
                .IncludeBase<IEnumerable<IntValueTimestampDto>, ScopedIndicator<int>>();

            CreateMap<IEnumerable<FloatValueTimestampDto>, LthNupl>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<FloatValueTimestampDto>, MarketCapThermocapRatio>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicator<float>>();

            CreateMap<IEnumerable<FloatValueTimestampDto>, StfDeflection>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicator<float>>();
        }
    }
}