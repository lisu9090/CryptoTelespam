﻿using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Abstract.Application;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProofOfConcept.Application.Helper;
using System.Linq;
using ProofOfConcept.Application.Const.Code;

namespace ProofOfConcept.Application.Domain.DataProcess
{
    public class StfDeflectionEventDetectorService : IDataProcessorService<StfDeflection>
    {
        private const float LEVEL_0 = 0f;
        private readonly Dictionary<string, Range> _eventLevels = new Dictionary<string, Range>();

        public StfDeflectionEventDetectorService()
        {
            _eventLevels.Add(StfDeflectionEventCode.ACCEPTABLE, Range.And(x => x >= double.MinValue, y => y <= LEVEL_0));
            _eventLevels.Add(StfDeflectionEventCode.UNACCEPTABLE, Range.And(x => x > LEVEL_0, y => y <= double.MaxValue));
        }

        public StockEvent<StfDeflection> DetectEvent(StfDeflection data)
        {
            string currentLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.Value)).Key;
            string previousLevel = _eventLevels.First(lvl => lvl.Value.IsInRange(data.PreviousValue)).Key;

            return !currentLevel.Equals(previousLevel) ? new StockEvent<StfDeflection>(data, currentLevel, previousLevel) : null;
        }
    }
}
