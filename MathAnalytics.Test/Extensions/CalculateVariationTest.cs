using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class CalculateVariationTest
    {
        private IList<TimeSerie> _sampleTimeSerie;

        [Fact]
        public void DecimalExtension()
        {
            CreateDailyGrowthList();

            var resultList = _sampleTimeSerie
                                .OrderBy(x => x.ReferenceDate)
                                .CalculateVariation(
                                    x => x.Value,
                                    (x, v) => new
                                    {
                                        Date = x.ReferenceDate,
                                        Variation = v
                                    })
                                .ToList();

            resultList[0].Variation.Should().Be(0M);
            resultList[1].Variation.Should().Be(-26.674844581240951114701742780M);
            resultList[2].Variation.Should().Be(-24.252563283729161439734017290M);
            resultList[3].Variation.Should().Be(-48.026502945385381468909803190M);
            resultList[4].Variation.Should().Be(-24.057561393614331023908141290M);
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
            _sampleTimeSerie = new List<TimeSerie>();

            TimeSerie _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 01), 11.246551M);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 03), 8.246551M);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 07), 6.246551M);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 12), 3.246551M);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie(new DateTime(2012, 01, 13), 2.46551M);
            _sampleTimeSerie.Add(_dailyGrowthObject);

        }
    }
}
