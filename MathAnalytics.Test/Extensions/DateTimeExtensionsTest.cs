using FluentAssertions;
using System;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class DateTimeExtensionsTest
    {
        #region GivenDateAndNumberOfWeeks - NewDateReturned

        [Fact]
        public void AddWeeks_GivenDateAndNumberOfWeeks_NewDateReturned()
        {
            DateTime date = new DateTime(2018, 10, 06);
            int numberOfWeeks = 52;
            DateTime expectedDate = new DateTime(2019, 10, 05);

            date.AddWeeks(numberOfWeeks).Should().Be(expectedDate);
        }

        #endregion
    }
}
