using AutoMapper;
using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.Abstract.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.ApiClientDomain
{
    public class ApiClientToDomainProfile : Profile
    {
        public ApiClientToDomainProfile()
        {
            CreateMap<IEnumerable<IntValueTimestampDto>, ScopedIndicatorBase<int>>()
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

            CreateMap<IEnumerable<FloatValueTimestampDto>, ScopedIndicatorBase<float>>()
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
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicatorBase<float>>();

            CreateMap<IEnumerable<IntValueTimestampDto>, NewAddresses>()
                .IncludeBase<IEnumerable<IntValueTimestampDto>, ScopedIndicatorBase<int>>();

            CreateMap<IEnumerable<IntValueTimestampDto>, TotalAddresses>()
                .IncludeBase<IEnumerable<IntValueTimestampDto>, ScopedIndicatorBase<int>>();

            CreateMap<IEnumerable<IntValueTimestampDto>, ActiveAddresses>()
                .IncludeBase<IEnumerable<IntValueTimestampDto>, ScopedIndicatorBase<int>>();

            CreateMap<IEnumerable<FloatValueTimestampDto>, LthNupl>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicatorBase<float>>();

            CreateMap<IEnumerable<FloatValueTimestampDto>, MarketCapThermocapRatio>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicatorBase<float>>();

            CreateMap<IEnumerable<FloatValueTimestampDto>, StfDeflection>()
                .IncludeBase<IEnumerable<FloatValueTimestampDto>, ScopedIndicatorBase<float>>();
        }
    }
}
