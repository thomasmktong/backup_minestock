using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;

namespace FYP_ClusterStockData
{
    // this algorithm basically perform clustering in the stocks into different groups using the kmean method
    class KMeanHelper
    {
        // refactored, public
        // stockList is the list of stocks which will be processed by this algorithm, stocks which has too little price ticks are omitted
        // numberOfClusters is the number of clusters that you are willing to seperatate the stocks
        // minNoOfTicks is the expected minimum number of ticks that the stock in stockList possess
        // additionalArgs - no use in this algorithm
        public static List<Cluster> Cluster(List<Stock> stockList, int numberOfClusters, int minNoOfTicks, string additionalArgs)
        {
            Dictionary<Stock, int> clusters = new Dictionary<Stock, int>();
            foreach (Stock eachStock in stockList)
            {
                clusters.Add(eachStock, 0);
            }
            return Cluster(clusters, numberOfClusters, minNoOfTicks);
        }

        private static List<Cluster> Cluster(Dictionary<Stock, int> clusters, int numberOfClusters, int minTimeInterval)
        {
            List<KeyValuePair<Stock, int>> stocksList = clusters.ToList();
            List<List<Tick>> centroidsList = new List<List<Tick>>();
            List<int> randomList = new List<int>();
            Random random = new Random();

            // temp variables
            int randomInt;
            int tempInt;
            double tempDbl;
            Stock loopingStock;

            // by blocking the initial assigned element to move between clusters, there may be cases that the 
            // algorithm will move other stocks between 2 clusters forever and try to achieve the optimum. By
            // detecting whether the current stock cluster mapping same as in the last 2 loops, we can break
            // the program if this case is encoutered.
            Dictionary<Stock, int> clusters_oneTimeBefore = null;
            Dictionary<Stock, int> clusters_twoTimeBefore = null;

            // randomly assign some stocks into first element of clusters
            for (int i = 0; i < numberOfClusters; i++)
            {
                do
                {
                    randomInt = random.Next(stocksList.Count);
                    clusters.TryGetValue(stocksList.ElementAt(randomInt).Key, out tempInt);
                } while (tempInt != 0);

                loopingStock = stocksList.ElementAt(randomInt).Key;
                clusters.Remove(loopingStock);
                clusters.Add(loopingStock, i + 1);

                randomList.Add(loopingStock.stockCode);
                Console.WriteLine("K-mean: Stock " + loopingStock.stockCode + " randomly selected for cluster " + (i + 1));

                List<Tick> ticksList = new List<Tick>();

                // copy the historical price of the stocks to become centroids of clusters
                for (int j = loopingStock.priceList.Count - minTimeInterval; j < loopingStock.priceList.Count; j++)
                {
                    NumericTick newTick = new NumericTick();
                    newTick.change = ((NumericTick)loopingStock.priceList.ElementAt(j)).change;
                    newTick.Time = loopingStock.priceList.ElementAt(j).Time;
                    ticksList.Add(newTick);
                }

                centroidsList.Add(ticksList);
            }

            // compare each stock with cluster centroids
            bool exit = false;

            // debug counter, to indicate which cluster we are in
            randomInt = 0;

            while (!exit)
            {
                randomInt++;
                exit = true;

                foreach (KeyValuePair<Stock, int> stockKYP in stocksList)
                {
                    double minDistance = 0.0;
                    int minDistanceCluster = 0;

                    for (int i = 0; i < centroidsList.Count; i++)
                    {
                        tempDbl = Distance(stockKYP.Key.priceList, centroidsList.ElementAt(i),
                            stockKYP.Key.stockCode + "", (i + 1) + "", randomInt + "");

                        if (minDistanceCluster == 0 || tempDbl < minDistance)
                        {
                            minDistance = tempDbl;
                            minDistanceCluster = i + 1;
                        }
                    }

                    // if any cluster assignment of a stock changed, iterate the loop again
                    int j;
                    clusters.TryGetValue(stockKYP.Key, out j);

                    if (!randomList.Exists(delegate(int k) { return k == stockKYP.Key.stockCode; }))
                    {
                        if (j != minDistanceCluster)
                        {
                            clusters.Remove(stockKYP.Key);
                            clusters.Add(stockKYP.Key, minDistanceCluster);
                            exit = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("K-mean: Initially selected element, distance to debugging purpose only.");
                    }
                }

                // recalculate centroid
                List<Tick> ticksList;
                int memberInCluster;
                centroidsList.Clear();

                for (int i = 0; i < numberOfClusters; i++)
                {
                    ticksList = new List<Tick>();
                    memberInCluster = 0;
                    for (int j = 0; j < minTimeInterval; j++)
                    {
                        ticksList.Add(new NumericTick());
                    }

                    foreach (KeyValuePair<Stock, int> stockKYP in clusters)
                    {
                        if (stockKYP.Value == (i + 1))
                        {
                            loopingStock = stockKYP.Key;
                            memberInCluster++;

                            int k = loopingStock.priceList.Count - minTimeInterval;
                            for (int j = k; j < loopingStock.priceList.Count; j++)
                            {
                                // **********
                                // Note: healthcheck should be made to confirm consistancy of date values
                                // **********

                                NumericTick newTick = (NumericTick)ticksList.ElementAt(j - k);
                                newTick.change += ((NumericTick)loopingStock.priceList.ElementAt(j)).change;
                                newTick.Time = loopingStock.priceList.ElementAt(j).Time;
                            }
                        }
                    }

                    foreach (NumericTick eachTick in ticksList)
                    {
                        eachTick.change = eachTick.change / memberInCluster;
                    }
                    centroidsList.Add(ticksList);
                }

                // infinite loop check
                if (CompareDictionary(clusters, clusters_oneTimeBefore) || CompareDictionary(clusters, clusters_twoTimeBefore))
                {
                    exit = true;
                    Console.WriteLine("\nK-mean: Infinite loop detected, will not go into next loop.");
                }
                else
                {
                    // if clusters are ok, copy as temp and go to next iteration
                    clusters_twoTimeBefore = clusters_oneTimeBefore;
                    clusters_oneTimeBefore = CloneDictionary(clusters);
                }

                // **********
                // Note: massive debug logging here, consider refactoring
                // **********

                Console.WriteLine("\nK-mean: Iteration " + randomInt + " result");

                foreach (KeyValuePair<Stock, int> eachKYP in clusters)
                {
                    Console.WriteLine("K-mean: Stock " + eachKYP.Key.stockCode + " belongs to cluster " + eachKYP.Value);
                }

                for (int i = 1; i <= numberOfClusters; i++)
                {
                    Console.WriteLine("K-mean: Cluster " + i + " has " + NumberofElements(clusters, i) + " stocks.");
                }

                Console.WriteLine();
            }

            // return calculation result
            List<Cluster> clusterList = new List<Cluster>();

            for (int i = 0; i < centroidsList.Count; i++)
            {
                Cluster tempCluster = new Cluster();
                tempCluster.centroid = centroidsList.ElementAt(i);
                tempCluster.stockCodeList = new List<int>();
                tempCluster.clusterCode = i + 1;

                foreach (KeyValuePair<Stock, int> eachKYP in clusters)
                {
                    if (eachKYP.Value == tempCluster.clusterCode)
                    {
                        tempCluster.stockCodeList.Add(eachKYP.Key.stockCode);
                    }
                }

                clusterList.Add(tempCluster);
            }

            return clusterList;
        }

        // debug version
        private static double Distance(List<Tick> list1, List<Tick> list2, string debug1, string debug2, string debug3)
        {
            double toReturn = Distance(list1, list2);
            if (true)
            {
                Console.WriteLine("K-mean: Stock " + debug1 + " vs cluster " + debug2 + ", iteration " + debug3 + ", distance = " + toReturn);
            }
            return toReturn;
        }

        private static double Distance(List<Tick> list1, List<Tick> list2)
        {
            double sum = 0;

            // **********
            // Note: for-loop does not require 'equal' condition because the first change is INF
            // **********

            for (int i = Math.Max(list1.Count, list2.Count) - 1; i > Math.Abs(list1.Count - list2.Count); i--)
            {
                sum += Math.Pow(((NumericTick)list1.ElementAt(i - MiscHelper.ReturnZeroIfNegative(list1.Count - list2.Count))).change
                    - ((NumericTick)list2.ElementAt(i - MiscHelper.ReturnZeroIfNegative(list1.Count - list2.Count))).change, 2);
            }

            return Math.Sqrt(sum);
        }

        private static int NumberofElements(Dictionary<Stock, int> clusters, int clusterID)
        {
            int toReturn = 0;
            foreach (int i in clusters.Values)
            {
                if (i == clusterID) toReturn++;
            }
            return toReturn;
        }

        private static Dictionary<Stock, int> CloneDictionary(Dictionary<Stock, int> dict)
        {
            Dictionary<Stock, int> dictNew = new Dictionary<Stock, int>(dict.Count);

            foreach (KeyValuePair<Stock, int> stockKVP in dict)
            {
                dictNew.Add(stockKVP.Key, stockKVP.Value);
            }

            return dictNew;
        }

        private static bool CompareDictionary(Dictionary<Stock, int> dict1, Dictionary<Stock, int> dict2)
        {
            if (dict1 == null || dict2 == null)
            {
                return false;
            }
            int value;

            foreach (KeyValuePair<Stock, int> stockKVP in dict1)
            {
                if (dict2.TryGetValue(stockKVP.Key, out value) && stockKVP.Value == value)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

    }
}
