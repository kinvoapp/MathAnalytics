using FluentAssertions;
using MathAnalytics.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class WeightedAverageTest
    {

        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DecimalProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<WeightedItem<decimal>> source = null;

            Action comparison = () =>
            {
                source.WeightedAverage(x => x.Value, x => x.Weight);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DoubleProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<WeightedItem<double>> source = null;

            Action comparison = () =>
            {
                source.WeightedAverage(x => x.Value, x => x.Weight);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void WeightedAverage_IEnumerableToScalar_FloatProperty_SourceIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<WeightedItem<float>> source = null;

            Action comparison = () =>
            {
                source.WeightedAverage(x => x.Value, x => x.Weight);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SelectorIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DecimalProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<WeightedItem<decimal>> source = DataGenerator.CreateWeightedItemsList<decimal>();

            Func<WeightedItem<decimal>, decimal> selector = null;

            Action comparison = () =>
            {
                source.WeightedAverage(selector, x => x.Weight);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source.WeightedAverage(x => x.Value, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DoubleProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<WeightedItem<double>> source = DataGenerator.CreateWeightedItemsList<double>();

            Func<WeightedItem<double>, double> selector = null;

            Action comparison = () =>
            {
                source.WeightedAverage(selector, x => x.Weight);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source.WeightedAverage(x => x.Value, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_FloatProperty_SelectorIsNull_ArgumentNullExceptionThrown()
        {
            IEnumerable<WeightedItem<float>> source = DataGenerator.CreateWeightedItemsList<float>();

            Func<WeightedItem<float>, float> selector = null;

            Action comparison = () =>
            {
                source.WeightedAverage(selector, x => x.Weight);

            };

            comparison.ShouldThrow<ArgumentNullException>();

            comparison = () =>
            {
                source.WeightedAverage(x => x.Value, selector);

            };

            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - DivideByZeroExceptionThrown

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DecimalProperty_SourceIsEmptyCollection_DivideByZeroExceptionThrown()
        {
            IEnumerable<WeightedItem<decimal>> source = new List<WeightedItem<decimal>>();

            Action comparison = () =>
            {
                source.WeightedAverage(x => x.Value, x => x.Weight);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DoubleProperty_SourceIsEmptyCollection_DivideByZeroExceptionThrown()
        {
            IEnumerable<WeightedItem<double>> source = new List<WeightedItem<double>>();

            Action comparison = () =>
            {
                source.WeightedAverage(x => x.Value, x => x.Weight);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_FloatProperty_SourceIsEmptyCollection_DivideByZeroExceptionThrown()
        {
            IEnumerable<WeightedItem<float>> source = new List<WeightedItem<float>>();

            Action comparison = () =>
            {
                source.WeightedAverage(x => x.Value, x => x.Weight);
            };

            comparison.ShouldThrow<DivideByZeroException>();
        }

        #endregion

        #region SourceIsNotEmpty - ProperCumulativePercentageReturned

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_Decimal_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<WeightedItem<decimal>> source = DataGenerator.CreateWeightedItemsList<decimal>();

            source.WeightedAverage(x => x.Value, x => x.Weight).Should().Be(7.973961418181818181818181818M);
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_Double_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<WeightedItem<double>> source = DataGenerator.CreateWeightedItemsList<double>();

            source.WeightedAverage(x => x.Value, x => x.Weight).Should().Be(7.9739614181818173);
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_Float_SourceIsNotEmpty_ProperCumulativePercentageReturned()
        {
            IEnumerable<WeightedItem<float>> source = DataGenerator.CreateWeightedItemsList<float>();

            source.WeightedAverage(x => x.Value, x => x.Weight).Should().Be(7.9739614181818173F);
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DecimalProperty_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            IEnumerable<WeightedItem<decimal>> source = new WeightedItem<decimal>[] {
                new WeightedItem<decimal>(decimal.MaxValue,decimal.MaxValue),
                new WeightedItem<decimal>(decimal.MaxValue, decimal.MaxValue)
            };

            Action comparison = () =>
            {
                source.WeightedAverage(x => x.Value, x => x.Weight);

            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_DoubleProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<WeightedItem<double>> source = new WeightedItem<double>[] {
                new WeightedItem<double>(double.MaxValue,double.MaxValue),
                new WeightedItem<double>(double.MaxValue, double.MaxValue)
            };


            var result = source.WeightedAverage(x => x.Value, x => x.Weight);

            double.IsPositiveInfinity(result).Should().BeFalse();
        }

        [Fact]
        public void WeightedAverage_IEnumerableToScalar_FloatProperty_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            IEnumerable<WeightedItem<float>> source = new WeightedItem<float>[] {
                new WeightedItem<float>(float.MaxValue,float.MaxValue),
                new WeightedItem<float>(float.MaxValue, float.MaxValue)
            };


            var result = source.WeightedAverage(x => x.Value, x => x.Weight);

            float.IsPositiveInfinity(result).Should().BeFalse();
        }

        #endregion

    }
}
