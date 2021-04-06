using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Abstract.Application;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProofOfConcept.Application.Helper;
using System.Linq;
using ProofOfConcept.Application.Const.Code;

namespace ProofOfConcept.Application.Domain.DataProcess
{
    public class MarketCapThermocapRatioEventDetectorService : IDataProcessorService<MarketCapThermocapRatio>
    {
        private const float LEVEL_0 = 0.000003f;
        private const float LEVEL_1 = 0.000004f;
        private readonly Dictionary<string, Range> _eventLevels = new Dictionary<string, Range>();

        public MarketCapThermocapRatioEventDetectorService()
        {
            _eventLevels.Add(MarketCapEventCode.ACCEPTABLE, Range.And(x => x >= double.MinValue, y => y <= LEVEL_0));
            _eventLevels.Add(MarketCapEventCode.CLOSE_TO_OVERHEAT, Range.And(x => x > LEVEL_0, y => y <= LEVEL_1));
            _eventLevels.Add(MarketCapEventCode.OVERHEATED, Range.And(x => x > LEVEL_1, y => y <= double.MaxValue));
        }

        public StockEvent<MarketCapThermocapRatio> DetectEvent(MarketCapThermocapRatio data)
        {
            string currentLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.Value)).Key;
            string previousLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.PreviousValue)).Key;

            return !currentLevel.Equals(previousLevel) ? new StockEvent<MarketCapThermocapRatio>(data, currentLevel, previousLevel) : null;
        }
    }
}
