using ProofOfConcept.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ProofOfConcept.Application.Service.MessageSend.Abstract
{
    public abstract class MessageSenderFactoryBase :
        IMessageSenderFactory<float>,
        IMessageSenderFactory<int>
    {
        private readonly Dictionary<IndicatorId, Func<IMessageSender<float>>> _floatBasedIndicators;
        private readonly Dictionary<IndicatorId, Func<IMessageSender<int>>> _intBasedIndicators;

        public MessageSenderFactoryBase()
        {
            _floatBasedIndicators = new Dictionary<IndicatorId, Func<IMessageSender<float>>>
            {
                { IndicatorId.LthNupl, () => GetService<LthNuplMessageService, float>() },
                { IndicatorId.MarketCapThermocapRatio, () => GetService<MarketCapThermocapRatioMessageService, float>() },
                { IndicatorId.MvrvZScore, () => GetService<MvrvZScoreMessageService, float>() },
                { IndicatorId.Nupl, () => GetService<NuplMessageService, float>() },
                { IndicatorId.Puell, () => GetService<PuellMessageService, float>() },
                { IndicatorId.StfDeflection, () => GetService<StfDeflectionMessageService, float>() }
            };

            _intBasedIndicators = new Dictionary<IndicatorId, Func<IMessageSender<int>>>
            {
                { IndicatorId.ActiveAddresses, () => GetService<ActiveAddressesMessageService, int>() },
                { IndicatorId.NewAddresses, () => GetService<NewAddressesMessageService, int>() },
                { IndicatorId.TotalAddresses, () => GetService<TotalAddressesMessageService, int>() }
            };
        }

        private IMessageSender<TValue> SelectMessageSender<TValue>(
            Dictionary<IndicatorId, Func<IMessageSender<TValue>>> indicatorSelectors,
            IndicatorId indicatorId)
        {
            if (!indicatorSelectors.ContainsKey(indicatorId))
            {
                throw new NotSupportedException($"Factory doesn't contain implementation for IndicatorId == {indicatorId}");
            }

            return indicatorSelectors[indicatorId]();
        }

        protected abstract IMessageSender<TValue> GetService<TImplementation, TValue>()
            where TImplementation : IMessageSender<TValue>;

        IMessageSender<float> IMessageSenderFactory<float>.GetMessageSender(IndicatorId indicatorId) =>
            SelectMessageSender(_floatBasedIndicators, indicatorId);

        IMessageSender<int> IMessageSenderFactory<int>.GetMessageSender(IndicatorId indicatorId) =>
            SelectMessageSender(_intBasedIndicators, indicatorId);
    }
}