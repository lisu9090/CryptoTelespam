using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.ApiClient
{
    public interface IRestApiService
    {
        Task<IEnumerable<IndicatorValue<float>>> GetNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<float>>> GetPuellMultipleAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<int>>> GetNewAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<int>>> GetTotalAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<int>>> GetActiveAddressesAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<float>>> GetStfDefectionAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<float>>> GetLthNuplAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<float>>> GetMarketCapThermocapRatioAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<float>>> GetMvrvRatioAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);

        Task<IEnumerable<IndicatorValue<float>>> GetMvrvZScoreAsync(string asset, int sinceTimeStamp = 0, int untilTimeStamp = int.MaxValue, string interval = Interval.DAY, string format = MediaType.JSON);
    }
}