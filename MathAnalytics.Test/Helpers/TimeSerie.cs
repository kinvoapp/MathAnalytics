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

        public string Details { get; set; }


        public decimal Variation { get; set; }

        public decimal CumulativeProfitability { get; set; }


    }
}
