using ProofOfConcept.Application.Const.Code;
using ProofOfConcept.Application.Service.DataProcess.Abstract;
using ProofOfConcept.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class StfDeflectionEventDetectorService : IDataProcessor<float>
    {
        private const float LEVEL_0 = 0f;
        private readonly Dictionary<string, Range> _eventLevels = new Dictionary<string, Range>();

        public StfDeflectionEventDetectorService()
        {
            _eventLevels.Add(StfDeflectionEventCode.ACCEPTABLE, Range.And(x => x >= double.MinValue, y => y <= LEVEL_0));
            _eventLevels.Add(StfDeflectionEventCode.UNACCEPTABLE, Range.And(x => x > LEVEL_0, y => y <= double.MaxValue));
        }

        public ZoneChageEvent<StfDeflection> DetectEvent(StfDeflection data)
        {
            string currentLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.Value)).Key;
            string previousLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.PreviousValue)).Key;

            return !currentLevel.Equals(previousLevel) ? new ZoneChageEvent<StfDeflection>(data, currentLevel, previousLevel) : null;
        }

        public ZoneChangeEvent<float> DetectEvent(IndicatorValueCollection<float> indicatorValues)
        {
            throw new System.NotImplementedException();
        }
    }
}