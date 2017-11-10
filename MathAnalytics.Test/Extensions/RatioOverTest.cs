using FluentAssertions;
using System;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class RatioOverTest
    {
        #region DenominatorIsZero DivideByZeroExceptionThrown

        [Fact]
        public void RatioOverDecimal_DenominatorIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                decimal numerator = 1M;

                numerator.RatioOver(0M);

            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void RatioOverDouble_DenominatorIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                double numerator = 1;

                numerator.RatioOver(0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void RatioOverFloat_DenominatorIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                float numerator = 1;

                numerator.RatioOver(0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion

        #region GivenNumeratorAndDenominator - RatioReturned

        [Theory]
        [InlineData(10.8, 10, 1.08)]
        public void RatioOverDecimal_GivenNumeratorAndDenominator_RatioReturned(decimal numerator, decimal denominator, decimal resultExpected)
        {
            numerator.RatioOver(denominator).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10.8, 10, 1.08)]
        public void RatioOverDouble_GivenNumeratorAndDenominator_RatioReturned(double numerator, double denominator, double resultExpected)
        {
            numerator.RatioOver(denominator).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10.8, 10, 1.08000008)]
        public void RatioOverFloat_GivenNumeratorAndDenominator_RatioReturned(float numerator, float denominator, float resultExpected)
        {
            numerator.RatioOver(denominator).Should().Be(resultExpected);
        }

        #endregion
    }
}
