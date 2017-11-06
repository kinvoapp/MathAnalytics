using MathAnalytics.Structs;
using System;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static int AmountOfMonthsUntil(this DateTime initialMonthlyReference, DateTime finalMonthlyReference)
        {
            return DateTimeSpan.CompareDates(initialMonthlyReference, finalMonthlyReference).Months;
        }
    }
}
