using ProofOfConcept.Application.Service.ZoneChange.Abstract;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.NuplZone;
using ProofOfConcept.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Application.Service.ZoneChange
{
    public class LthNuplZoneChangeDetectorService : IZoneChangeDetector<float>
    {
        private readonly NuplZoneService _zoneService;

        public LthNuplZoneChangeDetectorService(NuplZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public ZoneChangeEvent<float> DetectEvent(IndicatorValueCollection<float> indicatorValues)
        {
            if (indicatorValues == null || indicatorValues.Count() < 2)
            {
                return null;
            }

            IEnumerable<IndicatorValue<float>> orderedData = indicatorValues
                .OrderByDescending(indicatorValue => indicatorValue.Time);

            IndicatorValue<float> recentValue = orderedData.First();
            IndicatorValue<float> previousValue = orderedData.Last();

            ZoneId? recentZone = _zoneService.SelectZone(recentValue.Value);
            ZoneId? previousZone = _zoneService.SelectZone(previousValue.Value);

            if (!recentZone.HasValue || !previousZone.HasValue || recentZone == previousZone)
            {
                return null;
            }

            return new ZoneChangeEvent<float>(
                MessageTemplateId.Test, //TODO get from domain zone change service
                recentZone.Value,
                previousZone.Value,
                indicatorValues.IndicatorId,
                indicatorValues.AssetId);
        }
    }
}