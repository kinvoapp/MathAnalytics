using System;
using System.Collections.Generic;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        #region SharpeRatio scalar to scalar

        public static decimal SharpeRatio(this decimal portfolioReturn, decimal riskFreeRate, decimal standardDeviationOfPortfolioReturn)
        {
            if (standardDeviationOfPortfolioReturn == 0)
                throw new DivideByZeroException(nameof(standardDeviationOfPortfolioReturn));

            return (portfolioReturn - riskFreeRate) / standardDeviationOfPortfolioReturn;
        }

        public static double SharpeRatio(this double portfolioReturn, double riskFreeRate, double standardDeviationOfPortfolioReturn)
        {
            if (standardDeviationOfPortfolioReturn == 0)
                throw new DivideByZeroException(nameof(standardDeviationOfPortfolioReturn));

            return (portfolioReturn - riskFreeRate) / standardDeviationOfPortfolioReturn;
        }

        public static float SharpeRatio(this float portfolioReturn, float riskFreeRate, float standardDeviationOfPortfolioReturn)
        {
            if (standardDeviationOfPortfolioReturn == 0)
                throw new DivideByZeroException(nameof(standardDeviationOfPortfolioReturn));

            return (portfolioReturn - riskFreeRate) / standardDeviationOfPortfolioReturn;
        }

        #endregion

        #region SharpeRatio IEnumerable to scalar

        public static decimal SharpeRatio<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> portfolioReturnSelector, Func<TSource, decimal> riskFreeRateSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (portfolioReturnSelector == null)
            {
                throw new ArgumentNullException(nameof(portfolioReturnSelector));
            }

            if (riskFreeRateSelector == null)
            {
                throw new ArgumentNullException(nameof(riskFreeRateSelector));
            }

            decimal portfolioReturn = 0M;
            decimal riskFreeRate = 0M;

            checked
            {
                foreach (TSource item in source)
                {
                    portfolioReturn = portfolioReturn.AccumulateCompoundInterest(portfolioReturnSelector(item));
                    riskFreeRate = riskFreeRate.AccumulateCompoundInterest(riskFreeRateSelector(item));
                }

                var standardDeviation = source.StandardDeviation(portfolioReturnSelector);

                return portfolioReturn.SharpeRatio(riskFreeRate, standardDeviation);
            }
        }

        public static double SharpeRatio<TSource>(this IEnumerable<TSource> source, Func<TSource, double> portfolioReturnSelector, Func<TSource, double> riskFreeRateSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (portfolioReturnSelector == null)
            {
                throw new ArgumentNullException(nameof(portfolioReturnSelector));
            }

            if (riskFreeRateSelector == null)
            {
                throw new ArgumentNullException(nameof(riskFreeRateSelector));
            }

            double portfolioReturn = 0;
            double riskFreeRate = 0;

            checked
            {
                foreach (TSource item in source)
                {
                    portfolioReturn = portfolioReturn.AccumulateCompoundInterest(portfolioReturnSelector(item));
                    riskFreeRate = riskFreeRate.AccumulateCompoundInterest(riskFreeRateSelector(item));
                }

                var standardDeviation = source.StandardDeviation(portfolioReturnSelector);

                return portfolioReturn.SharpeRatio(riskFreeRate, standardDeviation);
            }
        }

        public static float SharpeRatio<TSource>(this IEnumerable<TSource> source, Func<TSource, float> portfolioReturnSelector, Func<TSource, float> riskFreeRateSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (portfolioReturnSelector == null)
            {
                throw new ArgumentNullException(nameof(portfolioReturnSelector));
            }

            if (riskFreeRateSelector == null)
            {
                throw new ArgumentNullException(nameof(riskFreeRateSelector));
            }

            float portfolioReturn = 0;
            float riskFreeRate = 0;

            checked
            {
                foreach (TSource item in source)
                {
                    portfolioReturn = portfolioReturn.AccumulateCompoundInterest(portfolioReturnSelector(item));
                    riskFreeRate = riskFreeRate.AccumulateCompoundInterest(riskFreeRateSelector(item));
                }

                var standardDeviation = source.StandardDeviation(portfolioReturnSelector);

                return portfolioReturn.SharpeRatio(riskFreeRate, standardDeviation);
            }
        }

        #endregion

    }
}
