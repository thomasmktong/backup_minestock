using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;
using System.Text.RegularExpressions;

namespace FYP_ClusterStockData
{
    // if you are reading this, no matter who you are, i would like to express that this algorithm is very complex
    // and i have written this in a very messy manner, referring to my documentations about the algorithm is suggested, 
    // thanks very much, i die la die la die la die la die la die la die la die la die la die la die la die la die la...
    public class MotifHelper
    {
        private static double SIMILARITY_MULTIPER;

        public static List<Cluster> Cluster(List<Stock> stockList, int numberOfClusters, int minTimeInterval, string additionalArgs)
        {
            SIMILARITY_MULTIPER = double.Parse(additionalArgs);
            int numberOfGenus = 0;

            // check the number of genus
            foreach (Stock eachStock in stockList)
            {
                foreach (Tick eachTick in eachStock.priceList)
                {
                    numberOfGenus = ((GenusTick)eachTick).degreeOfChange > numberOfGenus ?
                        ((GenusTick)eachTick).degreeOfChange : numberOfGenus;
                }
                if (numberOfGenus > 0) break;
            }

            if (numberOfGenus == 0)
            {
                return new List<Cluster>();
            }

            numberOfGenus = numberOfGenus * 2 + 1;

            // eliminate the error of yahoo that extra data points may have been given
            foreach (Stock eachStock in stockList)
            {
                int noOfExtraTicks = eachStock.priceList.Count - minTimeInterval;
                for (int i = 0; i < noOfExtraTicks; i++)
                {
                    // removing the front element, not removing the i-th element
                    eachStock.priceList.RemoveAt(0);
                }
            }

            // build up the similarity table, this will be used for kmean
            Dictionary<string, double> similarityTable = GenerateAndDetect(numberOfGenus, minTimeInterval, stockList);

            // select random stock code as cluster centers
            List<Cluster> clusterList = new List<Cluster>();
            List<Dictionary<int, double>> clustersCenterList = null;
            Dictionary<Stock, int> stockClusterMapping = new Dictionary<Stock, int>();
            Dictionary<Stock, int> stockClusterMapping_T1 = null;
            Dictionary<Stock, int> stockClusterMapping_T2 = null;
            Random random = new Random();
            int test;

            for (int i = 0; i < numberOfClusters; i++)
            {
                Stock pointer = stockList.ElementAt(random.Next(stockList.Count));
                Console.WriteLine("MOTIF: Stock " + pointer.stockCode + " randomly selected for cluster " + i);

                if (stockClusterMapping.TryGetValue(pointer, out test))
                {
                    i--;
                    continue;
                }
                else
                {
                    stockClusterMapping.Add(pointer, i);
                }
            }

            foreach (Stock eachStock in stockList)
            {
                if (!stockClusterMapping.TryGetValue(eachStock, out test))
                {
                    stockClusterMapping.Add(eachStock, -1);
                }
            }

            int minimalDistanceCluster;
            double minimalDistanceClusterDistance;
            double thisRoundDistance;
            bool clusterElementChanged = true;

            // the comparison is performed iteratively until no more element migration between clusters are observed
            for (int iteration = 1; clusterElementChanged; iteration++)
            {
                // initiation - to recalculate the means (centers) of each clusters
                clusterElementChanged = false;
                clustersCenterList = CalculateClusterCenter(numberOfClusters, stockClusterMapping, similarityTable);

                // perform similarity calculations - for each stocks in the list
                for (int i = 0; i < stockList.Count; i++)
                {
                    minimalDistanceCluster = int.MaxValue;
                    minimalDistanceClusterDistance = double.MaxValue;

                    // compare with the center of each clusters
                    for (int j = 0; j < numberOfClusters; j++)
                    {
                        thisRoundDistance = CalculateDistance(stockList[i].stockCode, stockList, clustersCenterList[j], similarityTable);
                        Console.WriteLine("MOTIF: Stock " + stockList[i].stockCode + " vs cluster " + j + ", iteration " + iteration + ", distance " + thisRoundDistance);

                        if (thisRoundDistance < minimalDistanceClusterDistance)
                        {
                            minimalDistanceCluster = j;
                            minimalDistanceClusterDistance = thisRoundDistance;
                        }
                    }

                    // if the result is different from the master table, that means the reuslts has been changed
                    if (stockClusterMapping[stockList[i]] != minimalDistanceCluster)
                    {
                        stockClusterMapping[stockList[i]] = minimalDistanceCluster;
                        clusterElementChanged = true;
                    }
                }

                // empty cluster check
                for (int i = 0; i < numberOfClusters; i++)
                {
                    if (DirtyHelper.CheckWetherClusterHasNoStock(stockClusterMapping, i))
                    {
                        while (true)
                        {
                            int tobe = new Random().Next(stockList.Count);
                            if (!DirtyHelper.CheckWetherThisStockIsALonelyStock(stockClusterMapping, stockClusterMapping[stockList[tobe]]))
                            {
                                stockClusterMapping[stockList[tobe]] = i;
                                break;
                            }
                        }
                    }
                }

                // infinite loop check
                if (CompareDictionary(stockClusterMapping, stockClusterMapping_T1) || CompareDictionary(stockClusterMapping, stockClusterMapping_T2))
                {
                    clusterElementChanged = false;
                    Console.WriteLine("\nMOTIF: Infinite loop detected, will not go into next loop.");
                }
                else
                {
                    // if clusters are ok, copy as temp and go to next iteration
                    stockClusterMapping_T2 = stockClusterMapping_T1;
                    stockClusterMapping_T1 = CloneDictionary(stockClusterMapping);
                }

                // **********
                // Note: massive debug logging here, consider refactoring
                // **********

                Console.WriteLine("MOTIF: Iteration " + iteration + " done");

                if (iteration % 3 == 0 || !clusterElementChanged)
                {
                    Console.WriteLine("\nMOTIF: Iteration " + iteration + " result");

                    foreach (KeyValuePair<Stock, int> eachKYP in stockClusterMapping)
                    {
                        Console.Write("MOTIF: Stock " + eachKYP.Key.stockCode + ", cluster ");

                        if (stockClusterMapping_T2 != null)
                        {
                            Console.Write(stockClusterMapping_T2[eachKYP.Key] + "->");
                        }

                        if (stockClusterMapping_T1 != null)
                        {
                            Console.Write(stockClusterMapping_T1[eachKYP.Key] + "->");
                        }

                        Console.WriteLine(eachKYP.Value);
                    }

                    Console.WriteLine();

                    for (int i = 0; i < numberOfClusters; i++)
                    {
                        Console.WriteLine("MOTIF: Cluster " + i + " has " + NumberofElements(stockClusterMapping, i) + " stocks.");
                    }
                }

                Console.WriteLine();
            }

            // populate a list of clusters in returning format
            List<Cluster> toReturn = new List<Cluster>();

            for (int i = 0; i < numberOfClusters; i++)
            {
                Cluster thisCluster = new Cluster();
                thisCluster.clusterCode = i + 1;
                thisCluster.stockCodeList = new List<int>();
                thisCluster.centroid = new List<Tick>();

                // propulate the stock codes
                foreach (KeyValuePair<Stock, int> eachStockClusterKYP in stockClusterMapping)
                {
                    if (eachStockClusterKYP.Value == i)
                    {
                        thisCluster.stockCodeList.Add(eachStockClusterKYP.Key.stockCode);
                    }
                }

                foreach (KeyValuePair<int, double> seqOccuranceKYP in clustersCenterList[i])
                {
                    thisCluster.centroid.Add(new FakeTick(seqOccuranceKYP.Key + "", seqOccuranceKYP.Value));
                }

                toReturn.Add(thisCluster);
            }

            return toReturn;
        }

