using System;
using System.Collections.Generic;
using System.Text;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        #region RealRateOfReturn scalar to scalar

        public static decimal RealRateOfReturn(this decimal nominalRateOfReturn, decimal inflationRate)
        {
            return (((1 + (nominalRateOfReturn / 100)) / (1 + (inflationRate / 100))) - 1) * 100;
        }

        public static double RealRateOfReturn(this double nominalRateOfReturn, double inflationRate)
        {
            return (((1 + (nominalRateOfReturn / 100)) / (1 + (inflationRate / 100))) - 1) * 100;
        }

        public static float RealRateOfReturn(this float nominalRateOfReturn, float inflationRate)
        {
            return (((1 + (nominalRateOfReturn / 100)) / (1 + (inflationRate / 100))) - 1) * 100;
        }

        #endregion

        #region RealRateOfReturn IEnumerable to scalar

        public static decimal RealRateOfReturn<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> nominalRateOfReturnSelector, Func<TSource, decimal> inflationRateSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (nominalRateOfReturnSelector == null)
            {
                throw new ArgumentNullException(nameof(nominalRateOfReturnSelector));
            }

            if (inflationRateSelector == null)
            {
                throw new ArgumentNullException(nameof(inflationRateSelector));
            }

            checked
            {
                var nominalRateOfReturn = source.AccumulateCompoundInterest(nominalRateOfReturnSelector);
                var inflationRate = source.AccumulateCompoundInterest(inflationRateSelector);

                return nominalRateOfReturn.RealRateOfReturn(inflationRate);
            }
        }

        public static double RealRateOfReturn<TSource>(this IEnumerable<TSource> source, Func<TSource, double> nominalRateOfReturnSelector, Func<TSource, double> inflationRateSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (nominalRateOfReturnSelector == null)
            {
                throw new ArgumentNullException(nameof(nominalRateOfReturnSelector));
            }

            if (inflationRateSelector == null)
            {
                throw new ArgumentNullException(nameof(inflationRateSelector));
            }

            checked
            {
                var nominalRateOfReturn = source.AccumulateCompoundInterest(nominalRateOfReturnSelector);
                var inflationRate = source.AccumulateCompoundInterest(inflationRateSelector);

                return nominalRateOfReturn.RealRateOfReturn(inflationRate);
            }
        }

        public static float RealRateOfReturn<TSource>(this IEnumerable<TSource> source, Func<TSource, float> nominalRateOfReturnSelector, Func<TSource, float> inflationRateSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (nominalRateOfReturnSelector == null)
            {
                throw new ArgumentNullException(nameof(nominalRateOfReturnSelector));
            }

            if (inflationRateSelector == null)
            {
                throw new ArgumentNullException(nameof(inflationRateSelector));
            }

            checked
            {
                var nominalRateOfReturn = source.AccumulateCompoundInterest(nominalRateOfReturnSelector);
                var inflationRate = source.AccumulateCompoundInterest(inflationRateSelector);

                return nominalRateOfReturn.RealRateOfReturn(inflationRate);
            }
        }

        #endregion
                
    }
}
