using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;

namespace ProofOfConcept.Domain.Zone
{
    public class ZoneSelectionMediator
    {
        public IndicatorZone<TIndicator> GetZone<TIndicator, TValue>(TValue value)
            where TIndicator : CryptocurrencyIndicator<TValue>
        {
            try
            {
                Type zoneBaseType = typeof(IndicatorZone<TIndicator>);
                Type zoneTesterType = typeof(IZoneRange<IndicatorZone<TIndicator>, TIndicator, TValue>);

                IZoneRange<IndicatorZone<TIndicator>, TIndicator, TValue> matchedZoneTester = GetType()
                    .Assembly
                    .DefinedTypes
                    .Where(type => zoneTesterType.IsAssignableFrom(type))
                    .Select(type => (IZoneRange<IndicatorZone<TIndicator>, TIndicator, TValue>)Activator.CreateInstance(type))
                    .Where(tester => tester.IsInZone(value))
                    .FirstOrDefault();

                Type zoneType = matchedZoneTester
                   ?.GetType()
                   .GetInterfaces()
                   .Where(testerInterface => zoneTesterType.IsAssignableFrom(testerInterface))
                   .First()
                   .GetGenericArguments()
                   .Where(genericArgument => zoneBaseType.IsAssignableFrom(genericArgument))
                   .FirstOrDefault();

                return zoneType != null ? (IndicatorZone<TIndicator>)Activator.CreateInstance(zoneType) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }
    }
}