using System;
using System.Collections.Generic;
using System.Text;

namespace MathAnalytics
{
    public static partial class Extensions
    {
        public static void CalculateCumulativePercentage<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, Action<TSource, decimal> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            decimal cumulativePercentage = 0M;
            checked
            {
                foreach (TSource item in source)
                {
                    cumulativePercentage = cumulativePercentage.AccumulateInterest(selector(item));

                    action(item, cumulativePercentage);

                }
            }
        }
    }
}
