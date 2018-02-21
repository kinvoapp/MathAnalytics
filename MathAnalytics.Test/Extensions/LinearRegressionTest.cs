using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace MathAnalytics.Test.Extensions
{
    public class LinearRegressionTest
    {
        #region SourceIsNull - ArgumentNullExceptionThrown

        [Fact]
        public void LinearRegressionOfDecimalList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            decimal[] listX = null;
            decimal[] listY = new decimal[] { 0, 1, 2.5M, 4.8M, 6.0M, 5.8M };

            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            listX = new decimal[] { 0, 1, 2, 3, 4, 5 };
            listY = null;

            comparison = () =>
            {
                listX.LinearRegression(listY);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void LinearRegressionOfDoubleList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            double[] listX = null;
            double[] listY = new double[] { 0, 1, 2.5, 4.8, 6.0, 5.8 };

            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            listX = new double[] { 0, 1, 2, 3, 4, 5 };
            listY = null;

            comparison = () =>
            {
                listX.LinearRegression(listY);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void LinearRegressionOfFloatList_SourceIsNull_ArgumentNullExceptionThrown()
        {
            float[] listX = null;
            float[] listY = new float[] { 0, 1, 2.5F, 4.8F, 6.0F, 5.8F };

            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<ArgumentNullException>();

            listX = new float[] { 0, 1, 2, 3, 4, 5 };
            listY = null;

            comparison = () =>
            {
                listX.LinearRegression(listY);
            };


            comparison.ShouldThrow<ArgumentNullException>();
        }

        #endregion

        #region SourceIsEmptyCollection - InvalidOperationExceptionThrown

        [Fact]
        public void LinearRegressionOfDecimalList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            decimal[] listX = new decimal[] { };
            decimal[] listY = new decimal[] { };

            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void LinearRegressionOfDoubleList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            double[] listX = new double[] { };
            double[] listY = new double[] { };

            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void LinearRegressionOfFloatList_SourceIsEmptyCollection_InvalidOperationExceptionThrown()
        {
            float[] listX = new float[] { };
            float[] listY = new float[] { };

            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<InvalidOperationException>();
        }

        #endregion

        #region SourceIsNotEmptyAndTheSameLength -  LinearRegressionReturned

        [Fact]
        public void LinearRegressionOfDecimalList_SourceIsNotEmptyAndTheSameLength_LinearRegressionReturned()
        {
            var listX = new decimal[] { 0, 1, 2, 3, 4, 5 };
            var listY = new decimal[] { 0, 1, 2.5M, 4.8M, 6.0M, 5.8M };

            var result = listX.LinearRegression(listY);

            result.RSquared.Should().Be(0.9395349856463521406241478997M);
            result.YIntercept.Should().Be(0.0428571428571428571428571428M);
            result.Slope.Should().Be(1.3228571428571428571428571429M);
        }

        [Fact]
        public void LinearRegressionOfDoubleList_SourceIsNotEmptyAndTheSameLength_LinearRegressionReturned()
        {
            var listX = new double[] { 0, 1, 2, 3, 4, 5 };
            var listY = new double[] { 0, 1, 2.5, 4.8, 6.0, 5.8 };

            var result = listX.LinearRegression(listY);

            result.RSquared.Should().Be(0.9395349856463534);
            result.YIntercept.Should().Be(0.042857142857142261);
            result.Slope.Should().Be(1.3228571428571432);
        }

        [Fact]
        public void LinearRegressionOfFloatList_SourceIsNotEmptyAndTheSameLength_LinearRegressionReturned()
        {
            var listX = new float[] { 0, 1, 2, 3, 4, 5 };
            var listY = new float[] { 0, 1, 2.5F, 4.8F, 6.0F, 5.8F };

            var result = listX.LinearRegression(listY);

            result.RSquared.Should().Be(0.9395349F);
            result.YIntercept.Should().Be(0.04285693F);
            result.Slope.Should().Be(1.32285726F);
        }

        #endregion

        #region SourceIsNotEmptyButDifferentLengths -  ArgumentException

        [Fact]
        public void LinearRegressionOfDecimalList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            var listX = new decimal[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var listY = new decimal[] { 0, 1, 2.5M, 4.8M, 6.0M, 5.8M };


            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void LinearRegressionOfDoubleList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            var listX = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var listY = new double[] { 0, 1, 2.5, 4.8, 6.0, 5.8 };


            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void LinearRegressionOfFloatList_SourceIsNotEmptyButDifferentLengths_ArgumentExceptionThrown()
        {
            var listX = new float[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var listY = new float[] { 0, 1, 2.5F, 4.8F, 6.0F, 5.8F };


            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<ArgumentException>();
        }

        #endregion

        #region SourceCumulativePercentageToOverflow - OverflowExceptionThrown or Infinity returned

        [Fact]
        public void LinearRegressionOfDecimalList_SourceCumulativePercentageToOverflow_OverflowExceptionThrown()
        {
            var listX = new decimal[] { decimal.MaxValue, decimal.MaxValue };
            var listY = new decimal[] { decimal.MaxValue, decimal.MaxValue };

            Action comparison = () =>
            {
                listX.LinearRegression(listY);
            };

            comparison.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void LinearRegressionOfDoubleList_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {
            var listX = new double[] { double.MaxValue, double.MaxValue };
            var listY = new double[] { double.MaxValue, double.MaxValue };

            var result = listX.LinearRegression(listY);

            double.IsPositiveInfinity(result.RSquared).Should().BeFalse();
            double.IsPositiveInfinity(result.YIntercept).Should().BeFalse();
            double.IsPositiveInfinity(result.Slope).Should().BeFalse();
        }

        [Fact]
        public void LinearRegressionOfFloatList_SourceCumulativePercentageToOverflow_NotInfinityReturned()
        {

            IEnumerable<float> measure1 = new float[] { float.MaxValue, float.MaxValue };
            IEnumerable<float> measure2 = new float[] { float.MaxValue, float.MaxValue };

            var result = measure1.LinearRegression(measure2);

            float.IsPositiveInfinity(result.RSquared).Should().BeFalse();
            float.IsPositiveInfinity(result.YIntercept).Should().BeFalse();
            float.IsPositiveInfinity(result.Slope).Should().BeFalse();

        }

        #endregion

    }
}
