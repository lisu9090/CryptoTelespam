using ProofOfConcept.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ProofOfConcept.Application.Service.ZoneChange.Abstract
{
    public abstract class ZoneChangeDetectorFactoryBase : ZoneChangeDetectorFactory<float>
    {
        private readonly Dictionary<IndicatorId, Func<IZoneChangeDetector<float>>> _floatBasedIndicators;

        public ZoneChangeDetectorFactoryBase()
        {
            _floatBasedIndicators = new Dictionary<IndicatorId, Func<IZoneChangeDetector<float>>>
            {
                { IndicatorId.LthNupl, () => GetService<LthNuplZoneChangeDetectorService, float>() },
                { IndicatorId.MarketCapThermocapRatio, () => GetService<MarketCapThermocapRatioEventDetectorService, float>() },
                { IndicatorId.MvrvZScore, () => GetService<MvrvZScoreEventDetectorService, float>() },
                { IndicatorId.Nupl, () => GetService<NuplEventDetectorService, float>() },
                { IndicatorId.Puell, () => GetService<PuellEventDetectorService, float>() },
                { IndicatorId.StfDeflection, () => GetService<StfDeflectionEventDetectorService, float>() }
            };
        }

        private IZoneChangeDetector<TValue> SelectDataProcessor<TValue>(
            Dictionary<IndicatorId, Func<IZoneChangeDetector<TValue>>> indicatorSelectors,
            IndicatorId indicatorId)
        {
            if (!indicatorSelectors.ContainsKey(indicatorId))
            {
                throw new NotSupportedException($"Factory doesn't contain implementation for IndicatorId == {indicatorId}");
            }

            return indicatorSelectors[indicatorId]();
        }

        protected abstract IZoneChangeDetector<TValue> GetService<TImplementation, TValue>()
            where TImplementation : IZoneChangeDetector<TValue>;

        IZoneChangeDetector<float> ZoneChangeDetectorFactory<float>.GetDataProcessor(IndicatorId indicatorId) =>
            SelectDataProcessor(_floatBasedIndicators, indicatorId);
    }
}