using System;
using System.Collections.Generic;
using System.Text;

namespace MathAnalytics.Test.Helpers
{
    public class BetaSampleItem<T>
    {
        public BetaSampleItem(DateTime referenceDate, T marketReturn, T assetReturn)
        {
            this.ReferenceDate = referenceDate;
            this.MarketReturn = marketReturn;
            this.AssetReturn = assetReturn;
        }

        public DateTime ReferenceDate { get; set; }

        public T MarketReturn { get; set; }

        public T AssetReturn { get; set; }
    }
}