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

        public Task<StockEvent<Puell>> DetectEventAsync(Puell data)
        {
            return Task.Run(() => 
            {
                var buyRange = Range.And(x => x >= LEVEL_0, y => y <= LEVEL_1);
                var sellRange = Range.And(x => x >= LEVEL_2, y => y <= LEVEL_3);

                if (buyRange.IsInRange(data.Value) && !buyRange.IsInRange(data.PreviousValue))
                {
                    return new StockEvent<Puell>(data, PuellEventCode.ENTER_BUY_ZONE);
                }
                else if (!buyRange.IsInRange(data.Value) && buyRange.IsInRange(data.PreviousValue))
                {
                    return new StockEvent<Puell>(data, PuellEventCode.ESCAPE_BUY_ZONE);
                }
                else if (sellRange.IsInRange(data.Value) && !sellRange.IsInRange(data.PreviousValue))
                {
                    return new StockEvent<Puell>(data, PuellEventCode.ENTER_SELL_ZONE);
                }
                else if (!sellRange.IsInRange(data.Value) && sellRange.IsInRange(data.PreviousValue))
                {
                    return new StockEvent<Puell>(data, PuellEventCode.ESCAPE_SELL_ZONE);
                }

                return null;
            });
        }
    }
}
