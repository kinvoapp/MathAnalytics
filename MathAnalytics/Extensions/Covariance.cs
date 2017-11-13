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

        public static decimal Covariance(this IEnumerable<decimal> measure1, IEnumerable<decimal> measure2)
        {
            if (measure1 == null)
            {
                throw new ArgumentNullException(nameof(measure1));
            }

            if (measure2 == null)
            {
                throw new ArgumentNullException(nameof(measure2));
            }

            if (measure2.Count() != measure2.Count())
            {
                throw new ArgumentException(nameof(measure2));
            }

            checked
            {
                decimal average1 = measure1.Average();
                decimal average2 = measure2.Average();
                int length = measure1.Count();

                if (length == 0)
                    throw new InvalidOperationException(nameof(length));

                decimal sum_mul = 0;

                for (int i = 0; i <= length - 1; i++)
                {
                    sum_mul += measure1.ElementAt(i) * measure2.ElementAt(i);
                }

                return (sum_mul - length * average1 * average2) / (length - 1);
            }

        }

        public static double Covariance(this IEnumerable<double> measure1, IEnumerable<double> measure2)
        {
            if (measure1 == null)
            {
                throw new ArgumentNullException(nameof(measure1));
            }

            if (measure2 == null)
            {
                throw new ArgumentNullException(nameof(measure2));
            }

            if (measure2.Count() != measure2.Count())
            {
                throw new ArgumentException(nameof(measure2));
            }

            checked
            {
                double average1 = measure1.Average();
                double average2 = measure2.Average();
                int length = measure1.Count();

                if (length == 0)
                    throw new InvalidOperationException(nameof(length));

                double sum_mul = 0;

                for (int i = 0; i <= length - 1; i++)
                {
                    sum_mul += measure1.ElementAt(i) * measure2.ElementAt(i);
                }

                return (sum_mul - length * average1 * average2) / (length - 1);
            }

        }

        public static float Covariance(this IEnumerable<float> measure1, IEnumerable<float> measure2)
        {
            if (measure1 == null)
            {
                throw new ArgumentNullException(nameof(measure1));
            }

            if (measure2 == null)
            {
                throw new ArgumentNullException(nameof(measure2));
            }

            if (measure2.Count() != measure2.Count())
            {
                throw new ArgumentException(nameof(measure2));
            }

            checked
            {
                float average1 = measure1.Average();
                float average2 = measure2.Average();
                int length = measure1.Count();

                if (length == 0)
                    throw new InvalidOperationException(nameof(length));

                float sum_mul = 0;

                for (int i = 0; i <= length - 1; i++)
                {
                    sum_mul += measure1.ElementAt(i) * measure2.ElementAt(i);
                }

                return (sum_mul - length * average1 * average2) / (length - 1);
            }
        }

        #endregion

        #region Two TSource properties in IEnumerable<TSource>

        public static decimal Covariance<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector1, Func<TSource, decimal> selector2)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException(nameof(selector1));
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException(nameof(selector1));
            }


            var measure1 = source.Select(selector1);
            var measure2 = source.Select(selector2);

            return measure1.Covariance(measure2);
        }

        public static double Covariance<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector1, Func<TSource, double> selector2)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException(nameof(selector1));
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException(nameof(selector1));
            }

            var measure1 = source.Select(selector1);
            var measure2 = source.Select(selector2);

            return measure1.Covariance(measure2);
        }

        public static float Covariance<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector1, Func<TSource, float> selector2)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException(nameof(selector1));
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException(nameof(selector1));
            }

            var measure1 = source.Select(selector1);
            var measure2 = source.Select(selector2);

            return measure1.Covariance(measure2);

        }


        #endregion
    }
}
