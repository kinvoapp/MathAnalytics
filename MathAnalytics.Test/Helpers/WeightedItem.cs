using System;
using System.Collections.Generic;
using System.Text;

namespace MathAnalytics.Test.Helpers
{
      public class WeightedItem<T>
    {
        public WeightedItem(T value, T weight)
        {
            this.Value = value;
            this.Weight = weight;
        }

        public T Value { get; set; }

        public T Weight { get; set; }
    }
}
