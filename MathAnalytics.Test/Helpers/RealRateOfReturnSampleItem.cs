using System;
using System.Collections.Generic;
using System.Text;

namespace MathAnalytics.Test.Helpers
{
    public class RealRateOfReturnSampleItem<T>
    {
        public RealRateOfReturnSampleItem(DateTime referenceDate, T nominalRateOfReturn, T inflationReturn)
        {
            this.ReferenceDate = referenceDate;
            this.NominalRateOfReturn = nominalRateOfReturn;
            this.InflationReturn = inflationReturn;
        }

        public DateTime ReferenceDate { get; set; }

        public T NominalRateOfReturn { get; set; }

        public T InflationReturn { get; set; }
    }
}
