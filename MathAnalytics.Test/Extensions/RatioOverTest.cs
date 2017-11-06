using FluentAssertions;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class RatioOverTest
    {

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 1.08)]
        public void RatioOver_Decimal_GivenNumeratorAndDenominator_RatioReturned(decimal numerator, decimal denominator, decimal resultExpected)
        {
            numerator.RatioOver(denominator).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 1.08)]
        public void RatioOver_Double_GivenNumeratorAndDenominator_RatioReturned(double numerator, double denominator, double resultExpected)
        {
            numerator.RatioOver(denominator).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10.8, 10, 1.08000008)]
        public void RatioOver_Float_GivenNumeratorAndDenominator_RatioReturned(float numerator, float denominator, float resultExpected)
        {
            numerator.RatioOver(denominator).Should().Be(resultExpected);
        }
    }
}
