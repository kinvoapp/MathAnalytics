using Xunit;
using FluentAssertions;
using System;

namespace MathAnalytics.Test.Extensions
{
    public class CalculateVariationOverTest
    {
        #region PreviousValueIsZero DivideByZeroExceptionThrown

        [Fact]
        public void CalculateVariationOverDecimal_PreviousValueIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                decimal currentValue = 1M;

                currentValue.CalculateVariationOver(0M);

            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void CalculateVariationOverDouble_PreviousValueIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                double currentValue = 1;

                currentValue.CalculateVariationOver(0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void CalculateVariationOverFloat_PreviousValueIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                float currentValue = 1;

                currentValue.CalculateVariationOver(0F);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion

        #region GivenCurrentValueAndPreviousValue - GrowthPercentageReturned

        [Theory]
        [InlineData(10.8, 10, 8)]
        public void CalculateVariationOverDecimal_GivenCurrentValueAndPreviousValue_GrowthPercentageReturned(decimal currentValue, decimal previousValue, decimal resultExpected)
        {
            currentValue.CalculateVariationOver(previousValue).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10.8, 10, 8.0000000000000071)]
        public void CalculateVariationOverDouble_GivenCurrentValueAndPreviousValue_GrowthPercentageReturned(double currentValue, double previousValue, double resultExpected)
        {
            currentValue.CalculateVariationOver(previousValue).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10.8, 10, 8.000004)]
        public void CalculateVariationOverFloat_GivenCurrentValueAndPreviousValue_GrowthPercentageReturned(float currentValue, float previousValue, float resultExpected)
        {
            currentValue.CalculateVariationOver(previousValue).Should().Be(resultExpected);
        }

        #endregion
    }
}
