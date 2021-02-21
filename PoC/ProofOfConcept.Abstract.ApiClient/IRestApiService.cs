using ProofOfConcept.Abstract.ApiClient.Dto;
using ProofOfConcept.Common.Const;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.ApiClient
{
    public interface IRestApiService
    {
        Task<IEnumerable<FloatValueTimestampDto>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<FloatValueTimestampDto>> GetPuellMultipleAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IntValueTimestampDto>> GetNewAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IntValueTimestampDto>> GetTotalAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IntValueTimestampDto>> GetActiveAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<FloatValueTimestampDto>> GetStfDefectionAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<FloatValueTimestampDto>> GetLthNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<FloatValueTimestampDto>> GetMarketCapThermocapRatioAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
    }
}
