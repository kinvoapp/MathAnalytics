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
        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void CalculateVariation_DecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .CalculateVariation(
                         x => x.GrowthRate,
                         (x, v) => new
                         {
                             Date = x.ReferenceDate,
                             Variation = v
                         });

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CalculateVariation_DoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .CalculateVariation(
                         x => x.GrowthRate,
                         (x, v) => new
                         {
                             Date = x.ReferenceDate,
                             Variation = v
                         });

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CalculateVariation_FloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .CalculateVariation(
                         x => x.GrowthRate,
                         (x, v) => new
                         {
                             Date = x.ReferenceDate,
                             Variation = v
                         });

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void CalculateVariation_DecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            Func<TimeSerie<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                        .OrderBy(x => x.ReferenceDate)
                        .CalculateVariation(
                            selector,
                            (x, v) => new
                            {
                                Date = x.ReferenceDate,
                                Variation = v
                            })
                         .ToList();

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CalculateVariation_DoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            Func<TimeSerie<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                        .OrderBy(x => x.ReferenceDate)
                        .CalculateVariation(
                            selector,
                            (x, v) => new
                            {
                                Date = x.ReferenceDate,
                                Variation = v
                            })
                         .ToList();

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CalculateVariation_FloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            Func<TimeSerie<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                        .OrderBy(x => x.ReferenceDate)
                        .CalculateVariation(
                            selector,
                            (x, v) => new
                            {
                                Date = x.ReferenceDate,
                                Variation = v
                            })
                         .ToList();

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - ZeroReturned

        [Fact]
        public void CalculateVariation_DecimalProperty_SourceIsEmptyCollection_EmptyCollectionReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = new List<TimeSerie<decimal>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .CalculateVariation(
                                    x => x.GrowthRate,
                                    (x, v) => new
                                    {
                                        Date = x.ReferenceDate,
                                        Variation = v
                                    })
                                .ToList();

            resultList.Any().Should().BeFalse();
        }

        [Fact]
        public void CalculateVariation_DoubleProperty_SourceIsEmptyCollection_EmptyCollectionReturned()
        {
            IEnumerable<TimeSerie<double>> source = new List<TimeSerie<double>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .CalculateVariation(
                                    x => x.GrowthRate,
                                    (x, v) => new
                                    {
                                        Date = x.ReferenceDate,
                                        Variation = v
                                    })
                                .ToList();

            resultList.Any().Should().BeFalse();
        }

        [Fact]
        public void CalculateVariation_FloatProperty_SourceIsEmptyCollection_EmptyCollectionReturned()
        {
            IEnumerable<TimeSerie<float>> source = new List<TimeSerie<float>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .CalculateVariation(
                                    x => x.GrowthRate,
                                    (x, v) => new
                                    {
                                        Date = x.ReferenceDate,
                                        Variation = v
                                    })
                                .ToList();

            resultList.Any().Should().BeFalse();
        }

        #endregion

        #region SourceIsNotEmpty - ProperVariationReturned

        [Fact]
        public void CalculateVariation_DecimalProperty_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            var resultList = source
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
        public void CalculateVariation_DoubleProperty_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .CalculateVariation(
                                    x => x.Value,
                                    (x, v) => new
                                    {
                                        Date = x.ReferenceDate,
                                        Variation = v
                                    })
                                .ToList();

            resultList[0].Variation.Should().Be(0);
            resultList[1].Variation.Should().Be(-26.674844581240954);
            resultList[2].Variation.Should().Be(-24.252563283729156);
            resultList[3].Variation.Should().Be(-48.026502945385388);
            resultList[4].Variation.Should().Be(-24.057561393614336);

        }

        [Fact]
        public void CalculateVariation_FloatProperty_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .CalculateVariation(
                                    x => x.Value,
                                    (x, v) => new
                                    {
                                        Date = x.ReferenceDate,
                                        Variation = v
                                    })
                                .ToList();

            resultList[0].Variation.Should().Be(0);
            resultList[1].Variation.Should().Be(-26.6748428F);
            resultList[2].Variation.Should().Be(-24.2525578F);
            resultList[3].Variation.Should().Be(-48.0265F);
            resultList[4].Variation.Should().Be(-24.0575676F);
        }

        #endregion
    }
}
