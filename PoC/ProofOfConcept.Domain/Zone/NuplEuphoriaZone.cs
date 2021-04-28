using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Zone
{
    public class NuplEuphoriaZone : IndicatorZone<Nupl>
    {
        public override string Name => "Euphoria";

        internal interface IZoneTester<in TZone, TIndicator, TValue>
            where TZone : IndicatorZone<TIndicator>
            where TIndicator : CryptocurrencyIndicator<TValue>
        {
            bool IsInZone(TValue value);
        }

        internal class ZoneTester : IZoneTester<NuplEuphoriaZone, Nupl, float>
        {
            public bool IsInZone(float value) => true;
        }

        internal class ZoneMediator
        {
            private readonly Dictionary<Type, object> _zoneTesters = new Dictionary<Type, object>
            {
                //todo take classes from assembly
                { typeof(Nupl), new ZoneTester() }
            };

            public IndicatorZone<TIndicator> GetZone<TIndicator, TValue>(TValue value)
                where TIndicator : CryptocurrencyIndicator<TValue>
            {
                try
                {
                    Type zoneBaseType = typeof(IndicatorZone<TIndicator>);
                    Type zoneTesterType = typeof(IZoneTester<IndicatorZone<TIndicator>, TIndicator, TValue>);

                    IZoneTester<IndicatorZone<TIndicator>, TIndicator, TValue> matchedZoneTester = GetType()
                        .Assembly
                        .DefinedTypes
                        .Where(type => zoneTesterType.IsAssignableFrom(type))
                        .Select(type => (IZoneTester<IndicatorZone<TIndicator>, TIndicator, TValue>)Activator.CreateInstance(type))
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
}