using System;

namespace MathAnalytics
{

    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal Payment(this decimal presentValue, decimal interestRate, int numPeriods)
        {
            if (interestRate == 0)
            {
                return -presentValue / numPeriods;
            }

            decimal payment = (interestRate * presentValue) / (1 - (decimal)Math.Pow((double)(1 + interestRate), -numPeriods));

            return -payment;
        }

        public static double Payment(this double presentValue, double interestRate, int numPeriods)
        {
            if (interestRate == 0)
            {
                return -presentValue / numPeriods;
            }

            double payment = interestRate * presentValue / (1 - Math.Pow(1 + interestRate, -numPeriods));

            return -payment;
        }

        public static float Payment(this float presentValue, float interestRate, int numPeriods)
        {
            if (interestRate == 0)
            {
                return -presentValue / numPeriods;
            }

            float payment = (interestRate * presentValue) / (1 - (float)Math.Pow((double)(1 + interestRate), -numPeriods));

            return -payment;
        }

    }
}
