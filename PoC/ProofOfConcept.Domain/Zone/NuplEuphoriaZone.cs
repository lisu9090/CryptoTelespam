using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Domain.Zone.Enum;

namespace ProofOfConcept.Domain.Zone
{
    public class NuplEuphoriaZone : IndicatorZone<Nupl>
    {
        public override int Id => (int)IndicatorZoneId.NuplEuphoria;

        public override int IndicatorId => (int)Indicator.Enum.IndicatorId.Nupl;

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
                    var zoneTesterType = typeof(IZoneTester<IndicatorZone<TIndicator>, TIndicator, TValue>);
                    var zoneType = GetType()
                        .Assembly
                        .GetTypes()
                        .Where(type => zoneTesterType.IsAssignableFrom(type))
                        .Select(type => (IZoneTester<IndicatorZone<TIndicator>, TIndicator, TValue>)Activator.CreateInstance(type))
                        .Where(tester => tester.IsInZone(value))
                        .FirstOrDefault() //null check
                        .GetType()
                        .GetInterfaces()
                        .Where(testerInterface => testerInterface.Equals(zoneTesterType))
                        .First()
                        .GetGenericArguments()
                        .First();

                    return (IndicatorZone<TIndicator>)Activator.CreateInstance(zoneType);
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