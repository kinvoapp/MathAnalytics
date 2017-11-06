using System;

namespace MathAnalytics.Test.Helpers
{
    public class TimeSerie
    {
        public TimeSerie(DateTime referenceDate, decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; set; }

        public DateTime ReferenceDate { get; set; }

        public decimal GrowthRate { get; set; }


    }

    public class TimeSerie<T>
    {
        public TimeSerie(DateTime referenceDate, T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public DateTime ReferenceDate { get; set; }

        public T GrowthRate { get; set; }
    }
}
