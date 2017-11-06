using System;
using System.Collections.Generic;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static IEnumerable<TResult> CalculateVariation<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<TSource, decimal, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            decimal lastValue = 0M;
            decimal variation = 0M;

            checked
            {
                foreach (TSource item in source)
                {
                    if (lastValue != 0)
                        variation = selector(item).CalculateVariationOver(lastValue);
                    else
                        variation = 0;

                    yield return resultSelector(item, variation);

                    lastValue = selector(item);
                }
            }

        }

        public static IEnumerable<TResult> CalculateVariation<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, double> selector, Func<TSource, double, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            double lastValue = 0;
            double variation = 0;

            checked
            {
                foreach (TSource item in source)
                {
                    if (lastValue != 0)
                        variation = selector(item).CalculateVariationOver(lastValue);
                    else
                        variation = 0;

                    yield return resultSelector(item, variation);

                    lastValue = selector(item);
                }
            }

        }

        public static IEnumerable<TResult> CalculateVariation<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, float> selector, Func<TSource, float, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            float lastValue = 0;
            float variation = 0;

            checked
            {
                foreach (TSource item in source)
                {
                    if (lastValue != 0)
                        variation = selector(item).CalculateVariationOver(lastValue);
                    else
                        variation = 0;

                    yield return resultSelector(item, variation);

                    lastValue = selector(item);
                }
            }

        }
    }
}
