using System;
using System.Collections.Generic;

namespace MathAnalytics
{
    public static partial class Extensions
    {
        public static IEnumerable<TResult> CalculateCumulativePercentage<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<TSource, decimal, TResult> resultSelector)
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

                    yield return resultSelector(item, cumulativePercentage);

                }
            }
        }

        public static IEnumerable<TResult> CalculateCumulativePercentage<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, double> selector, Func<TSource, double, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            double cumulativePercentage = 0;
            checked
            {
                foreach (TSource item in source)
                {
                    cumulativePercentage = cumulativePercentage.AccumulateInterest(selector(item));

                    yield return resultSelector(item, cumulativePercentage);

                }
            }
        }

        public static IEnumerable<TResult> CalculateCumulativePercentage<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, float> selector, Func<TSource, float, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            float cumulativePercentage = 0;
            checked
            {
                foreach (TSource item in source)
                {
                    cumulativePercentage = cumulativePercentage.AccumulateInterest(selector(item));

                    yield return resultSelector(item, cumulativePercentage);

                }
            }
        }
    }
}
