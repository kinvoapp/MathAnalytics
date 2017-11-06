using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class GetCumulativePercentageTest
    {
        private IList<TimeSerie> _dailyGrowth;

        [Fact]
        public void DecimalExtension()
        {
            CreateDailyGrowthList();

            _dailyGrowth
                .OrderBy(x => x.ReferenceDate)
                .GetCumulativePercentage(x => x.GrowthRate).Should().Be(22.537531589930649667743207320M);
        }

        [Fact]
        public void DoubleExtension()
        {
            CreateDailyGrowthList();

            _dailyGrowth
                .OrderBy(x => x.ReferenceDate)
                .GetCumulativePercentage(x => (double)x.GrowthRate).Should().Be(22.53753158993068);
        }

        [Fact]
        public void FloatExtension()
        {
            CreateDailyGrowthList();

            _dailyGrowth
                .OrderBy(x => x.ReferenceDate)
                .GetCumulativePercentage(x => (float)x.GrowthRate).Should().Be(22.537529F);
        }


        private void CreateDailyGrowthList()
        {
            _dailyGrowth = new List<TimeSerie>();

            TimeSerie _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 01), 11.246551M);
            _dailyGrowthObject.GrowthRate = 4.6532690000M;
            _dailyGrowth.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 03), 8.246551M);
            _dailyGrowthObject.GrowthRate = 1.6532690000M;
            _dailyGrowth.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 07), 6.246551M);
            _dailyGrowthObject.GrowthRate = 2.6532690000M;
            _dailyGrowth.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 12), 3.246551M);
            _dailyGrowthObject.GrowthRate = 6.532690000M;
            _dailyGrowth.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 12), 2.46551M);
            _dailyGrowthObject.GrowthRate = 5.32690000M;
            _dailyGrowth.Add(_dailyGrowthObject);

        }

    }
}
