using ProofOfConcept.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ProofOfConcept.Application.Service.DataProcess.Abstract
{
    public abstract class DataProcessorFactoryBase :
        IDataProcessorFactory<float>,
        IDataProcessorFactory<int>
    {
        private readonly Dictionary<IndicatorId, Func<IDataProcessor<float>>> _floatBasedIndicators;
        private readonly Dictionary<IndicatorId, Func<IDataProcessor<int>>> _intBasedIndicators;

        public DataProcessorFactoryBase()
        {
            _floatBasedIndicators = new Dictionary<IndicatorId, Func<IDataProcessor<float>>>
            {
                { IndicatorId.LthNupl, () => GetService<LthNuplEventDetectorService, float>() },
                { IndicatorId.MarketCapThermocapRatio, () => GetService<MarketCapThermocapRatioEventDetectorService, float>() },
                { IndicatorId.MvrvZScore, () => GetService<MvrvZScoreEventDetectorService, float>() },
                { IndicatorId.Nupl, () => GetService<NuplEventDetectorService, float>() },
                { IndicatorId.Puell, () => GetService<PuellEventDetectorService, float>() },
                { IndicatorId.StfDeflection, () => GetService<StfDeflectionEventDetectorService, float>() }
            };

            _intBasedIndicators = new Dictionary<IndicatorId, Func<IDataProcessor<int>>>
            {
                { IndicatorId.ActiveAddresses, () => GetService<ActiveAddressesEventDetectorService, int>() },
                { IndicatorId.NewAddresses, () => GetService<NewAddressesEventDetectorService, int>() },
                { IndicatorId.TotalAddresses, () => GetService<TotalAddressesEventDetectorService, int>() }
            };
        }

        private IDataProcessor<TValue> SelectDataProcessor<TValue>(
            Dictionary<IndicatorId, Func<IDataProcessor<TValue>>> indicatorSelectors,
            IndicatorId indicatorId)
        {
            if (!indicatorSelectors.ContainsKey(indicatorId))
            {
                throw new NotSupportedException($"Factory doesn't contain implementation for IndicatorId == {indicatorId}");
            }

            return indicatorSelectors[indicatorId]();
        }

        protected abstract IDataProcessor<TValue> GetService<TImplementation, TValue>()
            where TImplementation : IDataProcessor<TValue>;

        IDataProcessor<float> IDataProcessorFactory<float>.GetDataProcessor(IndicatorId indicatorId) =>
            SelectDataProcessor(_floatBasedIndicators, indicatorId);

        IDataProcessor<int> IDataProcessorFactory<int>.GetDataProcessor(IndicatorId indicatorId) =>
            SelectDataProcessor(_intBasedIndicators, indicatorId);
    }
}