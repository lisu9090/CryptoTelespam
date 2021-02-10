using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Code;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using ProofOfConcept.Domain.Helper;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<Nupl>
    {
        private const float LEVEL_0 = 0;
        private const float LEVEL_1 = 0.25f;
        private const float LEVEL_2 = 0.5f;
        private const float LEVEL_3 = 0.75f;
        private readonly Dictionary<string, Range2D> _eventLevels = new Dictionary<string, Range2D>();

        public NuplEventDetectorService()
        {
            _eventLevels.Add(NuplEventCode.CAPITULATION, Range2D.And(x => x >= double.MinValue, y => y < LEVEL_0));
            _eventLevels.Add(NuplEventCode.BELIEFE, Range2D.And(x => x >= LEVEL_0, y => y < LEVEL_1));
            _eventLevels.Add(NuplEventCode.OPTIMISM, Range2D.And(x => x >= LEVEL_1, y => y < LEVEL_2));
            _eventLevels.Add(NuplEventCode.HOPE, Range2D.And(x => x >= LEVEL_2, y => y < LEVEL_3));
            _eventLevels.Add(NuplEventCode.EUPHORIA, Range2D.And(x => x >= LEVEL_3, y => y <= double.MaxValue));
        }

        public Task<StockEvent<Nupl>> DetectEventAsync(Nupl data)
        {
            return Task.Run(() => 
            {
                var result = _eventLevels.First(lvl => lvl.Value.IsInRange(data.Value)).Key;
                var differenceCheck = _eventLevels.First(lvl => lvl.Value.IsInRange(data.PreviousValue)).Key;

                return !result.Equals(differenceCheck) ? new StockEvent<Nupl>(data, result) : null;
            });
        }
    }
}
