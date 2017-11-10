using System;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal CalculateVariationOver(this decimal currentValue, decimal previousValue)
        {
            if (previousValue == 0)
                throw new DivideByZeroException(nameof(previousValue));

            return ((currentValue / previousValue) - 1) * 100;
        }

        public static double CalculateVariationOver(this double currentValue, double previousValue)
        {
            if (previousValue == 0)
                throw new DivideByZeroException(nameof(previousValue));

            return ((currentValue / previousValue) - 1) * 100;
        }

        public static float CalculateVariationOver(this float currentValue, float previousValue)
        {
            if (previousValue == 0)
                throw new DivideByZeroException(nameof(previousValue));

            return ((currentValue / previousValue) - 1) * 100;
        }

    }
}
