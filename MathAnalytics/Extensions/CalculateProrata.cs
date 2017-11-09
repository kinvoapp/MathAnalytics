using System;
using System.Collections.Generic;
using System.Text;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal CalculateProrata(this decimal value, decimal interestRate, int days)
        {
            if (days == 0)
                return 0;

            return Convert.ToDecimal(Math.Pow(1 + ((double)interestRate / 100), 1 / (double)days) - 1) * 100;
        }

        public static double CalculateProrata(this double value, double interestRate, int days)
        {
            if (days == 0)
                return 0;

            return (Math.Pow(1 + interestRate / 100, 1 / (double)days) - 1) * 100;
        }

        public static float CalculateProrata(this float value, float interestRate, int days)
        {
            if (days == 0)
                return 0;

            return (float)(Math.Pow(1 + ((double)interestRate / 100), 1 / (double)days) - 1) * 100;
        }
    }
}
