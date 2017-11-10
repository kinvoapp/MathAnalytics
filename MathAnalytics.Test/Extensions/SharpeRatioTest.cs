using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class SharpeRatioTest
    {
        #region SharpeRatio scalar to scalar

        #region StandardDeviationIsZero DivideByZeroExceptionThrown

        [Fact]
        public void SharpeRatioOfDecimal_StandardDeviationIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                decimal portfolioReturn = 16M;
                decimal riskFreeRate = 11M;

                portfolioReturn.SharpeRatio(riskFreeRate, 0M);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void SharpeRatioOfDouble_StandardDeviationIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                double portfolioReturn = 16;
                double riskFreeRate = 11;

                portfolioReturn.SharpeRatio(riskFreeRate, 0);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void SharpeRatioOfFloat_StandardDeviationIsZero_DivideByZeroExceptionThrown()
        {
            Action comparison = () =>
            {
                float portfolioReturn = 16F;
                float riskFreeRate = 11F;

                portfolioReturn.SharpeRatio(riskFreeRate, 0F);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion

        #region SourceIsNotZero - SharpeRationReturned

        [Theory]
        [InlineData(0.1889, 0.1108, 0.1008, 0.77480159)]
        [InlineData(0, 0.1108, 0.1008, -1.09920635)]
        [InlineData(0.1889, 0, 0.1008, 1.87400794)]
        public void SharpeRatioOfDecimal_SourceIsNotZero_SharpeRationReturned(decimal portfolioReturn, decimal riskFreeRate, decimal standardDeviationOfPortfolioReturn, decimal resultExpected)
        {
            Math.Round(portfolioReturn.SharpeRatio(riskFreeRate, standardDeviationOfPortfolioReturn), 8).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0.1889, 0.1108, 0.1008, 0.77480159)]
        [InlineData(0, 0.1108, 0.1008, -1.09920635)]
        [InlineData(0.1889, 0, 0.1008, 1.87400794)]
        public void SharpeRatioOfDouble_SourceIsNotZero_SharpeRationReturned(double portfolioReturn, double riskFreeRate, double standardDeviationOfPortfolioReturn, double resultExpected)
        {
            Math.Round(portfolioReturn.SharpeRatio(riskFreeRate, standardDeviationOfPortfolioReturn), 8).Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0.1889, 0.1108, 0.1008, 0.77480155)]
        [InlineData(0, 0.1108, 0.1008, -1.09920633)]
        [InlineData(0.1889, 0, 0.1008, 1.87400782)]
        public void SharpeRatioOfFloat_SourceIsNotZero_SharpeRationReturned(float portfolioReturn, float riskFreeRate, float standardDeviationOfPortfolioReturn, float resultExpected)
        {
            portfolioReturn.SharpeRatio(riskFreeRate, standardDeviationOfPortfolioReturn).Should().Be(resultExpected);
        }

        #endregion

        #endregion

        #region SharpeRatio IEnumerable to scalar

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void SharpeRatio_IEnumerableToScalar_FloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = DataGenerator.CreateSharpeRatioSampleItemsList<decimal>();

            Func<SharpeRatioSampleItem<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(selector, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(x => x.PortfolioReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = DataGenerator.CreateSharpeRatioSampleItemsList<double>();

            Func<SharpeRatioSampleItem<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(selector, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(x => x.PortfolioReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_FloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = DataGenerator.CreateSharpeRatioSampleItemsList<float>();

            Func<SharpeRatioSampleItem<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(selector, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .SharpeRatio(x => x.PortfolioReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - ZeroReturned

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DecimalProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = new List<SharpeRatioSampleItem<decimal>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DoubleProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = new List<SharpeRatioSampleItem<double>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_FloatProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = new List<SharpeRatioSampleItem<float>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmpty - SharpeRatioReturned

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_Decimal_SourceIsNotEmpty_SharpeRatioReturned()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = DataGenerator.CreateSharpeRatioSampleItemsList<decimal>();

            source
                .OrderBy(x => x.ReferenceDate)
                .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate).Should().Be(2.8217884382811009251231451007M);
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_Double_SourceIsNotEmpty_SharpeRatioReturned()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = DataGenerator.CreateSharpeRatioSampleItemsList<double>();

            source
                .OrderBy(x => x.ReferenceDate)
                .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate).Should().Be(2.8217884382811032);
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_Float_SourceIsNotEmpty_SharpeRatioReturned()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = DataGenerator.CreateSharpeRatioSampleItemsList<float>();

            source
                .OrderBy(x => x.ReferenceDate)
                .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate).Should().Be(2.82179761F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DecimalProperty_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<decimal>> source = new SharpeRatioSampleItem<decimal>[] {
                new SharpeRatioSampleItem<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue, decimal.MaxValue),
                new SharpeRatioSampleItem<decimal>(new DateTime(2012, 02, 01), decimal.MaxValue, decimal.MaxValue)
            };

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_DoubleProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<SharpeRatioSampleItem<double>> source = new SharpeRatioSampleItem<double>[] {
                new SharpeRatioSampleItem<double>(new DateTime(2012, 01, 01), double.MaxValue, double.MaxValue),
                new SharpeRatioSampleItem<double>(new DateTime(2012, 02, 01), double.MaxValue, double.MaxValue)
            };


            var result = source
                           .OrderBy(x => x.ReferenceDate)
                           .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);


            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void SharpeRatio_IEnumerableToScalar_FloatProperty_SourceCumulativePercentageToOverflow_DivideByZeroExceptionThrown()
        {
            IEnumerable<SharpeRatioSampleItem<float>> source = new SharpeRatioSampleItem<float>[] {
                new SharpeRatioSampleItem<float>(new DateTime(2012, 01, 01), float.MaxValue, float.MaxValue),
                new SharpeRatioSampleItem<float>(new DateTime(2012, 02, 01), float.MaxValue, float.MaxValue)
            };
            
            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .SharpeRatio(x => x.PortfolioReturn, x => x.RiskFreeRate);

            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion


        #endregion
    }
}
