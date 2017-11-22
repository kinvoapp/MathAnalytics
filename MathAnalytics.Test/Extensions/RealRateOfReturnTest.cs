using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class RealRateOfReturnTest
    {
        #region RealRateOfReturn scalar to scalar

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(25.85034088, 8.671669103, 15.8078659496)]
        public void RealRateOfReturn_ScalarToScalar_Decimal_GivenNominalRateOfReturnAndInflationRate_RealReateOfReturnReturned(decimal nominalRateOfReturn, decimal inflationRate, decimal resultExpected)
        {
            Math.Round(nominalRateOfReturn.RealRateOfReturn(inflationRate), 10).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(25.85034088, 8.671669103, 15.807865949604505)]
        public void RealRateOfReturn_ScalarToScalar_Double_GivenNominalRateOfReturnAndInflationRate_RealReateOfReturnReturned(double nominalRateOfReturn, double inflationRate, double resultExpected)
        {
            nominalRateOfReturn.RealRateOfReturn(inflationRate).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(25.85034088, 8.671669103, 15.8078671F)]
        public void RealRateOfReturn_ScalarToScalar_Float_GivenNominalRateOfReturnAndInflationRate_RealReateOfReturnReturned(float nominalRateOfReturn, float inflationRate, float resultExpected)
        {
            nominalRateOfReturn.RealRateOfReturn(inflationRate).Should().Be(resultExpected);
        }

        #endregion

        #region RealRateOfReturn IEnumerable to scalar

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<RealRateOfReturnSampleItem<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .RealRateOfReturn(x => x.NominalRateOfReturn, x=> x.InflationReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<RealRateOfReturnSampleItem<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_FloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<RealRateOfReturnSampleItem<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }
        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<RealRateOfReturnSampleItem<decimal>> source = DataGenerator.CreateRealRateOfReturnSampleItemList<decimal>();

            Func<RealRateOfReturnSampleItem<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(selector, x => x.InflationReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<RealRateOfReturnSampleItem<double>> source = DataGenerator.CreateRealRateOfReturnSampleItemList<double>();

            Func<RealRateOfReturnSampleItem<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(selector, x => x.InflationReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_FloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<RealRateOfReturnSampleItem<float>> source = DataGenerator.CreateRealRateOfReturnSampleItemList<float>();

            Func<RealRateOfReturnSampleItem<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(selector, x => x.InflationReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - ZeroReturned

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DecimalProperty_SourceIsEmptyCollection_ZeroReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<decimal>> source = new List<RealRateOfReturnSampleItem<decimal>>();

            var resultList = source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            resultList.Should().Be(0M);
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DoubleProperty_SourceIsEmptyCollection_ZeroReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<double>> source = new List<RealRateOfReturnSampleItem<double>>();

            var resultList = source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            resultList.Should().Be(0);
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_FloatProperty_SourceIsEmptyCollection_ZeroReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<float>> source = new List<RealRateOfReturnSampleItem<float>>();

            var resultList = source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            resultList.Should().Be(0F);
        }

        #endregion

        #region SourceIsNotEmpty - RealRateOfReturnReturned

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_Decimal_SourceIsNotEmpty_RealRateOfReturnReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<decimal>> source = DataGenerator.CreateRealRateOfReturnSampleItemList<decimal>();

            source
                .OrderBy(x => x.ReferenceDate)
                .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn).Should().Be(8.887505128206211633025125740M);
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_Double_SourceIsNotEmpty_RealRateOfReturnReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<double>> source = DataGenerator.CreateRealRateOfReturnSampleItemList<double>();

            source
                .OrderBy(x => x.ReferenceDate)
                .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn).Should().Be(8.8875051282062181);
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_Float_SourceIsNotEmpty_RealRateOfReturnReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<float>> source = DataGenerator.CreateRealRateOfReturnSampleItemList<float>();

            source
                .OrderBy(x => x.ReferenceDate)
                .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn).Should().Be(8.887529F);
        }

        #endregion

        #region SourceRealRateOfReturnToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DecimalProperty_SourceRealRateOfReturnToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<RealRateOfReturnSampleItem<decimal>> source = new RealRateOfReturnSampleItem<decimal>[] {
                new RealRateOfReturnSampleItem<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue, decimal.MaxValue),
                new RealRateOfReturnSampleItem<decimal>(new DateTime(2012, 02, 01), decimal.MaxValue, decimal.MaxValue)
            };

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_DoubleProperty_SourceRealRateOfReturnToOverflow_NotInfinityReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<double>> source = new RealRateOfReturnSampleItem<double>[] {
                new RealRateOfReturnSampleItem<double>(new DateTime(2012, 01, 01), double.MaxValue, double.MaxValue),
                new RealRateOfReturnSampleItem<double>(new DateTime(2012, 02, 01), double.MaxValue, double.MaxValue)
            };

            var result = source
                    .OrderBy(x => x.ReferenceDate)
                    .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void RealRateOfReturn_IEnumerableToScalar_FloatProperty_SourceRealRateOfReturnToOverflow_InfinityReturned()
        {
            IEnumerable<RealRateOfReturnSampleItem<float>> source = new RealRateOfReturnSampleItem<float>[] {
                new RealRateOfReturnSampleItem<float>(new DateTime(2012, 01, 01), float.MaxValue, float.MaxValue),
                new RealRateOfReturnSampleItem<float>(new DateTime(2012, 02, 01), float.MaxValue, float.MaxValue)
            };

            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .RealRateOfReturn(x => x.NominalRateOfReturn, x => x.InflationReturn);

            float.IsPositiveInfinity(result).Should().BeFalse();
        }

        #endregion


        #endregion
    }
}
