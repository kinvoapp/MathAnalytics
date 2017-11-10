﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathAnalytics
{
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.
    public static partial class Extensions
    {
        public static decimal SharpeRatio(this decimal portfolioReturn, decimal riskFreeRate, decimal standardDeviationOfPortfolioReturn)
        {
            if (standardDeviationOfPortfolioReturn == 0)
                throw new DivideByZeroException(nameof(standardDeviationOfPortfolioReturn));

            return (portfolioReturn - riskFreeRate) / standardDeviationOfPortfolioReturn;
        }

        public static double SharpeRatio(this double portfolioReturn, double riskFreeRate, double standardDeviationOfPortfolioReturn)
        {
            if (standardDeviationOfPortfolioReturn == 0)
                throw new DivideByZeroException(nameof(standardDeviationOfPortfolioReturn));

            return (portfolioReturn - riskFreeRate) / standardDeviationOfPortfolioReturn;
        }

        public static float SharpeRatio(this float portfolioReturn, float riskFreeRate, float standardDeviationOfPortfolioReturn)
        {
            if (standardDeviationOfPortfolioReturn == 0)
                throw new DivideByZeroException(nameof(standardDeviationOfPortfolioReturn));

            return (portfolioReturn - riskFreeRate) / standardDeviationOfPortfolioReturn;
        }
    }
}
