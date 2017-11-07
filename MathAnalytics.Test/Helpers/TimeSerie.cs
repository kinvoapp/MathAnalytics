using System;

namespace MathAnalytics.Test.Helpers
{
    
    public class TimeSerie<T>
    {
        public TimeSerie(DateTime referenceDate, T value)
        {
            this.ReferenceDate = referenceDate;
            this.Value = value;
        }

        public T Value { get; set; }

        public DateTime ReferenceDate { get; set; }

        public T GrowthRate { get; set; }
    }
}
