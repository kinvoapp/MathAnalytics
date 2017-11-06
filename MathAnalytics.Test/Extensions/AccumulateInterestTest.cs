using FluentAssertions;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class AccumulateInterestTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1.5, 15, 16.72500)]
        public void DecimalExtension(decimal currentInterest, decimal cumulativeInterest, decimal resultExpected)
        {
            cumulativeInterest.AccumulateInterest(currentInterest).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1.5, 15, 16.724999999999991)]
        public void DoubleExtension(double currentInterest, double cumulativeInterest, double resultExpected)
        {
            cumulativeInterest.AccumulateInterest(currentInterest).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1.5, 15, 16.72499)]
        public void FloatExtension(float currentInterest, float cumulativeInterest, float resultExpected)
        {
            cumulativeInterest.AccumulateInterest(currentInterest).Should().Be(resultExpected);
        }
    }
}
