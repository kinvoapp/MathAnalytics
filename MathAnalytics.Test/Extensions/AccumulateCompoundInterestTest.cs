using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class AccumulateCompoundInterestTest
    {
        #region AccumulateCompoundInterest scalar to scalar

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1.5, 15, 16.72500)]
        public void AccumulateCompoundInterest_ScalarToScalar_Decimal_GivenCumulativeInterestAndCurrentInterest_NewCumulativeInterestReturned(decimal currentInterest, decimal cumulativeInterest, decimal resultExpected)
        {
            cumulativeInterest.AccumulateCompoundInterest(currentInterest).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1.5, 15, 16.724999999999991)]
        public void AccumulateCompoundInterest_ScalarToScalar_Double_GivenCumulativeInterestAndCurrentInterest_NewCumulativeInterestReturned(double currentInterest, double cumulativeInterest, double resultExpected)
        {
            cumulativeInterest.AccumulateCompoundInterest(currentInterest).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1.5, 15, 16.72499)]
        public void AccumulateCompoundInterest_ScalarToScalar_Float_GivenCumulativeInterestAndCurrentInterest_NewCumulativeInterestReturned(float currentInterest, float cumulativeInterest, float resultExpected)
        {
            cumulativeInterest.AccumulateCompoundInterest(currentInterest).Should().Be(resultExpected);
        }

        #endregion

        #region AccumulateCompoundInterest IEnumerable to scalar

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .AccumulateCompoundInterest(x => x.GrowthRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .AccumulateCompoundInterest(x => x.GrowthRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_FloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .AccumulateCompoundInterest(x => x.GrowthRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }
        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            Func<TimeSerie<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .AccumulateCompoundInterest(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            Func<TimeSerie<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .AccumulateCompoundInterest(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_FloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            Func<TimeSerie<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .AccumulateCompoundInterest(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - ZeroReturned

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DecimalProperty_SourceIsEmptyCollection_ZeroReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = new List<TimeSerie<decimal>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(x => x.GrowthRate);

            resultList.Should().Be(0M);
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DoubleProperty_SourceIsEmptyCollection_ZeroReturned()
        {
            IEnumerable<TimeSerie<double>> source = new List<TimeSerie<double>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(x => x.GrowthRate);

            resultList.Should().Be(0);
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_FloatProperty_SourceIsEmptyCollection_ZeroReturned()
        {
            IEnumerable<TimeSerie<float>> source = new List<TimeSerie<float>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(x => x.GrowthRate);

            resultList.Should().Be(0F);
        }

        #endregion

        #region SourceIsNotEmpty - ProperCumulativePercentageReturned

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_Decimal_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            source
                .OrderBy(x => x.ReferenceDate)
                .AccumulateCompoundInterest(x => x.GrowthRate).Should().Be(22.537531589930649667743207320M);
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_Double_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            source
                .OrderBy(x => x.ReferenceDate)
                .AccumulateCompoundInterest(x => x.GrowthRate).Should().Be(22.53753158993068);
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_Float_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            source
                .OrderBy(x => x.ReferenceDate)
                .AccumulateCompoundInterest(x => x.GrowthRate).Should().Be(22.537529F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DecimalProperty_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = new TimeSerie<decimal>[] {
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), 1M) { GrowthRate = decimal.MaxValue },
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), 1M) { GrowthRate = decimal.MaxValue }
            };

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .AccumulateCompoundInterest(x => x.GrowthRate);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_DoubleProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<TimeSerie<double>> source = new TimeSerie<double>[] {
                new TimeSerie<double>(new DateTime(2012, 01, 01), 1) { GrowthRate = double.MaxValue },
                new TimeSerie<double>(new DateTime(2012, 01, 01), 1) { GrowthRate = double.MaxValue }
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .AccumulateCompoundInterest(x => x.GrowthRate);

            double.IsPositiveInfinity(result).Should().BeTrue();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToScalar_FloatProperty_SourceCumulativePercentageToOverflow_InfinityReturned()
        {
            IEnumerable<TimeSerie<float>> source = new TimeSerie<float>[] {
                new TimeSerie<float>(new DateTime(2012, 01, 01), 1) { GrowthRate = float.MaxValue },
                new TimeSerie<float>(new DateTime(2012, 01, 01), 1) { GrowthRate = float.MaxValue }
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .AccumulateCompoundInterest(x => x.GrowthRate);

            float.IsPositiveInfinity(result).Should().BeTrue();
        }

        #endregion


        #endregion

        #region AccumulateCompoundInterest IEnumerable to IEnumerable 

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .AccumulateCompoundInterest(
                         x => x.GrowthRate,
                         (x, cumProf) => new
                         {
                             Date = x.ReferenceDate,
                             CumulativePercentage = cumProf
                         });

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .AccumulateCompoundInterest(
                         x => x.GrowthRate,
                         (x, cumProf) => new
                         {
                             Date = x.ReferenceDate,
                             CumulativePercentage = cumProf
                         });

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_FloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .AccumulateCompoundInterest(
                         x => x.GrowthRate,
                         (x, cumProf) => new
                         {
                             Date = x.ReferenceDate,
                             CumulativePercentage = cumProf
                         });

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }
        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            Func<TimeSerie<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                        .OrderBy(x => x.ReferenceDate)
                        .AccumulateCompoundInterest(
                            selector,
                            (x, cumProf) => new
                            {
                                Date = x.ReferenceDate,
                                CumulativePercentage = cumProf
                            })
                         .ToList();

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            Func<TimeSerie<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                        .OrderBy(x => x.ReferenceDate)
                        .AccumulateCompoundInterest(
                            selector,
                            (x, cumProf) => new
                            {
                                Date = x.ReferenceDate,
                                CumulativePercentage = cumProf
                            })
                         .ToList();

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_FloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            Func<TimeSerie<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                        .OrderBy(x => x.ReferenceDate)
                        .AccumulateCompoundInterest(
                            selector,
                            (x, cumProf) => new
                            {
                                Date = x.ReferenceDate,
                                CumulativePercentage = cumProf
                            })
                         .ToList();

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - ZeroReturned

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DecimalProperty_SourceIsEmptyCollection_EmptyCollectionReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = new List<TimeSerie<decimal>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(
                                    x => x.GrowthRate,
                                    (x, cumProf) => new
                                    {
                                        Date = x.ReferenceDate,
                                        CumulativePercentage = cumProf
                                    })
                                .ToList();

            resultList.Any().Should().BeFalse();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DoubleProperty_SourceIsEmptyCollection_EmptyCollectionReturned()
        {
            IEnumerable<TimeSerie<double>> source = new List<TimeSerie<double>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(
                                    x => x.GrowthRate,
                                    (x, cumProf) => new
                                    {
                                        Date = x.ReferenceDate,
                                        CumulativePercentage = cumProf
                                    })
                                .ToList();

            resultList.Any().Should().BeFalse();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_FloatProperty_SourceIsEmptyCollection_EmptyCollectionReturned()
        {
            IEnumerable<TimeSerie<float>> source = new List<TimeSerie<float>>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(
                                    x => x.GrowthRate,
                                    (x, cumProf) => new
                                    {
                                        Date = x.ReferenceDate,
                                        CumulativePercentage = cumProf
                                    })
                                .ToList();

            resultList.Any().Should().BeFalse();
        }

        #endregion

        #region SourceIsNotEmpty - ProperCumulativePercentageReturned

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DecimalProperty_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(
                                    x => x.GrowthRate,
                                    (x, cumProf) => new
                                    {
                                        Date = x.ReferenceDate,
                                        CumulativePercentage = cumProf
                                    })
                                .ToList();

            resultList[0].CumulativePercentage.Should().Be(4.6532690000M);
            resultList[1].CumulativePercentage.Should().Be(6.38346905386361M);
            resultList[2].CumulativePercentage.Should().Be(9.2061086593943664664109M);
            resultList[3].CumulativePercentage.Should().Be(16.34020519917575630512547822M);
            resultList[4].CumulativePercentage.Should().Be(22.53753158993064966774320732M);

        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DoubleProperty_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(
                                    x => x.GrowthRate,
                                    (x, cumProf) => new
                                    {
                                        Date = x.ReferenceDate,
                                        CumulativePercentage = cumProf
                                    })
                                .ToList();

            resultList[0].CumulativePercentage.Should().Be(4.6532690000000043);
            resultList[1].CumulativePercentage.Should().Be(6.3834690538636218);
            resultList[2].CumulativePercentage.Should().Be(9.2061086593943742);
            resultList[3].CumulativePercentage.Should().Be(16.340205199175784);
            resultList[4].CumulativePercentage.Should().Be(22.53753158993068);
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_FloatProperty_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            var resultList = source
                                .OrderBy(x => x.ReferenceDate)
                                .AccumulateCompoundInterest(
                                    x => x.GrowthRate,
                                    (x, cumProf) => new
                                    {
                                        Date = x.ReferenceDate,
                                        CumulativePercentage = cumProf
                                    })
                                .ToList();

            resultList[0].CumulativePercentage.Should().Be(4.653263F);
            resultList[1].CumulativePercentage.Should().Be(6.383455F);
            resultList[2].CumulativePercentage.Should().Be(9.206093F);
            resultList[3].CumulativePercentage.Should().Be(16.3401966F);
            resultList[4].CumulativePercentage.Should().Be(22.537529F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DecimalProperty_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = new TimeSerie<decimal>[] {
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), 1M) { GrowthRate = decimal.MaxValue },
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), 1M) { GrowthRate = decimal.MaxValue }
            };

            Action comparison = () =>
            {
                source
                         .OrderBy(x => x.ReferenceDate)
                         .AccumulateCompoundInterest(
                             x => x.GrowthRate,
                             (x, cumProf) => new
                             {
                                 Date = x.ReferenceDate,
                                 CumulativePercentage = cumProf
                             })
                         .ToList();

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_DoubleProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<TimeSerie<double>> source = new TimeSerie<double>[] {
                new TimeSerie<double>(new DateTime(2012, 01, 01), 1) { GrowthRate = double.MaxValue },
                new TimeSerie<double>(new DateTime(2012, 01, 01), 1) { GrowthRate = double.MaxValue }
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .AccumulateCompoundInterest(
                                x => x.GrowthRate,
                                (x, cumProf) => new
                                {
                                    Date = x.ReferenceDate,
                                    CumulativePercentage = cumProf
                                })
                            .ToList();

            double.IsPositiveInfinity(result[0].CumulativePercentage).Should().BeFalse();
        }

        [Fact]
        public void AccumulateCompoundInterest_IEnumerableToIEnumberable_FloatProperty_SourceCumulativePercentageToOverflow_InfinityReturned()
        {
            IEnumerable<TimeSerie<float>> source = new TimeSerie<float>[] {
                new TimeSerie<float>(new DateTime(2012, 01, 01), 1) { GrowthRate = float.MaxValue },
                new TimeSerie<float>(new DateTime(2012, 01, 01), 1) { GrowthRate = float.MaxValue }
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .AccumulateCompoundInterest(
                                x => x.GrowthRate,
                                (x, cumProf) => new
                                {
                                    Date = x.ReferenceDate,
                                    CumulativePercentage = cumProf
                                })
                            .ToList();

            float.IsPositiveInfinity(result[0].CumulativePercentage).Should().BeTrue();
        }

        #endregion

        #endregion
    }
}
