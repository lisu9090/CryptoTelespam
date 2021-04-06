using AutoMapper;
using ProofOfConcept.ApiClient.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.ApiClient.Helper
{
    internal static class MapExtension
    {
        public static TMapResult DtoOrderedMap<T, TMapResult>(this IMapper mapper, IEnumerable<T> data) where T : TimestampDto
        {
            data = data.OrderByDescending(item => item.T);
            return mapper.Map<TMapResult>(data);
        }
    }
}