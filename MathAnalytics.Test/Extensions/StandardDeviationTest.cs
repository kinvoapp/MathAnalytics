using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class StandardDeviationTest
    {
        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void StandardDeviationOfDecimal_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .StandardDeviation(x => x.Value);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void StandardDeviationOfDouble_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .StandardDeviation(x => x.Value);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void StandardDeviationOfFloat_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .StandardDeviation(x => x.Value);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }
        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void StandardDeviationOfDecimal_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            Func<TimeSerie<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .StandardDeviation(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StandardDeviationOfDouble_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            Func<TimeSerie<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .StandardDeviation(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StandardDeviationOfFloat_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            Func<TimeSerie<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .StandardDeviation(selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - ZeroReturned

        [Fact]
        public void StandardDeviationOfDecimal_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = new List<TimeSerie<decimal>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .StandardDeviation(x => x.Value);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void StandardDeviationOfDouble_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<TimeSerie<double>> source = new List<TimeSerie<double>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .StandardDeviation(x => x.Value);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void StandardDeviationOfFloat_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<TimeSerie<float>> source = new List<TimeSerie<float>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .StandardDeviation(x => x.Value);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmpty - StandardDeviationReturned

        [Fact]
        public void StandardDeviationOfDecimal_SourceIsNotEmpty_StandardDeviationReturned()
        {
            IEnumerable<TimeSerie<decimal>> source = DataGenerator.CreateTimeSerieList<decimal>();

            source
                .OrderBy(x => x.ReferenceDate)
                .StandardDeviation(x => x.Value).Should().Be(3.61547653964677M);
        }

        [Fact]
        public void StandardDeviationOfDouble_SourceIsNotEmpty_StandardDeviationReturned()
        {
            IEnumerable<TimeSerie<double>> source = DataGenerator.CreateTimeSerieList<double>();

            source
                .OrderBy(x => x.ReferenceDate)
                .StandardDeviation(x => x.Value).Should().Be(3.6154765396467705);
        }

        [Fact]
        public void StandardDeviationOfFloat_SourceIsNotEmpty_StandardDeviationReturned()
        {
            IEnumerable<TimeSerie<float>> source = DataGenerator.CreateTimeSerieList<float>();

            source
                .OrderBy(x => x.ReferenceDate)
                .StandardDeviation(x => x.Value).Should().Be(3.615476F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void StandardDeviationOfDecimal_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<TimeSerie<decimal>> source = new TimeSerie<decimal>[] {
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue),
                new TimeSerie<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue)
            };

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .StandardDeviation(x => x.Value);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void StandardDeviationOfDouble_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<TimeSerie<double>> source = new TimeSerie<double>[] {
                new TimeSerie<double>(new DateTime(2012, 01, 01), double.MaxValue),
                new TimeSerie<double>(new DateTime(2012, 01, 01), double.MaxValue)
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .StandardDeviation(x => x.Value);

            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void StandardDeviationOfFloat_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<TimeSerie<float>> source = new TimeSerie<float>[] {
                new TimeSerie<float>(new DateTime(2012, 01, 01),  float.MaxValue),
                new TimeSerie<float>(new DateTime(2012, 01, 01),  float.MaxValue)
            };


            var result = source
                            .OrderBy(x => x.ReferenceDate)
                            .StandardDeviation(x => x.Value);

            float.IsPositiveInfinity(result).Should().BeFalse();
        }

        #endregion
    }
}
