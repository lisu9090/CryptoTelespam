using System;

namespace ProofOfConcept.Domain.Helper
{
    internal class DateTimeBuilder
    {
        private DateTimeOffset _dateTimeOffset;

        private DateTimeBuilder(DateTimeOffset dateTimeOffset)
        {
            _dateTimeOffset = dateTimeOffset;
        }

        public static DateTimeBuilder Now()
        {
            return new DateTimeBuilder(DateTimeOffset.Now);
        }

        public static DateTimeBuilder UtcNow()
        {
            return new DateTimeBuilder(DateTimeOffset.UtcNow);
        }

        public DateTimeBuilder AddMilliseconds(double milliseconds)
        {
            _dateTimeOffset = _dateTimeOffset.AddMilliseconds(milliseconds);

            return this;
        }

        public DateTimeBuilder AddSeconds(double seconds)
        {
            _dateTimeOffset = _dateTimeOffset.AddSeconds(seconds);

            return this;
        }

        public DateTimeBuilder AddMinutes(double minutes)
        {
            _dateTimeOffset = _dateTimeOffset.AddMinutes(minutes);

            return this;
        }

        public DateTimeBuilder AddHours(double hours)
        {
            _dateTimeOffset = _dateTimeOffset.AddHours(hours);

            return this;
        }

        public DateTimeBuilder AddDays(double days)
        {
            _dateTimeOffset = _dateTimeOffset.AddDays(days);

            return this;
        }

        public DateTimeBuilder AddMonths(int months)
        {
            _dateTimeOffset = _dateTimeOffset.AddMonths(months);

            return this;
        }

        public DateTimeBuilder AddYears(int years)
        {
            _dateTimeOffset = _dateTimeOffset.AddYears(years);

            return this;
        }

        public DateTimeBuilder TruncateToHour()
        {
            AddMinutes(-_dateTimeOffset.Minute);
            AddSeconds(-_dateTimeOffset.Second);
            return AddMilliseconds(-_dateTimeOffset.Millisecond);
        }

        public DateTimeBuilder Truncate()
        {
            AddHours(-_dateTimeOffset.Hour);
            return TruncateToHour();
        }

        public DateTimeOffset Build()
        {
            return _dateTimeOffset;
        }
    }
}
