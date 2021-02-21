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
    public class PuellEventDetectorService : IDataProcessorService<Puell>
    {
        private const float LEVEL_0 = 0.3f;
        private const float LEVEL_1 = 0.5f;
        private const float LEVEL_2 = 4f;
        private const float LEVEL_3 = 10f;
        private const int BUY_CLASS = 1;
        private const int WAIT_CLASS = 2;
        private const int SELL_CLASS = 3;
        private readonly Dictionary<int, Range> _eventLevels = new Dictionary<int, Range>();

        public PuellEventDetectorService()
        {
            _eventLevels.Add(BUY_CLASS, Range.And(x => x >= LEVEL_0, y => y <= LEVEL_1));
            _eventLevels.Add(WAIT_CLASS, Range.And(x => x > LEVEL_1, y => y < LEVEL_2));
            _eventLevels.Add(SELL_CLASS, Range.And(x => x >= LEVEL_2, y => y <= LEVEL_3));
        }

        public Task<StockEvent<Puell>> DetectEventAsync(Puell data)
        {
            return Task.Run(() => 
            {
                var currenClass = _eventLevels.First(lvl => lvl.Value.IsInRange(data.Value)).Key;
                var previousCLass = _eventLevels.First(lvl => lvl.Value.IsInRange(data.PreviousValue)).Key;

                if(currenClass > previousCLass)
                {
                    if(currenClass == SELL_CLASS)
                    {
                        return new StockEvent<Puell>(data, PuellEventCode.ENTER_SELL_ZONE);
                    }

                    return new StockEvent<Puell>(data, PuellEventCode.ESCAPE_BUY_ZONE);
                }
                else if (currenClass < previousCLass)
                {
                    if (currenClass == BUY_CLASS)
                    {
                        return new StockEvent<Puell>(data, PuellEventCode.ENTER_BUY_ZONE);
                    }

                    return new StockEvent<Puell>(data, PuellEventCode.ESCAPE_SELL_ZONE);
                }

                return null;
            });
        }
    }
}
