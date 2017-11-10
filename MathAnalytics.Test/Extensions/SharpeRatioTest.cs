using FluentAssertions;
using System;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class SharpeRatioTest
    {
        #region StandardDeviationIsZero DivideByZeroExceptionThrown

        [Fact]
        public void SharpeRatioOfDecimal_StandardDeviationIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                decimal portfolioReturn = 16M;
                decimal riskFreeRate = 11M;

                portfolioReturn.SharpeRatio(riskFreeRate, 0M);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void SharpeRatioOfDouble_StandardDeviationIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                double portfolioReturn = 16;
                double riskFreeRate = 11;

                portfolioReturn.SharpeRatio(riskFreeRate, 0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void SharpeRatioOfFloat_StandardDeviationIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                float portfolioReturn = 16F;
                float riskFreeRate = 11F;

                portfolioReturn.SharpeRatio(riskFreeRate, 0F);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion

        #region SourceIsNotZero - SharpeRationReturned

        [Theory]
        [InlineData(0.1889, 0.1108, 0.1008, 0.77480159)]
        [InlineData(0, 0.1108, 0.1008, -1.09920635)]
        [InlineData(0.1889, 0, 0.1008, 1.87400794)]
        public void SharpeRatioOfDecimal_SourceIsNotZero_SharpeRationReturned(decimal portfolioReturn, decimal riskFreeRate, decimal standardDeviationOfPortfolioReturn, decimal resultExpected)
        {
            Math.Round(portfolioReturn.SharpeRatio(riskFreeRate, standardDeviationOfPortfolioReturn), 8).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0.1889, 0.1108, 0.1008, 0.77480159)]
        [InlineData(0, 0.1108, 0.1008, -1.09920635)]
        [InlineData(0.1889, 0, 0.1008, 1.87400794)]
        public void SharpeRatioOfDouble_SourceIsNotZero_SharpeRationReturned(double portfolioReturn, double riskFreeRate, double standardDeviationOfPortfolioReturn, double resultExpected)
        {
            Math.Round(portfolioReturn.SharpeRatio(riskFreeRate, standardDeviationOfPortfolioReturn), 8).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0.1889, 0.1108, 0.1008, 0.77480155)]
        [InlineData(0, 0.1108, 0.1008, -1.09920633)]
        [InlineData(0.1889, 0, 0.1008, 1.87400782)]
        public void SharpeRatioOfFloat_SourceIsNotZero_SharpeRationReturned(float portfolioReturn, float riskFreeRate, float standardDeviationOfPortfolioReturn, float resultExpected)
        {
            portfolioReturn.SharpeRatio(riskFreeRate, standardDeviationOfPortfolioReturn).Should().Be(resultExpected);
        }

        #endregion
    }
}
