using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Const.Code;
using ProofOfConcept.Application.Helper;
using ProofOfConcept.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Application.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<Nupl>
    {
        private const float LEVEL_0 = 0;
        private const float LEVEL_1 = 0.25f;
        private const float LEVEL_2 = 0.5f;
        private const float LEVEL_3 = 0.75f;
        private readonly Dictionary<string, Range> _eventLevels = new Dictionary<string, Range>();

        public NuplEventDetectorService()
        {
            _eventLevels.Add(NuplEventCode.CAPITULATION, Range.And(x => x >= double.MinValue, y => y < LEVEL_0));
            _eventLevels.Add(NuplEventCode.BELIEFE, Range.And(x => x >= LEVEL_0, y => y < LEVEL_1));
            _eventLevels.Add(NuplEventCode.OPTIMISM, Range.And(x => x >= LEVEL_1, y => y < LEVEL_2));
            _eventLevels.Add(NuplEventCode.HOPE, Range.And(x => x >= LEVEL_2, y => y < LEVEL_3));
            _eventLevels.Add(NuplEventCode.EUPHORIA, Range.And(x => x >= LEVEL_3, y => y <= double.MaxValue));
        }

        public StockEvent<Nupl> DetectEvent(Nupl data)
        {
            string currentLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.Value)).Key;
            string previousLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.PreviousValue)).Key;

            return !currentLevel.Equals(previousLevel) ? new StockEvent<Nupl>(data, currentLevel, previousLevel) : null;
        }
    }
}