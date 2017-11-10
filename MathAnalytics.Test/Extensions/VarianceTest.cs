using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class VarianceTest
    {
        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void VarianceOfDecimal_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Variance(x => x.Value);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void VarianceOfDouble_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Variance(x => x.Value);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void VarianceOfFloat_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Variance(x => x.Value);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }
        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void VarianceOfDecimal_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            Func<TimeSerie<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Variance(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void VarianceOfDouble_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            Func<TimeSerie<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Variance(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void VarianceOfFloat_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            Func<TimeSerie<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Variance(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - ZeroReturned

        [Fact]
        public void VarianceOfDecimal_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = new List<TimeSerie<decimal>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Variance(x => x.Value);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void VarianceOfDouble_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = new List<TimeSerie<double>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Variance(x => x.Value);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void VarianceOfFloat_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = new List<TimeSerie<float>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Variance(x => x.Value);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmpty - ProperCumulativePercentageReturned

        [Fact]
        public void VarianceOfDecimal_SourceIsNotEmpty_VarianceReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            source
                .OrderBy(x => x.ReferenceDate)
                .Variance(x => x.Value).Should().Be(13.0716706087362M);
        }

        [Fact]
        public void VarianceOfDouble_SourceIsNotEmpty_VarianceReturned()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            source
                .OrderBy(x => x.ReferenceDate)
                .Variance(x => x.Value).Should().Be(13.071670608736184);
        }

        [Fact]
        public void VarianceOfFloat_SourceIsNotEmpty_VarianceReturned()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            source
                .OrderBy(x => x.ReferenceDate)
                .Variance(x => x.Value).Should().Be(13.0716658F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void VarianceOfDecimal_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = new TimeSerie<decimal>[] {
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue),
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue)
            };

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Variance(x => x.Value);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void VarianceOfDouble_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<TimeSerie<double>> source = new TimeSerie<double>[] {
                new TimeSerie<double>(new DateTime(2012, 01, 01), double.MaxValue),
                new TimeSerie<double>(new DateTime(2012, 01, 01), double.MaxValue)
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .Variance(x => x.Value);

            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void VarianceOfFloat_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<TimeSerie<float>> source = new TimeSerie<float>[] {
                new TimeSerie<float>(new DateTime(2012, 01, 01),  float.MaxValue),
                new TimeSerie<float>(new DateTime(2012, 01, 01),  float.MaxValue)
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .Variance(x => x.Value);

            float.IsPositiveInfinity(result).Should().BeFalse();
        }

        #endregion
    }
}
