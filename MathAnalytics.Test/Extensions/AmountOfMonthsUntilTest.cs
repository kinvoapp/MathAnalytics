using FluentAssertions;
using System;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class AmountOfMonthsUntilTest
    {
        [Fact]
        public void AmountOfMonthsBetweenDates_DifferentDates_NumberOfMonthsReturned()
        {
            DateTime initialMonthlyReference = new DateTime(2017, 01, 01);

            initialMonthlyReference.AmountOfMonthsUntil(new DateTime(2017, 12, 01)).Should().Be(11);
        }

        [Fact]
        public void AmountOfMonthsBetweenDates_SameDate_ZeroReturned()
        {
            DateTime monthlyReference = new DateTime(2017, 01, 01);

            monthlyReference.AmountOfMonthsUntil(monthlyReference).Should().Be(0);
        }

        [Fact]
        public void AmountOfMonthsBetweenDates_InitialDateGreaterThanFinalDate_NumberOfMonthsReturned()
        {
            DateTime initialMonthlyReference = new DateTime(2017, 12, 01);

            initialMonthlyReference.AmountOfMonthsUntil(new DateTime(2017, 01, 01)).Should().Be(11);
        }
    }
}