        // input number of genus and number in sequence, compute all the possible permutations
        public static Dictionary<string, double> GenerateAndDetect(int numberOfGenus,
            int maxNumberInSequence, List<Stock> stockList)
        {
            Dictionary<string, double> resultDict = new Dictionary<string, double>();
            int temp;
            double similarity;

            // initialize the result dictionary
            foreach (Stock eachStockA in stockList)
            {
                foreach (Stock eachStockB in stockList)
                {
                    if (eachStockA.stockCode == eachStockB.stockCode)
                    {
                        resultDict.Add(eachStockA.stockCode + "-" + eachStockA.stockCode,
                            Math.Pow(eachStockA.priceList.Count, SIMILARITY_MULTIPER));
                    }
                    else if (eachStockA.stockCode < eachStockB.stockCode)
                    {
                        temp = LCSHelper.GetLCS(SequenceString(eachStockA.priceList), SequenceString(eachStockB.priceList));
                        similarity = Math.Pow(temp, SIMILARITY_MULTIPER);
                        resultDict.Add(StocksKeyString(eachStockA.stockCode, eachStockB.stockCode), similarity);

                        Console.WriteLine("MOTIF: Stock " + eachStockA.stockCode + " and " + eachStockB.stockCode +
                            " has a common motif of length " + temp + ", similarity " + Math.Round(similarity, 2));
                    }
                }
            }

            return resultDict;
        }

