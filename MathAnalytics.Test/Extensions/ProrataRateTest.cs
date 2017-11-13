using FluentAssertions;
using System;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class ProrataRateTest
    {
        #region NumberOfDaysIsZero DivideByZeroExceptionThrown

        [Fact]
        public void ProrataRateOfDecimal_NumberOfDaysIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                16M.ProrataRate(0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void ProrataRateOfDouble_NumberOfDaysIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                ((double)16).ProrataRate(0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void ProrataRateOfFloat_NumberOfDaysIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                ((float)16).ProrataRate(0);

            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion

        #region GivenValueAndInterestRateAndDays - ProrataRateReturned

        [Theory]
        [InlineData(16, 252, 0.0589141750148459)]
        public void ProrataRateOfDecimal_GivenValueAndInterestRateAndDays_ProrataRateReturned(decimal interestRate, int days, decimal resultExpected)
        {
            interestRate.ProrataRate(days).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(16, 252, 0.05891417501484586)]
        public void ProrataRateOfDouble_GivenValueAndInterestRateAndDays_ProrataRateReturned(double interestRate, int days, double resultExpected)
        {
            interestRate.ProrataRate(days).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(16, 252, 0.05891417)]
        public void ProrataRateOfFloat_GivenValueAndInterestRateAndDays_ProrataRateReturned(float interestRate, int days, float resultExpected)
        {
            interestRate.ProrataRate(days).Should().Be(resultExpected);
        }

        #endregion
    }
}
