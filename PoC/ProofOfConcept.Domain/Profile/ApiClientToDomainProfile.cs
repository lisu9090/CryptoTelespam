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
                .ConvertUsing((s, d) => 
                {
                    if(s.Count() < 2)
                    {
                        throw new Exception("Mapping error, collection must contain 2 or more items.");
                    }

                    s = s.OrderByDescending(item => item.T);

                    d.Time = DateTimeOffset.FromUnixTimeSeconds(s.First().T);
                    d.Value = s.First().V;
                    d.PreviousTime = DateTimeOffset.FromUnixTimeSeconds(s.ElementAt(1).T);
                    d.PreviousValue = s.ElementAt(1).V;

                    return d;
                });

            CreateMap<IEnumerable<FloatValueTimestampDto>, ScopedIndicatorBase<float>>()
                .ConvertUsing((s, d) =>
                {
                    if (s.Count() < 2)
                    {
                        throw new Exception("Mapping error, collection must contain 2 or more items.");
                    }

                    s = s.OrderByDescending(item => item.T);

                    d.Time = DateTimeOffset.FromUnixTimeSeconds(s.First().T);
                    d.Value = s.First().V;
                    d.PreviousTime = DateTimeOffset.FromUnixTimeSeconds(s.ElementAt(1).T);
                    d.PreviousValue = s.ElementAt(1).V;

                    return d;
                });

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
