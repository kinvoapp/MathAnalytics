using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class BetaTest
    {
        #region Two IEnumerable<scalar> lists

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void BetaOfDecimalList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<decimal>> source = DataGenerator.CreateBetaSampleItemsList<decimal>();

            IEnumerable<decimal> measure1 = null;
            IEnumerable<decimal> measure2 = source.Select(x => x.AssetReturn);

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            measure1 = source.Select(x => x.MarketReturn);
            measure2 = null;

            comparison = () =>
            {
                measure1.Beta(measure2);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void BetaOfDoubleList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<double>> source = DataGenerator.CreateBetaSampleItemsList<double>();

            IEnumerable<double> measure1 = null;
            IEnumerable<double> measure2 = source.Select(x => x.AssetReturn);

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            measure1 = source.Select(x => x.MarketReturn);
            measure2 = null;

            comparison = () =>
            {
                measure1.Beta(measure2);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void BetaOfFloatList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<float>> source = DataGenerator.CreateBetaSampleItemsList<float>();

            IEnumerable<float> measure1 = null;
            IEnumerable<float> measure2 = source.Select(x => x.AssetReturn);

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            measure1 = source.Select(x => x.MarketReturn);
            measure2 = null;

            comparison = () =>
            {
                measure1.Beta(measure2);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - InvalidOperationExceptionThrown

        [Fact]
        public void BetaOfDecimalList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<decimal> measure1 = new List<decimal>();
            IEnumerable<decimal> measure2 = new List<decimal>();

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void BetaOfDoubleList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<double> measure1 = new List<double>();
            IEnumerable<double> measure2 = new List<double>();

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void BetaOfFloatList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<float> measure1 = new List<float>();
            IEnumerable<float> measure2 = new List<float>();

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmptyAndTheSameLength - BetaReturned

        [Fact]
        public void BetaOfDecimalList_SourceIsNotEmptyAndTheSameLength_BetaReturned()
        {
            IEnumerable<BetaSampleItem<decimal>> source = DataGenerator.CreateBetaSampleItemsList<decimal>();

            var marketReturns = source.Select(x => x.MarketReturn);
            var assetReturns = source.Select(x => x.AssetReturn);

            marketReturns.Beta(assetReturns).Should().Be(0.7275786672584273763846257811M);
        }

        [Fact]
        public void BetaOfDoubleList_SourceIsNotEmptyAndTheSameLength_BetaReturned()
        {
            IEnumerable<BetaSampleItem<double>> source = DataGenerator.CreateBetaSampleItemsList<double>();

            var marketReturns = source.Select(x => x.MarketReturn);
            var assetReturns = source.Select(x => x.AssetReturn);

            marketReturns.Beta(assetReturns).Should().Be(0.72757866725842668);
        }

        [Fact]
        public void BetaOfFloatList_SourceIsNotEmptyAndTheSameLength_BetaReturned()
        {
            IEnumerable<BetaSampleItem<float>> source = DataGenerator.CreateBetaSampleItemsList<float>();

            var marketReturns = source.Select(x => x.MarketReturn);
            var assetReturns = source.Select(x => x.AssetReturn);

            marketReturns.Beta(assetReturns).Should().Be(0.7275786672584273763846257811F);
        }

        #endregion

        #region SourceIsNotEmptyButDifferentLengths - BetaReturned

        [Fact]
        public void BetaOfDecimalList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            IEnumerable<decimal> measure1 = new decimal[] { 1M, 2M, 3M };
            IEnumerable<decimal> measure2 = new decimal[] { 1M, 2M };

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void BetaOfDoubleList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            IEnumerable<double> measure1 = new double[] { 1, 2, 3 };
            IEnumerable<double> measure2 = new double[] { 1, 2 };

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void BetaOfFloatList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            IEnumerable<float> measure1 = new float[] { 1, 2, 3 };
            IEnumerable<float> measure2 = new float[] { 1, 2 };

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void BetaOfDecimalList_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<decimal> measure1 = new decimal[] { decimal.MaxValue, decimal.MaxValue };
            IEnumerable<decimal> measure2 = new decimal[] { decimal.MaxValue, decimal.MaxValue };

            Action comparison = () =>
            {
                measure1.Beta(measure2);
            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void BetaOfDoubleList_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<double> measure1 = new double[] { double.MaxValue, double.MaxValue };
            IEnumerable<double> measure2 = new double[] { double.MaxValue, double.MaxValue };

            var result = measure1.Beta(measure2);

            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void BetaOfFloatList_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {

            IEnumerable<float> measure1 = new float[] { float.MaxValue, float.MaxValue };
            IEnumerable<float> measure2 = new float[] { float.MaxValue, float.MaxValue };

            var result = measure1.Beta(measure2);

            float.IsPositiveInfinity(result).Should().BeFalse();

        }

        #endregion

        #endregion

        #region Two TSource properties in IEnumerable<TSource>

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void BetaOfDecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<decimal>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(x => x.MarketReturn, x => x.AssetReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void BetaOfDoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<double>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(x => x.MarketReturn, x => x.AssetReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void BetaOfFloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<float>> source = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(x => x.MarketReturn, x => x.AssetReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void BetaOfDecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<decimal>> source = DataGenerator.CreateBetaSampleItemsList<decimal>();

            Func<BetaSampleItem<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(selector, x => x.AssetReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(x => x.MarketReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BetaOfDoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<double>> source = DataGenerator.CreateBetaSampleItemsList<double>();

            Func<BetaSampleItem<double>, double> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(selector, x => x.AssetReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(x => x.MarketReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BetaOfFloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<BetaSampleItem<float>> source = DataGenerator.CreateBetaSampleItemsList<float>();

            Func<BetaSampleItem<float>, float> selector = null;

            Action comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(selector, x => x.AssetReturn);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(x => x.MarketReturn, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - InvalidOperationExceptionThrown

        [Fact]
        public void BetaOfDecimalProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<BetaSampleItem<decimal>> source = new List<BetaSampleItem<decimal>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Beta(x => x.MarketReturn, x => x.AssetReturn);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void BetaOfDoubleProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<BetaSampleItem<double>> source = new List<BetaSampleItem<double>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Beta(x => x.MarketReturn, x => x.AssetReturn);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void BetaOfFloatProperty_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            IEnumerable<BetaSampleItem<float>> source = new List<BetaSampleItem<float>>();

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Beta(x => x.MarketReturn, x => x.AssetReturn);

            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmpty - BetaReturned

        [Fact]
        public void BetaOfDecimal_SourceIsNotEmpty_BetaReturned()
        {
            IEnumerable<BetaSampleItem<decimal>> source = DataGenerator.CreateBetaSampleItemsList<decimal>();

            source.Beta(x => x.MarketReturn, x => x.AssetReturn).Should().Be(0.7275786672584273763846257811M);
        }

        [Fact]
        public void BetaOfDouble_SourceIsNotEmpty_BetaReturned()
        {
            IEnumerable<BetaSampleItem<double>> source = DataGenerator.CreateBetaSampleItemsList<double>();

            source.Beta(x => x.MarketReturn, x => x.AssetReturn).Should().Be(0.72757866725842668);
        }

        [Fact]
        public void BetaOfFloat_SourceIsNotEmpty_BetaReturned()
        {
            IEnumerable<BetaSampleItem<float>> source = DataGenerator.CreateBetaSampleItemsList<float>();

            source.Beta(x => x.MarketReturn, x => x.AssetReturn).Should().Be(0.7275786672584273763846257811F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void BetaOfDecimalProperty_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<BetaSampleItem<decimal>> source = new BetaSampleItem<decimal>[] {
                new BetaSampleItem<decimal>(new DateTime(2012, 01, 01), decimal.MaxValue, decimal.MaxValue),
                new BetaSampleItem<decimal>(new DateTime(2012, 02, 01), decimal.MaxValue, decimal.MaxValue)
            };

            Action comparison = () =>
            {
                source
                    .OrderBy(x => x.ReferenceDate)
                    .Beta(x => x.MarketReturn, x => x.AssetReturn);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void BetaOfDoubleProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<BetaSampleItem<double>> source = new BetaSampleItem<double>[] {
                new BetaSampleItem<double>(new DateTime(2012, 01, 01), double.MaxValue, double.MaxValue),
                new BetaSampleItem<double>(new DateTime(2012, 02, 01), double.MaxValue, double.MaxValue)
            };


            var result = source
                           .OrderBy(x => x.ReferenceDate)
                           .Beta(x => x.MarketReturn, x => x.AssetReturn);


            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void BetaOfFloatProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<BetaSampleItem<float>> source = new BetaSampleItem<float>[] {
                new BetaSampleItem<float>(new DateTime(2012, 01, 01), float.MaxValue, float.MaxValue),
                new BetaSampleItem<float>(new DateTime(2012, 02, 01), float.MaxValue, float.MaxValue)
            };


            var result = source
                     .OrderBy(x => x.ReferenceDate)
                     .Beta(x => x.MarketReturn, x => x.AssetReturn);

            float.IsPositiveInfinity(result).Should().BeFalse();

        }

        #endregion

        #endregion

    }
}
