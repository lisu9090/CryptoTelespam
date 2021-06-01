﻿using ProofOfConcept.Application.Const.Code;
using ProofOfConcept.Application.Service.DataProcess.Abstract;
using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class MvrvZScoreEventDetectorService : IDataProcessor<float>
    {
        private const float LEVEL_0 = 0.3f;
        private const float LEVEL_1 = 0.5f;
        private const float LEVEL_2 = 4f;
        private const float LEVEL_3 = 10f;

        public ZoneChageEvent<Puell> DetectEvent(Puell data)
        {
            var buyRange = Range.And(x => x >= LEVEL_0, y => y <= LEVEL_1);
            var sellRange = Range.And(x => x >= LEVEL_2, y => y <= LEVEL_3);

            if (buyRange.IsInRange(data.Value) && !buyRange.IsInRange(data.PreviousValue))
            {
                return new ZoneChageEvent<Puell>(data, PuellEventCode.ENTER_BUY_ZONE);
            }
            else if (!buyRange.IsInRange(data.Value) && buyRange.IsInRange(data.PreviousValue))
            {
                return new ZoneChageEvent<Puell>(data, PuellEventCode.ESCAPE_BUY_ZONE);
            }
            else if (sellRange.IsInRange(data.Value) && !sellRange.IsInRange(data.PreviousValue))
            {
                return new ZoneChageEvent<Puell>(data, PuellEventCode.ENTER_SELL_ZONE);
            }
            else if (!sellRange.IsInRange(data.Value) && sellRange.IsInRange(data.PreviousValue))
            {
                return new ZoneChageEvent<Puell>(data, PuellEventCode.ESCAPE_SELL_ZONE);
            }

            return null;
        }

        public ZoneChageEvent<MvrvZScore> DetectEvent(MvrvZScore data)
        {
            throw new System.NotImplementedException();
        }

        public ZoneChangeEvent<float> DetectEvent(IndicatorValueCollection<float> indicatorValues)
        {
            throw new System.NotImplementedException();
        }
    }
}