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
        #region Two IEnumerable<scalar> lists

        public static decimal Beta(this IEnumerable<decimal> marketReturns, IEnumerable<decimal> assetReturns)
        {
            if (marketReturns == null)
            {
                throw new ArgumentNullException(nameof(marketReturns));
            }

            if (assetReturns == null)
            {
                throw new ArgumentNullException(nameof(assetReturns));
            }

            if (assetReturns.Count() != assetReturns.Count())
            {
                throw new ArgumentException(nameof(assetReturns));
            }

            return marketReturns.Covariance(assetReturns) / marketReturns.Variance(x => x);
        }

        public static double Beta(this IEnumerable<double> marketReturns, IEnumerable<double> assetReturns)
        {
            if (marketReturns == null)
            {
                throw new ArgumentNullException(nameof(marketReturns));
            }

            if (assetReturns == null)
            {
                throw new ArgumentNullException(nameof(assetReturns));
            }

            if (assetReturns.Count() != assetReturns.Count())
            {
                throw new ArgumentException(nameof(assetReturns));
            }

            return marketReturns.Covariance(assetReturns) / marketReturns.Variance(x => x);


        }

        public static float Beta(this IEnumerable<float> marketReturns, IEnumerable<float> assetReturns)
        {
            if (marketReturns == null)
            {
                throw new ArgumentNullException(nameof(marketReturns));
            }

            if (assetReturns == null)
            {
                throw new ArgumentNullException(nameof(assetReturns));
            }

            if (assetReturns.Count() != assetReturns.Count())
            {
                throw new ArgumentException(nameof(assetReturns));
            }

            return marketReturns.Covariance(assetReturns) / marketReturns.Variance(x => x);

        }

        #endregion

        #region Two TSource properties in IEnumerable<TSource>

        public static decimal Beta<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selectorMarketReturns, Func<TSource, decimal> selectorAssetReturns)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selectorMarketReturns == null)
            {
                throw new ArgumentNullException(nameof(selectorMarketReturns));
            }

            if (selectorMarketReturns == null)
            {
                throw new ArgumentNullException(nameof(selectorMarketReturns));
            }


            var marketReturns = source.Select(selectorMarketReturns);
            var assetReturns = source.Select(selectorAssetReturns);

            return marketReturns.Beta(assetReturns);
        }

        public static double Beta<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selectorMarketReturns, Func<TSource, double> selectorAssetReturns)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selectorMarketReturns == null)
            {
                throw new ArgumentNullException(nameof(selectorMarketReturns));
            }

            if (selectorMarketReturns == null)
            {
                throw new ArgumentNullException(nameof(selectorMarketReturns));
            }

            var marketReturns = source.Select(selectorMarketReturns);
            var assetReturns = source.Select(selectorAssetReturns);

            return marketReturns.Beta(assetReturns);
        }

        public static float Beta<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selectorMarketReturns, Func<TSource, float> selectorAssetReturns)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selectorMarketReturns == null)
            {
                throw new ArgumentNullException(nameof(selectorMarketReturns));
            }

            if (selectorMarketReturns == null)
            {
                throw new ArgumentNullException(nameof(selectorMarketReturns));
            }

            var marketReturns = source.Select(selectorMarketReturns);
            var assetReturns = source.Select(selectorAssetReturns);

            return marketReturns.Beta(assetReturns);
        }


        #endregion
    }
}
