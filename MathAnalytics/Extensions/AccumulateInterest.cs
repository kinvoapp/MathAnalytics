namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal AccumulateInterest(this decimal cumulativeInterest, decimal currentInterest)
        {
            return (((1 + (cumulativeInterest / 100)) * (1 + (currentInterest / 100))) - 1) * 100;
        }

        public static double AccumulateInterest(this double cumulativeInterest, double currentInterest)
        {
            return (((1 + (cumulativeInterest / 100)) * (1 + (currentInterest / 100))) - 1) * 100;
        }

        public static float AccumulateInterest(this float cumulativeInterest, float currentInterest)
        {
            return (((1 + (cumulativeInterest / 100)) * (1 + (currentInterest / 100))) - 1) * 100;
        }
    }
}
