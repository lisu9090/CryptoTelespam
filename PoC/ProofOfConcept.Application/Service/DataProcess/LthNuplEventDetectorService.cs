using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Extensions;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;
using ProofOfConcept.Domain.Zone.LthNuplZone;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class LthNuplEventDetectorService : IDataProcessorService<LthNupl>
    {
        private readonly LthNuplZoneService _zoneService;

        public LthNuplEventDetectorService(LthNuplZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public ZoneChageEvent<LthNupl> DetectEvent(LthNupl data)
        {
            if (data == null || data.Count() < 2)
            {
                return null;
            }

            IEnumerable<IndicatorValue<float>> orderedData = data.OrderByDescending(indicatorValue => indicatorValue.Time);
            IndicatorValue<float> recentValue = orderedData.First();
            IndicatorValue<float> previousValue = orderedData.Last();

            IndicatorZone<LthNupl> recentZone = _zoneService.GetZone(recentValue.Value);
            IndicatorZone<LthNupl> previousZone = _zoneService.GetZone(previousValue.Value);

            if (recentZone.Name == previousZone.Name)
            {
                return null;
            }

            return new ZoneChageEvent<LthNupl>
            {
                Indicator = data,
                CurrentZone = recentZone,
                PreviousZone = previousZone,
                StockEventMessageTemplateId = 1 //TODO add propper message template
            };
        }
    }
}