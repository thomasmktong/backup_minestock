using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;

namespace FYP_ClusterStockData
{
    class TempCheckHelper
    {
        public static List<Cluster> Cluster(List<Stock> stockList, int numberOfClusters, int minTimeInterval, string additionalArgs)
        {
            int numberOfGenus = 0;

            // check the number of genus
            for (int i = 0; i < stockList.Count; i++)
            {
                numberOfGenus = 0;

                foreach (Tick tick in stockList[i].priceList)
                {
                    numberOfGenus = Math.Abs(((GenusTick)tick).degreeOfChange) > numberOfGenus ?
                        Math.Abs(((GenusTick)tick).degreeOfChange) : numberOfGenus;
                }

                numberOfGenus = numberOfGenus * 2 + 1;

                if (5 != numberOfGenus && 1 != numberOfGenus)
                {
                    Console.WriteLine(stockList[i].stockCode);
                }
            }

            Console.WriteLine();

            return null;
        }
    }
}
