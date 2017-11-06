﻿using System;
using System.Collections.Generic;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal GetCumulativePercentage<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
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
                }
            }

            return cumulativePercentage;
        }

        public static float GetCumulativePercentage<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
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
                }
            }

            return cumulativePercentage;
        }

        public static double GetCumulativePercentage<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
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
                }
            }

            return cumulativePercentage;
        }
    }
}