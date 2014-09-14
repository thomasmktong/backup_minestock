using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;
using System.IO;

namespace FYP_CategorizeStockData
{
    public class UpDownChangeHelper
    {
        public static List<Stock> Categorize(List<Stock> nonCategorizedStockList, int numberOfGenus, int numberOfDaysAsReferencingPeriod, string additionalArgs)
        {
            List<Stock> toReturn = new List<Stock>();
            numberOfGenus = (int)Math.Floor(numberOfGenus / 2.0);
            double peak;
            double trough;

            foreach (Stock eachStock in nonCategorizedStockList)
            {
                findChangePeakTrough(eachStock.priceList, out peak, out trough);
                List<Tick> priceList = new List<Tick>();

                Console.WriteLine("UPDOWN: Stock " + eachStock.stockCode + " has a peak of " + peak + ", a trough of " + trough);

                foreach (Tick tick in eachStock.priceList)
                {
                    GenusTick genusTick = new GenusTick();
                    genusTick.id = tick.id;
                    genusTick.Time = tick.Time;
                    genusTick.degreeOfChange = 0;

                    if (!double.IsInfinity(((NumericTick)tick).adjustedChange))
                    {
                        if (((NumericTick)tick).adjustedChange > 0)
                        {
                            for (int i = 0; i < numberOfGenus; i++)
                            {
                                if (((NumericTick)tick).adjustedChange > (Math.Max(peak,trough) * i / numberOfGenus))
                                {
                                    genusTick.degreeOfChange = i + 1;
                                }
                            }
                        }
                        else if (((NumericTick)tick).adjustedChange < 0)
                        {
                            for (int i = 0; i < numberOfGenus; i++)
                            {
                                if (((NumericTick)tick).adjustedChange < (Math.Max(peak, trough) * i / numberOfGenus))
                                {
                                    genusTick.degreeOfChange = -i - 1;
                                }
                            }
                        }
                    }

                    priceList.Add(genusTick);
                }

                eachStock.priceList = priceList;
            }

            return nonCategorizedStockList;
        }

        public static void findChangePeakTrough(List<Tick> priceList, out double peak, out double trough)
        {
            peak = 0.0;
            trough = 0.0;

            foreach (Tick tick in priceList)
            {
                if (double.IsInfinity(((NumericTick)tick).adjustedChange))
                {
                    continue;
                }

                peak = ((NumericTick)tick).adjustedChange > peak ? ((NumericTick)tick).adjustedChange : peak;
                trough = ((NumericTick)tick).adjustedChange < trough ? ((NumericTick)tick).adjustedChange : trough;
            }
        }
    }
}
