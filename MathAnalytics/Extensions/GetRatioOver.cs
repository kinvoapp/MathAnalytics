namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal GetRatioOver(this decimal numerator, decimal denominator)
        {
            if (denominator == 0)
                return 0;

            return (numerator / denominator) * 100;
        }

        public static double GetRatioOver(this double numerator, double denominator)
        {
            if (denominator == 0)
                return 0;

            return (numerator / denominator) * 100;
        }

        public static float GetRatioOver(this float numerator, float denominator)
        {
            if (denominator == 0)
                return 0;

            return (numerator / denominator) * 100;
        }
    }
}
