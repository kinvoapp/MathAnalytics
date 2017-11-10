using System;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal RatioOver(this decimal numerator, decimal denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException(nameof(denominator));

            return (numerator / denominator);
        }

        public static double RatioOver(this double numerator, double denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException(nameof(denominator));

            return (numerator / denominator);
        }

        public static float RatioOver(this float numerator, float denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException(nameof(denominator));

            return (numerator / denominator);
        }
    }
}
