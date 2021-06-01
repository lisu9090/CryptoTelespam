using ProofOfConcept.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Application.Service.DataLoad.Abstract
{
    public abstract class IndicatorValueLoaderFactoryBase :
        IIndicatorValueLoaderFactory<float>,
        IIndicatorValueLoaderFactory<int>
    {
        private readonly Dictionary<IndicatorId, Func<IIndicatorValueLoader<float>>> _floatBasedIndicators;
        private readonly Dictionary<IndicatorId, Func<IIndicatorValueLoader<int>>> _intBasedIndicators;

        public IndicatorValueLoaderFactoryBase()
        {
            _floatBasedIndicators = new Dictionary<IndicatorId, Func<IIndicatorValueLoader<float>>>
            {
                { IndicatorId.LthNupl, () => GetService<LthNuplLoaderService, float>() },
                { IndicatorId.MarketCapThermocapRatio, () => GetService<MarketCapThermocapRatioLoaderService, float>() },
                { IndicatorId.MvrvZScore, () => GetService<MvrvZScoreLoaderService, float>() },
                { IndicatorId.Nupl, () => GetService<NuplLoaderService, float>() },
                { IndicatorId.Puell, () => GetService<PuellLoaderService, float>() },
                { IndicatorId.StfDeflection, () => GetService<StfDeflectionLoaderService, float>() }
            };

            _intBasedIndicators = new Dictionary<IndicatorId, Func<IIndicatorValueLoader<int>>>
            {
                { IndicatorId.ActiveAddresses, () => GetService<ActiveAddressesLoaderService, int>() },
                { IndicatorId.NewAddresses, () => GetService<NewAddressesLoaderService, int>() },
                { IndicatorId.TotalAddresses, () => GetService<TotalAddressesLoaderService, int>() }
            };
        }

        private IIndicatorValueLoader<TValue> SelectLoader<TValue>(
            Dictionary<IndicatorId, Func<IIndicatorValueLoader<TValue>>> indicatorSelectors,
            IndicatorId indicatorId)
        {
            if (!indicatorSelectors.ContainsKey(indicatorId))
            {
                throw new NotSupportedException($"Factory doesn't contain implementation for IndicatorId == {indicatorId}");
            }

            return indicatorSelectors[indicatorId]();
        }

        protected abstract IIndicatorValueLoader<TValue> GetService<TImplementation, TValue>()
            where TImplementation : IIndicatorValueLoader<TValue>;

        IIndicatorValueLoader<float> IIndicatorValueLoaderFactory<float>.GetLoader(IndicatorId indicatorId) =>
            SelectLoader(_floatBasedIndicators, indicatorId);

        IIndicatorValueLoader<int> IIndicatorValueLoaderFactory<int>.GetLoader(IndicatorId indicatorId) =>
            SelectLoader(_intBasedIndicators, indicatorId);
    }
}