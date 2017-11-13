using System;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal ProrataRate(this decimal interestRate, int basis)
        {
            if (basis == 0)
                throw new DivideByZeroException(nameof(basis));

            return Convert.ToDecimal(Math.Pow(1 + ((double)interestRate / 100), 1 / (double)basis) - 1) * 100;
        }

        public static double ProrataRate(this double interestRate, int basis)
        {
            if (basis == 0)
                throw new DivideByZeroException(nameof(basis));

            return (Math.Pow(1 + interestRate / 100, y: 1 / (double)basis) - 1) * 100;
        }

        public static float ProrataRate(this float interestRate, float basis)
        {
            if (basis == 0)
                throw new DivideByZeroException(nameof(basis));

            return (float)(Math.Pow(1 + interestRate / 100, 1 / basis) - 1) * 100;
        }
        
    }
}
