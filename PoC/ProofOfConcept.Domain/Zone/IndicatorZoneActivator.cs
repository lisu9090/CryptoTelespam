using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;

namespace ProofOfConcept.Domain.Zone
{
    internal class IndicatorZoneActivator
    {
        public IndicatorZone<TIndicator> CreateZoneInstance<TIndicator, TValue>(
            IZoneRange<IndicatorZone<TIndicator>, TIndicator, TValue> zoneRange
            )
            where TIndicator : CryptoIndicator<TValue>
        {
            Type indicatorZoneType = zoneRange
                .GetType()
                .GetInterfaces()
                .Where(implementedInterface => typeof(IZoneRange<,,>).IsAssignableFrom(implementedInterface))
                .FirstOrDefault()
                .GetGenericArguments()
                .Where(genericArgument => typeof(IndicatorZone<TIndicator>).IsAssignableFrom(genericArgument))
                .FirstOrDefault();

            return (IndicatorZone<TIndicator>)Activator.CreateInstance(indicatorZoneType);
        }
    }
}