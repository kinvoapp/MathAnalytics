using System;
using System.Collections.Generic;
using System.Linq;

namespace MathAnalytics
{
    public class LinearRegressionTuple<T1, T2, T3> : Tuple<T1, T2, T3>
    {
        public LinearRegressionTuple(T1 rsquared, T2 yintercept, T3 slope)
                : base(rsquared, yintercept, slope)
        {

        }

        public T1 RSquared { get { return this.Item1; } }
        public T2 YIntercept { get { return this.Item2; } }
        public T3 Slope { get { return this.Item3; } }

    }

    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static LinearRegressionTuple<decimal, decimal, decimal> LinearRegression(this IEnumerable<decimal> xVals, IEnumerable<decimal> yVals)
        {
            if (xVals == null)
            {
                throw new ArgumentNullException(nameof(xVals));
            }

            if (yVals == null)
            {
                throw new ArgumentNullException(nameof(yVals));
            }

            if (xVals.Count() != yVals.Count())
            {
                throw new ArgumentException(nameof(yVals));
            }

            if (xVals.Count() == 0)
            {
                throw new InvalidOperationException(nameof(yVals));
            }

            decimal sumOfX = 0;
            decimal sumOfY = 0;
            decimal sumOfXSq = 0;
            decimal sumOfYSq = 0;
            decimal ssX = 0;
            decimal ssY = 0;
            decimal sumCodeviates = 0;
            decimal sCo = 0;
            decimal count = xVals.Count();

            for (int ctr = 0; ctr < count; ctr++)
            {
                var x = xVals.ElementAt(ctr);
                var y = yVals.ElementAt(ctr);
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }
            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            var RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = Convert.ToDecimal((double)RNumerator / Math.Sqrt((double)RDenom));

            var rsquared = dblR * dblR;
            var yintercept = meanY - ((sCo / ssX) * meanX);
            var slope = sCo / ssX;

            return new LinearRegressionTuple<decimal, decimal, decimal>(rsquared, yintercept, slope);
        }

        public static LinearRegressionTuple<double, double, double> LinearRegression(this IEnumerable<double> xVals, IEnumerable<double> yVals)
        {
            if (xVals == null)
            {
                throw new ArgumentNullException(nameof(xVals));
            }

            if (yVals == null)
            {
                throw new ArgumentNullException(nameof(yVals));
            }

            if (xVals.Count() != yVals.Count())
            {
                throw new ArgumentException(nameof(yVals));
            }

            if (xVals.Count() == 0)
            {
                throw new InvalidOperationException(nameof(yVals));
            }

            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double ssX = 0;
            double ssY = 0;
            double sumCodeviates = 0;
            double sCo = 0;
            double count = xVals.Count();

            for (int ctr = 0; ctr < count; ctr++)
            {
                var x = xVals.ElementAt(ctr);
                var y = yVals.ElementAt(ctr);
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }
            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            var RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = RNumerator / Math.Sqrt(RDenom);

            var rsquared = dblR * dblR;
            var yintercept = meanY - ((sCo / ssX) * meanX);
            var slope = sCo / ssX;

            return new LinearRegressionTuple<double, double, double>(rsquared, yintercept, slope);

        }

        public static LinearRegressionTuple<float, float, float> LinearRegression(this IEnumerable<float> xVals, IEnumerable<float> yVals)
        {
            if (xVals == null)
            {
                throw new ArgumentNullException(nameof(xVals));
            }

            if (yVals == null)
            {
                throw new ArgumentNullException(nameof(yVals));
            }

            if (xVals.Count() != yVals.Count())
            {
                throw new ArgumentException(nameof(yVals));
            }

            if (xVals.Count() == 0)
            {
                throw new InvalidOperationException(nameof(yVals));
            }

            float sumOfX = 0;
            float sumOfY = 0;
            float sumOfXSq = 0;
            float sumOfYSq = 0;
            float ssX = 0;
            float ssY = 0;
            float sumCodeviates = 0;
            float sCo = 0;
            float count = xVals.Count();

            for (int ctr = 0; ctr < count; ctr++)
            {
                var x = xVals.ElementAt(ctr);
                var y = yVals.ElementAt(ctr);
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }
            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            var RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = (float)(RNumerator / Math.Sqrt(RDenom));

            var rsquared = dblR * dblR;
            var yintercept = meanY - ((sCo / ssX) * meanX);
            var slope = sCo / ssX;

            return new LinearRegressionTuple<float, float, float>(rsquared, yintercept, slope);
        }
    }
}
