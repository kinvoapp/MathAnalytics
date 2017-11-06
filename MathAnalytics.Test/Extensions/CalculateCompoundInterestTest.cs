using FluentAssertions;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class CalculateCompoundInterestTest
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10000, 1.5, 50, 21052.4242060746)]
        public void CalculateCompoundInterest_Decimal_GivenPrincipalAndInterestRateAndNumberOfPoints_CompoundInterestReturned(decimal principal, decimal interestRate, int numberOfPoints, decimal resultExpected)
        {
            principal.CalculateCompoundInterest(interestRate, numberOfPoints).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10000, 1.5, 50, 21052.424206074647)]
        public void CalculateCompoundInterest_Double_GivenPrincipalAndInterestRateAndNumberOfPoints_CompoundInterestReturned(double principal, double interestRate, int numberOfPoints, double resultExpected)
        {
            principal.CalculateCompoundInterest(interestRate, numberOfPoints).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10000, 1.5, 50, 21052.4082)]
        public void CalculateCompoundInterest_Float_GivenPrincipalAndInterestRateAndNumberOfPoints_CompoundInterestReturned(float principal, float interestRate, int numberOfPoints, float resultExpected)
        {
            principal.CalculateCompoundInterest(interestRate, numberOfPoints).Should().Be(resultExpected);
        }
    }
}
