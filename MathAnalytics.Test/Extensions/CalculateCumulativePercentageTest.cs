using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class CalculateCumulativePercentageTest
    {
        private IList<TimeSerie> _dailyGrowth;

        [Fact]
        public void DecimalExtension()
        {
            CreateDailyGrowthList();

            _dailyGrowth
                .OrderBy(x => x.ReferenceDate)
                .CalculateCumulativePercentage(x => x.GrowthRate, (x, cumProf) => x.CumulativeProfitability = cumProf);

            _dailyGrowth[0].CumulativeProfitability.Should().Be(4.6532690000M);
            _dailyGrowth[1].CumulativeProfitability.Should().Be(6.38346905386361M);
            _dailyGrowth[2].CumulativeProfitability.Should().Be(9.2061086593943664664109M);
            _dailyGrowth[3].CumulativeProfitability.Should().Be(16.34020519917575630512547822M);
            _dailyGrowth[4].CumulativeProfitability.Should().Be(22.53753158993064966774320732M);
            
        }

        [Fact]
        public void DoubleExtension()
        {
            //TODO
        }

        [Fact]
        public void FloatExtension()
        {
            //TODO
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
