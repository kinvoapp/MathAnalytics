using System;
using System.Collections.Generic;
using System.Linq;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            checked
            {
                decimal average = source.Average(selector);
                int length = source.Count();

                double s = 0;
                
                foreach (TSource item in source)
                {
                    s += Math.Pow((double)selector(item), 2);
                }

                return Convert.ToDecimal((s - length * Math.Pow((double)average, 2)) / (length - 1));
            }

        }

        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            checked
            {
                double average = source.Average(selector);
                int length = source.Count();

                double s = 0;

                foreach (TSource item in source)
                {
                    s += Math.Pow(selector(item), 2);
                }

                return (s - length * Math.Pow((double)average, 2)) / (length - 1);
            }

        }

        public static float Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            checked
            {
                float average = source.Average(selector);
                int length = source.Count();

                double s = 0;

                foreach (TSource item in source)
                {
                    s += Math.Pow((double)selector(item), 2);
                }

                return (float)(s - length * Math.Pow((double)average, 2)) / (length - 1);
            }

        }
    }
}
