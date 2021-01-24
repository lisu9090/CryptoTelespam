using ProofOfConcept.AbstractApiClient.Dto;
using ProofOfConcept.Common.Const;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractApiClient
{
    public interface IRestApiService
    {
        Task<IEnumerable<IFloatValueTimestampDto>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IIntValueTimestampDto>> GetNewAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IIntValueTimestampDto>> GetTotalAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IIntValueTimestampDto>> GetActiveAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IFloatValueTimestampDto>> GetStfDefectionAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IFloatValueTimestampDto>> GetLthNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
        Task<IEnumerable<IFloatValueTimestampDto>> GetMarketCapThermocapRatioAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
    }
}
