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
        public static decimal WeightedAverage<T>(this IEnumerable<T> source, Func<T, decimal> value, Func<T, decimal> weight)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (weight == null)
            {
                throw new ArgumentNullException(nameof(weight));
            }

            decimal weightedValueSum = source.Sum(x => value(x) * weight(x));
            decimal weightSum = source.Sum(x => weight(x));

            if (weightSum != 0)
                return weightedValueSum / weightSum;
            else
                throw new DivideByZeroException(nameof(weightSum));
        }

        public static double WeightedAverage<T>(this IEnumerable<T> source, Func<T, double> value, Func<T, double> weight)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (weight == null)
            {
                throw new ArgumentNullException(nameof(weight));
            }

            double weightedValueSum = source.Sum(x => value(x) * weight(x));
            double weightSum = source.Sum(x => weight(x));

            if (weightSum != 0)
                return weightedValueSum / weightSum;
            else
                throw new DivideByZeroException(nameof(weightSum));
        }

        public static float WeightedAverage<T>(this IEnumerable<T> source, Func<T, float> value, Func<T, float> weight)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (weight == null)
            {
                throw new ArgumentNullException(nameof(weight));
            }

            float weightedValueSum = source.Sum(x => value(x) * weight(x));
            float weightSum = source.Sum(x => weight(x));

            if (weightSum != 0)
                return weightedValueSum / weightSum;
            else
                throw new DivideByZeroException(nameof(weightSum));
        }
    }
}
