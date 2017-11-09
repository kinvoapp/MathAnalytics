using System;
using System.Collections.Generic;

namespace MathAnalytics.Test.Helpers
{
    public static class DataGenerator
    {
        public static IEnumerable<TimeSerie<T>> CreateTimeSerieList<T>()
        {
            var _sampleTimeSerie = new List<TimeSerie<T>>();

            TimeSerie<T> _dailyGrowthObject = new TimeSerie<T>(new DateTime(2012, 01, 01), GetValue<T>(11.246551));
            _dailyGrowthObject.GrowthRate = GetValue<T>(4.6532690000);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie<T>(new DateTime(2012, 01, 03), GetValue<T>(8.246551));
            _dailyGrowthObject.GrowthRate = GetValue<T>(1.6532690000);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie<T>(new DateTime(2012, 01, 07), GetValue<T>(6.246551));
            _dailyGrowthObject.GrowthRate = GetValue<T>(2.6532690000);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie<T>(new DateTime(2012, 01, 12), GetValue<T>(3.246551));
            _dailyGrowthObject.GrowthRate = GetValue<T>(6.532690000);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            _dailyGrowthObject = new TimeSerie<T>(new DateTime(2012, 01, 12), GetValue<T>(2.46551));
            _dailyGrowthObject.GrowthRate = GetValue<T>(5.32690000);
            _sampleTimeSerie.Add(_dailyGrowthObject);

            return _sampleTimeSerie;
        }

        public static IEnumerable<WeightedItem<T>> CreateWeightedItemsList<T>()
        {
            var weightedList = new List<WeightedItem<T>>();

            weightedList.Add(new WeightedItem<T>(GetValue<T>(6.532690000), GetValue<T>(150)));
            weightedList.Add(new WeightedItem<T>(GetValue<T>(8.789250000), GetValue<T>(80)));
            weightedList.Add(new WeightedItem<T>(GetValue<T>(9.847520000), GetValue<T>(35)));
            weightedList.Add(new WeightedItem<T>(GetValue<T>(16.51326900), GetValue<T>(10)));

            return weightedList;
        }

        private static T GetValue<T>(double value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
