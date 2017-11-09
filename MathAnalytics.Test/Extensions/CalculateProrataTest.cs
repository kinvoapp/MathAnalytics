using FluentAssertions;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class CalculateProrataTest
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10000, 16, 252, 0.0589141750148459)]
        public void CalculateProrata_Decimal_GivenValueAndInterestRateAndDays_ProrataRateReturned(decimal value, decimal interestRate, int days, decimal resultExpected)
        {
            value.CalculateProrata(interestRate, days).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10000, 16, 252, 0.05891417501484586)]
        public void CalculateProrata_Double_GivenValueAndInterestRateAndDays_ProrataRateReturned(double value, double interestRate, int days, double resultExpected)
        {
            value.CalculateProrata(interestRate, days).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10000, 16, 252, 0.0589141750148459)]
        public void CalculateProrata_Float_GivenValueAndInterestRateAndDays_ProrataRateReturned(float value, float interestRate, int days, float resultExpected)
        {
            value.CalculateProrata(interestRate, days).Should().Be(resultExpected);
        }
    }
}
