using System;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal CalculateCompoundInterest(this decimal principal, decimal interestRate, int numberOfPoints)
        {
            decimal convertedInterestRate = 1 + (interestRate / 100M);
            double index = Convert.ToDouble(convertedInterestRate);

            var profitability = Math.Pow(index, Convert.ToDouble(numberOfPoints));

            return (Convert.ToDecimal(profitability) * principal);
        }

        public static double CalculateCompoundInterest(this double principal, double interestRate, int numberOfPoints)
        {
            double convertedInterestRate = 1 + (interestRate / 100);
            double index = convertedInterestRate;

            var profitability = Math.Pow(index, Convert.ToDouble(numberOfPoints));

            return profitability * principal;
        }

        public static float CalculateCompoundInterest(this float principal, float interestRate, int numberOfPoints)
        {
            float convertedInterestRate = 1 + (interestRate / 100);
            double index = Convert.ToDouble(convertedInterestRate);

            var profitability = Math.Pow(index, Convert.ToDouble(numberOfPoints));

            return ((float)profitability * principal);
        }
    }
}
