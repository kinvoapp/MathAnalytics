using Xunit;
using FluentAssertions;

namespace MathAnalytics.Test.Extensions
{
    public class GetGrowthPercentageOverTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 8)]
        public void DecimalExtension(decimal currentValue, decimal previousValue, decimal resultExpected)
        {
            currentValue.GetGrowthPercentageOver(previousValue).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 8.0000000000000071)]
        public void DoubleExtension(double currentValue, double previousValue, double resultExpected)
        {
            currentValue.GetGrowthPercentageOver(previousValue).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 8.000004)]
        public void FloatExtension(float currentValue, float previousValue, float resultExpected)
        {
            currentValue.GetGrowthPercentageOver(previousValue).Should().Be(resultExpected);
        }
    }
}
