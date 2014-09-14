using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;

namespace FYP_CategorizeStockData
{
    public class AboveBelowAvgHelper
    {
        public static List<Stock> Categorize(List<Stock> nonCategorizedStockList, int numberOfGenus, int numberOfDaysAsReferencingPeriod, string additionalArgs)
        {
            bool notUsingReferiod = (numberOfDaysAsReferencingPeriod == 0);
            Dictionary<Stock, List<double>> avgPriceOfRefPeriodDict = new Dictionary<Stock, List<double>>();

            double error;
            double pricePeak;
            double priceTrough;
            double priceAvg;
            double priceSum;
            int refPeriodPointer;
            int noOfPeriod;
            int denominator;

            error = 0.01 / numberOfGenus;
            Console.WriteLine("\nNumber of genus: " + numberOfGenus + ", number of days as ref period: " + numberOfDaysAsReferencingPeriod);
            numberOfGenus = (int)Math.Floor((double)numberOfGenus / 2);

            // calculate the average price of each refencing period
            foreach (Stock eachStock in nonCategorizedStockList)
            {
                if (notUsingReferiod)
                {
                    numberOfDaysAsReferencingPeriod = eachStock.priceList.Count;
                }

                List<double> avgPriceOfRefPeriodList = new List<double>();
                priceSum = 0.0;
                denominator = 0;
                noOfPeriod = (int)Math.Ceiling(eachStock.priceList.Count / (double)numberOfDaysAsReferencingPeriod);

                Console.WriteLine("\nABVBLW: Stock " + eachStock.stockCode + " has " + noOfPeriod + " referencing period");
                Console.WriteLine("ABVBLW: Stock " + eachStock.stockCode + ", tick #0, start of a referencing period");

                for (int i = 0; i < eachStock.priceList.Count; i++)
                {
                    if (numberOfDaysAsReferencingPeriod != 0 && i != 0 && i % numberOfDaysAsReferencingPeriod == 0)
                    {
                        // end of a referencing period, take the average of these prices and add to the list
                        avgPriceOfRefPeriodList.Add(priceSum / denominator);
                        priceSum = 0.0;
                        denominator = 0;

                        Console.WriteLine("ABVBLW: Stock " + eachStock.stockCode + ", tick #" + i + ", start of a referencing period");
                    }

                    // in the referencing period, add the price to sum
                    priceSum += ((NumericTick)eachStock.priceList[i]).adjustedClose;
                    denominator++;
                }

                if (denominator > 0)
                {
                    avgPriceOfRefPeriodList.Add(priceSum / denominator);
                }

                avgPriceOfRefPeriodDict.Add(eachStock, avgPriceOfRefPeriodList);
            }

            Console.WriteLine();

            // discretize the stock price according to their own referencing period average price
            foreach (Stock eachStock in nonCategorizedStockList)
            {
                noOfPeriod = (int)Math.Ceiling(eachStock.priceList.Count / (double)numberOfDaysAsReferencingPeriod);
                refPeriodPointer = -1;
                priceAvg = -0.1;
                List<Tick> refPeriodTickList = null;
                List<Tick> categorizedStockList = new List<Tick>();

                for (int i = 0; i < eachStock.priceList.Count; i++)
                {
                    if (numberOfDaysAsReferencingPeriod != 0 && i % numberOfDaysAsReferencingPeriod == 0)
                    {
                        // get the average of this referencing period from the list
                        refPeriodPointer = (int)Math.Floor(i / (double)numberOfDaysAsReferencingPeriod);
                        priceAvg = avgPriceOfRefPeriodDict[eachStock][refPeriodPointer];

                        if (refPeriodPointer + 1 != noOfPeriod)
                        {
                            refPeriodTickList = eachStock.priceList.GetRange(refPeriodPointer * numberOfDaysAsReferencingPeriod, numberOfDaysAsReferencingPeriod);
                        }
                        else
                        {
                            refPeriodTickList = eachStock.priceList.GetRange(refPeriodPointer * numberOfDaysAsReferencingPeriod, eachStock.priceList.Count - refPeriodPointer * numberOfDaysAsReferencingPeriod);
                        }
                    }

                    findPricePeakTrough(refPeriodTickList, out pricePeak, out priceTrough);

                    if (i % numberOfDaysAsReferencingPeriod == 0)
                    {
                        Console.WriteLine("ABVBLW: Stock " + eachStock.stockCode + ", Ref P #" + refPeriodPointer +
                            ", average: " + priceAvg + ", peak: " + pricePeak + ", trough: " + priceTrough);
                    }

                    // divide the interval
                    NumericTick thisNumericTick = (NumericTick)eachStock.priceList[i];
                    GenusTick convertedGenusTick = new GenusTick();
                    convertedGenusTick.id = thisNumericTick.id;
                    convertedGenusTick.Time = thisNumericTick.Time;

                    if (Math.Abs(thisNumericTick.adjustedClose - priceAvg) / priceAvg <= error)
                    {
                        convertedGenusTick.degreeOfChange = 0;
                    }
                    else if (thisNumericTick.adjustedClose > priceAvg)
                    {
                        for (int j = 0; j < numberOfGenus; j++)
                        {
                            if (thisNumericTick.adjustedClose > priceAvg + ((pricePeak - priceAvg) * j / numberOfGenus))
                            {
                                convertedGenusTick.degreeOfChange = j + 1;
                            }
                        }
                    }
                    else if (thisNumericTick.adjustedClose < priceAvg)
                    {
                        for (int j = 0; j < numberOfGenus; j++)
                        {
                            if (thisNumericTick.adjustedClose < priceAvg - ((priceAvg - priceTrough) * j / numberOfGenus))
                            {
                                convertedGenusTick.degreeOfChange = -j - 1;
                            }
                        }
                    }

                    categorizedStockList.Add(convertedGenusTick);
                }

                eachStock.priceList = categorizedStockList;
            }

            return nonCategorizedStockList;
        }

        public static void findPricePeakTrough(List<Tick> priceList, out double peak, out double trough)
        {
            peak = double.MinValue;
            trough = double.MaxValue;

            foreach (Tick tick in priceList)
            {
                if (double.IsInfinity(((NumericTick)tick).adjustedClose))
                {
                    continue;
                }

                peak = ((NumericTick)tick).adjustedClose > peak ? ((NumericTick)tick).adjustedClose : peak;
                trough = ((NumericTick)tick).adjustedClose < trough ? ((NumericTick)tick).adjustedClose : trough;
            }
        }
    }
}