        // method for calculating distance
        public static double CalculateDistance(int stockCode, List<Stock> stockList,
            Dictionary<int, double> clusterCenter, Dictionary<string, double> similarityTable)
        {
            double toReturn = 0.0;

            foreach (Stock eachStockToBeComparedWith in stockList)
            {
                string dictKey = StocksKeyString(stockCode, eachStockToBeComparedWith.stockCode);
                toReturn += Math.Pow(similarityTable[dictKey] - clusterCenter[eachStockToBeComparedWith.stockCode], 2);
            }

            return Math.Sqrt(toReturn);
        }

        // input the tick objects, convert them into strings
        public static string SequenceString(List<Tick> ticks)
        {
            string toReturn = "";
            foreach (Tick tick in ticks)
            {
                int i = ((GenusTick)tick).degreeOfChange;
                toReturn += Convert.ToChar(73 + i);
            }
            return toReturn;
        }

        // turn two stocks into a key of result dict
        public static string StocksKeyString(int firstStockCode, int secondStockCode)
        {
            return (firstStockCode < secondStockCode) ? firstStockCode + "-" + secondStockCode : secondStockCode + "-" + firstStockCode;
        }

        // method for recalculating cluster centers
        private static List<Dictionary<int, double>> CalculateClusterCenter(int numberOfClusters,
            Dictionary<Stock, int> stockClusterMapping, Dictionary<string, double> similarityTable)
        {
            List<Dictionary<int, double>> toReturn = new List<Dictionary<int, double>>();
            int hit = 0;

            for (int i = 0; i < numberOfClusters; i++)
            {
                Dictionary<int, double> clusterCenterPointList = new Dictionary<int, double>();
                hit = 0;

                // walk along the column
                foreach (KeyValuePair<Stock, int> stockClusterKYP in stockClusterMapping)
                {
                    if (stockClusterKYP.Value == i)
                    {
                        hit++;

                        // walk along the row
                        foreach (KeyValuePair<Stock, int> eachStockToBeComparedWith in stockClusterMapping)
                        {
                            double similarity = 0.0;
                            similarityTable.TryGetValue(StocksKeyString(stockClusterKYP.Key.stockCode, eachStockToBeComparedWith.Key.stockCode), out similarity);
                            double clusterPoint = 0.0;

                            if (!clusterCenterPointList.TryGetValue(eachStockToBeComparedWith.Key.stockCode, out clusterPoint))
                            {
                                clusterCenterPointList.Add(eachStockToBeComparedWith.Key.stockCode, similarity);
                            }
                            else
                            {
                                clusterCenterPointList[eachStockToBeComparedWith.Key.stockCode] += similarity;
                            }
                        }
                    }
                }

                // take the average
                foreach (KeyValuePair<Stock, int> eachStockToBeComparedWith in stockClusterMapping)
                {
                    clusterCenterPointList[eachStockToBeComparedWith.Key.stockCode] /= hit;
                }

                toReturn.Add(clusterCenterPointList);
            }

            return toReturn;
        }

        // method for comparing two dictionaries
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

        // method for copying a dictionary
        private static Dictionary<Stock, int> CloneDictionary(Dictionary<Stock, int> dict)
        {
            Dictionary<Stock, int> dictNew = new Dictionary<Stock, int>(dict.Count);

            foreach (KeyValuePair<Stock, int> stockKVP in dict)
            {
                dictNew.Add(stockKVP.Key, stockKVP.Value);
            }

            return dictNew;
        }

        // method for getting the count of a specific cluster, debug purpose
        private static int NumberofElements(Dictionary<Stock, int> clusters, int clusterID)
        {
            int toReturn = 0;
            foreach (int i in clusters.Values)
            {
                if (i == clusterID) toReturn++;
            }
            return toReturn;
        }
    }
}
