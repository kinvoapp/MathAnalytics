using System;
using System.Collections.Generic;

namespace MathAnalytics
{
    public static partial class Extensions
    {
        public static decimal StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return (decimal)Math.Sqrt((double)source.Variance(selector));
        }

        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            return Math.Sqrt(source.Variance(selector));
        }

        public static float StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return (float)Math.Sqrt(source.Variance(selector));
        }
    }
}
