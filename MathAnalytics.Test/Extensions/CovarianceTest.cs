using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class CovarianceTest
    {
        #region Two IEnumerable<scalar> lists

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void CovarianceOfDecimalList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = DataGenerator.CreateSharpeRatioSampleItemsList<decimal>();

            IEnumerable<decimal> measure1 = null;
            IEnumerable<decimal> measure2 = source.Select(x => x.RiskFreeRate);

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            measure1 = source.Select(x => x.PortfolioReturn);
            measure2 = null;

            comparison = () =>
            {
                measure1.Covariance(measure2);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void CovarianceOfDoubleList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = DataGenerator.CreateSharpeRatioSampleItemsList<double>();

            IEnumerable<double> measure1 = null;
            IEnumerable<double> measure2 = source.Select(x => x.RiskFreeRate);

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            measure1 = source.Select(x => x.PortfolioReturn);
            measure2 = null;

            comparison = () =>
            {
                measure1.Covariance(measure2);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void CovarianceOfFloatList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = DataGenerator.CreateSharpeRatioSampleItemsList<float>();

            IEnumerable<float> measure1 = null;
            IEnumerable<float> measure2 = source.Select(x => x.RiskFreeRate);

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            measure1 = source.Select(x => x.PortfolioReturn);
            measure2 = null;

            comparison = () =>
            {
                measure1.Covariance(measure2);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - InvalidOperationExceptionThrown

        [Fact]
        public void CovarianceOfDecimalList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<decimal> measure1 = new List<decimal>();
            IEnumerable<decimal> measure2 = new List<decimal>();

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void CovarianceOfDoubleList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<double> measure1 = new List<double>();
            IEnumerable<double> measure2 = new List<double>();

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void CovarianceOfFloatList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<float> measure1 = new List<float>();
            IEnumerable<float> measure2 = new List<float>();

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmptyAndTheSameLength - CovarianceReturned

        [Fact]
        public void CovarianceOfDecimalList_SourceIsNotEmptyAndTheSameLength_CovarianceReturned()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = DataGenerator.CreateSharpeRatioSampleItemsList<decimal>();

            var measure1 = source.Select(x => x.PortfolioReturn);
            var measure2 = source.Select(x => x.RiskFreeRate);

            measure1.Covariance(measure2).Should().Be(13.393797588565666666666666667M);
        }

        [Fact]
        public void CovarianceOfDoubleList_SourceIsNotEmptyAndTheSameLength_CovarianceReturned()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = DataGenerator.CreateSharpeRatioSampleItemsList<double>();

            var measure1 = source.Select(x => x.PortfolioReturn);
            var measure2 = source.Select(x => x.RiskFreeRate);

            measure1.Covariance(measure2).Should().Be(13.39379758856569);
        }

        [Fact]
        public void CovarianceOfFloatList_SourceIsNotEmptyAndTheSameLength_CovarianceReturned()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = DataGenerator.CreateSharpeRatioSampleItemsList<float>();

            var measure1 = source.Select(x => x.PortfolioReturn);
            var measure2 = source.Select(x => x.RiskFreeRate);

            measure1.Covariance(measure2).Should().Be(13.3937883F);
        }

        #endregion

        #region SourceIsNotEmptyButDifferentLengths - CovarianceReturned

        [Fact]
        public void CovarianceOfDecimalList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            IEnumerable<decimal> measure1 = new decimal[] { 1M, 2M, 3M };
            IEnumerable<decimal> measure2 = new decimal[] { 1M, 2M };

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void CovarianceOfDoubleList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            IEnumerable<double> measure1 = new double[] { 1, 2, 3 };
            IEnumerable<double> measure2 = new double[] { 1, 2 };

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void CovarianceOfFloatList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            IEnumerable<float> measure1 = new float[] { 1, 2, 3 };
            IEnumerable<float> measure2 = new float[] { 1, 2 };

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void CovarianceOfDecimalList_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<decimal> measure1 = new decimal[] { decimal.MaxValue, decimal.MaxValue };
            IEnumerable<decimal> measure2 = new decimal[] { decimal.MaxValue, decimal.MaxValue };

            Action comparison = () =>
            {
                measure1.Covariance(measure2);
            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void CovarianceOfDoubleList_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<double> measure1 = new double[] { double.MaxValue, double.MaxValue };
            IEnumerable<double> measure2 = new double[] { double.MaxValue, double.MaxValue };

            var result = measure1.Covariance(measure2);

            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void CovarianceOfFloatList_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {

            IEnumerable<float> measure1 = new float[] { float.MaxValue, float.MaxValue };
            IEnumerable<float> measure2 = new float[] { float.MaxValue, float.MaxValue };

            var result = measure1.Covariance(measure2);

            float.IsPositiveInfinity(result).Should().BeFalse();

        }

        #endregion

        #endregion

        #region Two TSource properties in IEnumerable<TSource>

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void CovarianceOfDecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void CovarianceOfDoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void CovarianceOfFloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void CovarianceOfDecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = DataGenerator.CreateSharpeRatioSampleItemsList<decimal>();

            Func<SharpeRatioSampleItem<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(selector, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(x => x.PortfolioReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CovarianceOfDoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = DataGenerator.CreateSharpeRatioSampleItemsList<double>();

            Func<SharpeRatioSampleItem<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(selector, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(x => x.PortfolioReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CovarianceOfFloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = DataGenerator.CreateSharpeRatioSampleItemsList<float>();

            Func<SharpeRatioSampleItem<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(selector, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(x => x.PortfolioReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - InvalidOperationExceptionThrown

        [Fact]
        public void CovarianceOfDecimalProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = new List<SharpeRatioSampleItem<decimal>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void CovarianceOfDoubleProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = new List<SharpeRatioSampleItem<double>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void CovarianceOfFloatProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = new List<SharpeRatioSampleItem<float>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmpty - CovarianceReturned

        [Fact]
        public void CovarianceOfDecimal_SourceIsNotEmpty_CovarianceReturned()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = DataGenerator.CreateSharpeRatioSampleItemsList<decimal>();

            source.Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate).Should().Be(13.393797588565666666666666667M);
        }

        [Fact]
        public void CovarianceOfDouble_SourceIsNotEmpty_CovarianceReturned()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = DataGenerator.CreateSharpeRatioSampleItemsList<double>();

            source.Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate).Should().Be(13.39379758856569);
        }

        [Fact]
        public void CovarianceOfFloat_SourceIsNotEmpty_CovarianceReturned()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = DataGenerator.CreateSharpeRatioSampleItemsList<float>();

            source.Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate).Should().Be(13.3937883F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void CovarianceOfDecimalProperty_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = new SharpeRatioSampleItem<decimal>[] {
                new SharpeRatioSampleItem<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue, decimal.MaxValue),
                new SharpeRatioSampleItem<decimal>(new DateTime(2012, 02, 01), decimal.MaxValue, decimal.MaxValue)
            };

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void CovarianceOfDoubleProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = new SharpeRatioSampleItem<double>[] {
                new SharpeRatioSampleItem<double>(new DateTime(2012, 01, 01), double.MaxValue, double.MaxValue),
                new SharpeRatioSampleItem<double>(new DateTime(2012, 02, 01), double.MaxValue, double.MaxValue)
            };


            var result = source
                           .OrderBy(x => x.ReferenceDate)
                           .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);


            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void CovarianceOfFloatProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = new SharpeRatioSampleItem<float>[] {
                new SharpeRatioSampleItem<float>(new DateTime(2012, 01, 01), float.MaxValue, float.MaxValue),
                new SharpeRatioSampleItem<float>(new DateTime(2012, 02, 01), float.MaxValue, float.MaxValue)
            };


            var result = source
                     .OrderBy(x => x.ReferenceDate)
                     .Covariance(x => x.PortfolioReturn, x => x.RiskFreeRate);

            float.IsPositiveInfinity(result).Should().BeFalse();

        }

        #endregion

        #endregion

    }
}
