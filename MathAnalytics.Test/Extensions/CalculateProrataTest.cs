using FluentAssertions;
using System;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class CalculateProrataTest
    {
        #region NumberOfDaysIsZero DivideByZeroExceptionThrown

        [Fact]
        public void CalculateProrataOfDecimal_NumberOfDaysIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                decimal value = 1M;

                value.CalculateProrata(16M, 0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void CalculateProrataOfDouble_NumberOfDaysIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                double value = 1;

                value.CalculateProrata(16, 0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void CalculateProrataOfFloat_NumberOfDaysIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                float value = 1F;

                value.CalculateProrata(16F, 0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion

        #region GivenValueAndInterestRateAndDays - ProrataRateReturned

        [Theory]
        [InlineData(10000, 16, 252, 0.0589141750148459)]
        public void CalculateProrataOfDecimal_GivenValueAndInterestRateAndDays_ProrataRateReturned(decimal value, decimal interestRate, int days, decimal resultExpected)
        {
            value.CalculateProrata(interestRate, days).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10000, 16, 252, 0.05891417501484586)]
        public void CalculateProrataOfDouble_GivenValueAndInterestRateAndDays_ProrataRateReturned(double value, double interestRate, int days, double resultExpected)
        {
            value.CalculateProrata(interestRate, days).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10000, 16, 252, 0.0589141750148459)]
        public void CalculateProrataOfFloat_GivenValueAndInterestRateAndDays_ProrataRateReturned(float value, float interestRate, int days, float resultExpected)
        {
            value.CalculateProrata(interestRate, days).Should().Be(resultExpected);
        }

        #endregion
    }
}
