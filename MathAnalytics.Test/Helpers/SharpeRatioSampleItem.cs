using System;

namespace MathAnalytics.Test.Helpers
{
    public class SharpeRatioSampleItem<T>
    {
        public SharpeRatioSampleItem(DateTime referenceDate, T portfolioReturn, T riskFreeRate)
        {
            this.ReferenceDate = referenceDate;
            this.PortfolioReturn = portfolioReturn;
            this.RiskFreeRate = riskFreeRate;
        }

        public DateTime ReferenceDate { get; set; }

        public T PortfolioReturn { get; set; }
        
        public T RiskFreeRate { get; set; }
    }
}
