using FluentAssertions;
using System;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class GetAmountOfMonthsUntilTest
    {
        [Fact]
        public void DateTimeExtension()
        {
            DateTime initialMonthlyReference = new DateTime(2017, 01, 01);

            initialMonthlyReference.GetAmountOfMonthsUntil(new DateTime(2017, 12, 01)).Should().Be(11);

            initialMonthlyReference.GetAmountOfMonthsUntil(initialMonthlyReference).Should().Be(0);
        }
    }
}
