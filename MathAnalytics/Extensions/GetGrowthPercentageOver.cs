namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal GetGrowthPercentageOver(this decimal currentValue, decimal previousValue)
        {
            if (previousValue == 0)
                return 0;

            return ((currentValue / previousValue) - 1) * 100;
        }

        public static double GetGrowthPercentageOver(this double currentValue, double previousValue)
        {
            if (previousValue == 0)
                return 0;

            return ((currentValue / previousValue) - 1) * 100;
        }

        public static float GetGrowthPercentageOver(this float currentValue, float previousValue)
        {
            if (previousValue == 0)
                return 0;

            return ((currentValue / previousValue) - 1) * 100;
        }

    }
}
