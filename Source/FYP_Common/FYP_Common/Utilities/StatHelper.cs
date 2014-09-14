using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FYP_Common
{
    public class StatHelper
    {
        public static double CountTicksInYear(List<Tick> tickList)
        {
            List<int> countOfTicksPerYear = new List<int>();
            int countOfTicks = 1;
            int temp = 0;

            foreach (Tick eachTick in tickList)
            {
                if (eachTick.Time.Year != temp)
                {
                    // a new year
                    countOfTicksPerYear.Add(countOfTicks == 1 ? 250 : countOfTicks);
                    temp = eachTick.Time.Year;
                    countOfTicks = 1;
                }
                else
                {
                    // countinue to count
                    countOfTicks++;
                }
            }

            countOfTicksPerYear.Sort();
            return countOfTicksPerYear.ElementAt(countOfTicksPerYear.Count - 1);
        }

        public static double GetDailyArithReturn(List<Tick> tickList)
        {
            double arithMean = 0.0;

            foreach (Tick eachTick in tickList)
            {
                if (!eachTick.GetType().IsEquivalentTo(typeof(NumericTick)))
                {
                    return 0.0;
                }

                arithMean += ((NumericTick)eachTick).adjustedChange / 100;
            }

            arithMean /= tickList.Count;
            return arithMean;
        }

        public static double GetAnnualArithReturn(List<Tick> tickList)
        {
            return GetDailyArithReturn(tickList) * CountTicksInYear(tickList);
        }

        public static double GetDailyGeoReturn(List<Tick> tickList)
        {
            double geoMean = 1.0;

            foreach (Tick eachTick in tickList)
            {
                if (!eachTick.GetType().IsEquivalentTo(typeof(NumericTick)))
                {
                    return 0.0;
                }

                geoMean *= (1 + ((NumericTick)eachTick).adjustedChange / 100);
            }

            geoMean = Math.Pow(geoMean, (double)1 / tickList.Count) - 1;
            return geoMean;
        }

        public static double GetAnnualGeoReturn(List<Tick> tickList)
        {
            return Math.Pow(1 + GetDailyGeoReturn(tickList), CountTicksInYear(tickList)) - 1;
        }

        public static double GetDailyVariance(List<Tick> tickList)
        {
            double avg = GetDailyArithReturn(tickList);
            double diff = 0.0;

            foreach (Tick eachTick in tickList)
            {
                if (!eachTick.GetType().IsEquivalentTo(typeof(NumericTick)))
                {
                    return 0.0;
                }

                diff += Math.Pow(((NumericTick)eachTick).adjustedChange / 100 - avg, 2);
            }

            return diff / tickList.Count;
        }

        public static double GetDailySD(List<Tick> tickList)
        {
            return Math.Sqrt(GetDailyVariance(tickList));
        }

        public static double GetAnnualSD(List<Tick> tickList)
        {
            return GetDailySD(tickList) * Math.Sqrt(CountTicksInYear(tickList));
        }

        public static double GetDailyCorrelation(List<Tick> stockTickList, List<Tick> indexTickList)
        {
            return GetDailyCovariance(stockTickList, indexTickList) / (GetDailySD(stockTickList) * GetDailySD(indexTickList));
        }

        public static double GetDailyCovariance(List<Tick> stockTickList, List<Tick> indexTickList)
        {
            if (stockTickList.Count < indexTickList.Count)
            {
                indexTickList = indexTickList.GetRange(indexTickList.Count - stockTickList.Count, stockTickList.Count);
            }
            else if (stockTickList.Count > indexTickList.Count)
            {
                return 0.0;
            }

            double expectedStockReturn = GetDailyArithReturn(stockTickList);
            double expectedIndexReturn = GetDailyArithReturn(indexTickList);
            double diff = 0;

            for (int i = 0; i < stockTickList.Count; i++)
            {
                diff += (((NumericTick)stockTickList[i]).adjustedChange / 100 - expectedStockReturn) *
                    (((NumericTick)indexTickList[i]).adjustedChange / 100 - expectedIndexReturn);
            }

            return diff / stockTickList.Count;
        }

        public static double[,] GetCovarianceMatrix(List<Tick>[] tickList)
        {
            int count = tickList.Length;
            double[,] covariance = new double[count, count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j)
                    {
                        covariance[i, j] = Math.Pow(GetDailySD(tickList[i]), 2);
                    }
                    else if (i < j)
                    {
                        covariance[i, j] = StatHelper.GetDailyCovariance(tickList[i], tickList[j]);
                        covariance[j, i] = covariance[i, j];
                    }
                }
            }

            return covariance;
        }

        public static double GetPortfolioReturn(List<Portfolio> selectedStockList, double[] valueOfStockList, double totalValue)
        {
            double pYield = 0.0;

            for (int i = 0; i < selectedStockList.Count; i++)
            {
                pYield += (double)valueOfStockList[i] / totalValue * (double)selectedStockList[i].annualReturn / 100;
            }

            return pYield;
        }

        public static double GetPortfolioSD(List<Portfolio> selectedStockList, double[] valueOfStockList, double totalValue, double[,] covarianceMatrix)
        {
            double pVol = 0.0;

            for (int i = 0; i < selectedStockList.Count; i++)
            {
                for (int j = 0; j < selectedStockList.Count; j++)
                {
                    if (i == j)
                    {
                        pVol += covarianceMatrix[i, i] * Math.Pow((double)valueOfStockList[i] / totalValue, 2);
                    }
                    else
                    {
                        pVol += covarianceMatrix[i, j] * (double)valueOfStockList[i] / totalValue * (double)valueOfStockList[j] / totalValue;
                    }
                }
            }

            return Math.Sqrt(pVol) * Math.Sqrt(250);
        }

        public static double GetBeta(List<Tick> stockTickList, List<Tick> indexTickList)
        {
            if (stockTickList.Count < indexTickList.Count)
            {
                indexTickList = indexTickList.GetRange(indexTickList.Count - stockTickList.Count, stockTickList.Count);
            }
            else if (stockTickList.Count > indexTickList.Count)
            {
                return 0.0;
            }

            return GetDailyCovariance(stockTickList, indexTickList) / GetDailyVariance(indexTickList);
        }

        public static double GetHistPercentVaR(List<Tick> tickList, double prob)
        {
            List<double> dailyPnlList = new List<double>();

            foreach (Tick eachTick in tickList)
            {
                if (!eachTick.GetType().IsEquivalentTo(typeof(NumericTick)))
                {
                    return 0.0;
                }

                dailyPnlList.Add(((NumericTick)eachTick).adjustedChange / 100);
            }

            dailyPnlList.Sort();

            double temp1 = dailyPnlList.Count * prob;
            double temp2 = Math.Truncate(temp1);

            if (temp2 == 0)
            {
                return dailyPnlList[(int)temp2] * temp1;
            }
            else
            {
                double upperBound = dailyPnlList[(int)temp2];
                double lowerBound = dailyPnlList[(int)temp2 - 1];
                return Math.Abs(upperBound - lowerBound) * (temp1 - temp2) + lowerBound;
            }
        }

        public static double GetHistDollarVaR(List<Tick> tickList, double prob)
        {
            return GetLastPrice(tickList) * GetHistPercentVaR(tickList, prob);
        }

        public static double GetParaPercentVaR(List<Tick> tickList, double prob)
        {
            return GetDailySD(tickList) * GetNormsInv(prob);
        }

        public static double GetParaDollarVaR(List<Tick> tickList, double prob)
        {
            return GetLastPrice(tickList) * GetParaPercentVaR(tickList, prob);
        }

        public static double GetLastPrice(List<Tick> tickList)
        {
            return ((NumericTick)tickList[tickList.Count - 1]).close;
        }

        public static double GetNormsInv(double p)
        {
            // **********
            // normsinv from http://home.online.no/~pjacklam/notes/invnorm/impl/misra/normsinv.html
            // **********

            // Coefficients in rational approximations
            double[] a = new double[] {-3.969683028665376e+01, 2.209460984245205e+02,
                              -2.759285104469687e+02, 1.383577518672690e+02,
                              -3.066479806614716e+01, 2.506628277459239e+00};

            double[] b = new double[] {-5.447609879822406e+01, 1.615858368580409e+02,
                              -1.556989798598866e+02, 6.680131188771972e+01,
                              -1.328068155288572e+01};

            double[] c = new double[] {-7.784894002430293e-03, -3.223964580411365e-01,
                              -2.400758277161838e+00, -2.549732539343734e+00,
                              4.374664141464968e+00, 2.938163982698783e+00};

            double[] d = new double[] {7.784695709041462e-03, 3.224671290700398e-01,
                               2.445134137142996e+00, 3.754408661907416e+00};

            // Define break-points.
            double plow = 0.02425;
            double phigh = 1 - plow;
            double q;

            // Rational approximation for lower region:
            if (p < plow)
            {
                q = Math.Sqrt(-2 * Math.Log(p));
                return (((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                                                ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }

            // Rational approximation for upper region:
            if (phigh < p)
            {
                q = Math.Sqrt(-2 * Math.Log(1 - p));
                return -(((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                                                       ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }

            // Rational approximation for central region:
            q = p - 0.5;
            double r = q * q;
            return (((((a[0] * r + a[1]) * r + a[2]) * r + a[3]) * r + a[4]) * r + a[5]) * q /
                                     (((((b[0] * r + b[1]) * r + b[2]) * r + b[3]) * r + b[4]) * r + 1);
        }
    }
}
