using System;
using System.Collections.Generic;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        #region AccumulateCompoundInterest scalar to scalar

        public static decimal AccumulateCompoundInterest(this decimal cumulativeInterest, decimal currentInterest)
        {
            return (((1 + (cumulativeInterest / 100)) * (1 + (currentInterest / 100))) - 1) * 100;
        }

        public static double AccumulateCompoundInterest(this double cumulativeInterest, double currentInterest)
        {
            return (((1 + (cumulativeInterest / 100)) * (1 + (currentInterest / 100))) - 1) * 100;
        }

        public static float AccumulateCompoundInterest(this float cumulativeInterest, float currentInterest)
        {
            return (((1 + (cumulativeInterest / 100)) * (1 + (currentInterest / 100))) - 1) * 100;
        }

        #endregion

        #region AccumulateCompoundInterest IEnumerable to scalar

        public static decimal AccumulateCompoundInterest<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
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
                    cumulativePercentage = cumulativePercentage.AccumulateCompoundInterest(selector(item));
                }
            }

            return cumulativePercentage;
        }

        public static float AccumulateCompoundInterest<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
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
                    cumulativePercentage = cumulativePercentage.AccumulateCompoundInterest(selector(item));
                }
            }

            return cumulativePercentage;
        }

        public static double AccumulateCompoundInterest<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
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
                    cumulativePercentage = cumulativePercentage.AccumulateCompoundInterest(selector(item));
                }
            }

            return cumulativePercentage;
        }

        #endregion

        #region AccumulateCompoundInterest IEnumerable to IEnumerable 
        
        public static IEnumerable<TResult> AccumulateCompoundInterest<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<TSource, decimal, TResult> resultSelector)
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
                    cumulativePercentage = cumulativePercentage.AccumulateCompoundInterest(selector(item));

                    yield return resultSelector(item, cumulativePercentage);

                }
            }
        }

        public static IEnumerable<TResult> AccumulateCompoundInterest<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, double> selector, Func<TSource, double, TResult> resultSelector)
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
                    cumulativePercentage = cumulativePercentage.AccumulateCompoundInterest(selector(item));

                    yield return resultSelector(item, cumulativePercentage);

                }
            }
        }

        public static IEnumerable<TResult> AccumulateCompoundInterest<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, float> selector, Func<TSource, float, TResult> resultSelector)
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
                    cumulativePercentage = cumulativePercentage.AccumulateCompoundInterest(selector(item));

                    yield return resultSelector(item, cumulativePercentage);

                }
            }
        }

        #endregion
    }
}
