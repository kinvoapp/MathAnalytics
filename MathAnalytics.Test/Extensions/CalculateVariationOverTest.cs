using Xunit;
using FluentAssertions;

namespace MathAnalytics.Test.Extensions
{
    public class CalculateVariationOverTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 8)]
        public void CalculateVariationOver_Decimal_GivenCurrentValueAndPreviousValue_GrowthPercentageReturned(decimal currentValue, decimal previousValue, decimal resultExpected)
        {
            currentValue.CalculateVariationOver(previousValue).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 8.0000000000000071)]
        public void CalculateVariationOver_Double_GivenCurrentValueAndPreviousValue_GrowthPercentageReturned(double currentValue, double previousValue, double resultExpected)
        {
            currentValue.CalculateVariationOver(previousValue).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 8.000004)]
        public void CalculateVariationOver_Float_GivenCurrentValueAndPreviousValue_GrowthPercentageReturned(float currentValue, float previousValue, float resultExpected)
        {
            currentValue.CalculateVariationOver(previousValue).Should().Be(resultExpected);
        }
    }
}
