using FluentAssertions;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class GetRatioOverTest
    {

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 108)]
        public void DecimalExtension(decimal numerator, decimal denominator, decimal resultExpected)
        {
            numerator.GetRatioOver(denominator).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 108)]
        public void DoubleExtension(double numerator, double denominator, double resultExpected)
        {
            numerator.GetRatioOver(denominator).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 108.000008)]
        public void FLoatExtension(float numerator, float denominator, float resultExpected)
        {
            numerator.GetRatioOver(denominator).Should().Be(resultExpected);
        }
    }
}
