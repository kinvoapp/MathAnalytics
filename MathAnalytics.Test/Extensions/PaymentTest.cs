using FluentAssertions;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class PaymentTest
    {
        #region GivenPresentValueAndInterestRateAndNumberOfPeriods - PaymentReturned

        [Theory]
        [InlineData(-436750.00, 0.0099981303892207, 144, 5735.76)]
        public void PaymentOfDecimal_GivenPresentValueAndInterestRateAndNumberOfPeriods_PaymentReturnedReturned(decimal presentValue, decimal interestRate, int numberOfPeriods, decimal resultExpected)
        {
            presentValue.Payment(interestRate, numberOfPeriods).Should().BeApproximately(resultExpected, 0.01M);
        }

        [Theory]
        [InlineData(-436750.00, 0.0099981303892207, 144, 5735.76)]
        public void PaymentOfDouble_GivenPresentValueAndInterestRateAndNumberOfPeriods_PaymentReturnedReturned(double presentValue, double interestRate, int numberOfPeriods, double resultExpected)
        {
            presentValue.Payment(interestRate, numberOfPeriods).Should().BeApproximately(resultExpected, 0.01);
        }

        [Theory]
        [InlineData(-436750.00, 0.0099981303892207, 144, 5735.76)]
        public void PaymentOfFloat_GivenPresentValueAndInterestRateAndNumberOfPeriods_PaymentReturnedReturned(float presentValue, float interestRate, int numberOfPeriods, float resultExpected)
        {
            presentValue.Payment(interestRate, numberOfPeriods).Should().BeApproximately(resultExpected, 0.018F);
        }

        #endregion
    }
}
