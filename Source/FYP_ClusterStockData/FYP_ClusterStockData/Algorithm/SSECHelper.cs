using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;

namespace FYP_ClusterStockData
{
    // Modified version of UPSEC - algorithm by Keith for DNA protein sequence
    class SSECHelper
    {
        // stockList is the list of stocks which will be processed by this algorithm, stocks which has too little price ticks are omitted
        // numberOfClusters is the number of clusters that you are willing to seperatate the stocks
        // minNoOfTicks is the expected minimum number of ticks that the stock in stockList possess
        // additionalArgs - number of ticks in a defined sequence
        public static List<Cluster> Cluster(List<Stock> stockList, int numberOfClusters, int minTimeInterval, string additionalArgs)
        {
            int numberOfGenus = 0;
            int numberInSequence = 0;

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

            // additional question, number of ticks in a defined sequence
            if (!int.TryParse(additionalArgs, out numberInSequence))
            {
                Console.WriteLine("\nNumber of ticks in a denfined sequence: ");
                numberInSequence = int.Parse(Console.ReadLine());
            }

            // determine all possible combination in a sequence
            List<string> possibleSequences = SequenceString(numberOfGenus, numberInSequence);
            List<Dictionary<string, double>> clustersCenterList = null;

            // count the occourance of sequences of each stocks
            Dictionary<Stock, Dictionary<string, int>> masterDict1 = new Dictionary<Stock, Dictionary<string, int>>();

            foreach (Stock eachStock in stockList)
            {
                Dictionary<string, int> stockSequenceDict = SeqListToIntDict(possibleSequences);

                // count the occourance of sequences of each stocks
                for (int i = 0; i < eachStock.priceList.Count - numberInSequence; i++)
                {
                    Tick[] ticks = new Tick[numberInSequence];
                    for (int j = 0; j < numberInSequence; j++)
                    {
                        ticks[j] = eachStock.priceList.ElementAt(i + j);
                    }

                    // int count = 0;
                    // string sequence = SequenceString(ticks);
                    // stockSequenceDict.TryGetValue(sequence, out count);
                    // stockSequenceDict.Remove(sequence);
                    // stockSequenceDict.Add(sequence, count + 1);
                    stockSequenceDict[SequenceString(ticks)] += 1;
                }

                Console.WriteLine();

                // output the result to sysout or log
                foreach (KeyValuePair<string, int> eachKYP in stockSequenceDict)
                {
                    if (eachKYP.Value != 0)
                    {
                        Console.WriteLine("SSEC: Stock " + eachStock.stockCode +
                            " has the sequence " + eachKYP.Key + " occurred " + eachKYP.Value + " times");
                    }
                }

                // add the the master table for future similarity calculations
                masterDict1.Add(eachStock, stockSequenceDict);
            }

            // define the clusters with randomly defining a stock into each of them
            Dictionary<Stock, int> masterDict2 = new Dictionary<Stock, int>(); // -- t
            Dictionary<Stock, int> masterDict3 = null; // -- t-1
            Dictionary<Stock, int> masterDict4 = null; // -- t-2
            Random random = new Random();
            int test = -1;

            for (int i = 0; i < numberOfClusters; i++)
            {
                Stock pointer = stockList.ElementAt(random.Next(stockList.Count));
                Console.WriteLine("SSEC: Stock " + pointer.stockCode + " randomly selected for cluster " + i);

                if (masterDict2.TryGetValue(pointer, out test))
                {
                    i--;
                    continue;
                }
                else
                {
                    masterDict2.Add(pointer, i);
                }
            }

            foreach (Stock eachStock in stockList)
            {
                if (!masterDict2.TryGetValue(eachStock, out test))
                {
                    masterDict2.Add(eachStock, -1);
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
                clustersCenterList = CalculateClusterCenter(possibleSequences, masterDict1, masterDict2, numberOfClusters);

                // perform similarity calculations - for each stocks in the list
                for (int i = 0; i < stockList.Count; i++)
                {
                    minimalDistanceCluster = int.MaxValue;
                    minimalDistanceClusterDistance = double.MaxValue;

                    // compare with the center of each clusters
                    for (int j = 0; j < numberOfClusters; j++)
                    {
                        thisRoundDistance = CalculateDistance(possibleSequences, clustersCenterList[j], masterDict1[stockList[i]]);
                        Console.WriteLine("SSEC: Stock " + stockList[i].stockCode + " vs cluster " + j + ", iteration " + iteration + ", distance " + thisRoundDistance);

                        if (thisRoundDistance < minimalDistanceClusterDistance)
                        {
                            minimalDistanceCluster = j;
                            minimalDistanceClusterDistance = thisRoundDistance;
                        }
                    }

                    // if the result is different from the master table, that means the reuslts has been changed
                    if (masterDict2[stockList[i]] != minimalDistanceCluster)
                    {
                        masterDict2[stockList[i]] = minimalDistanceCluster;
                        clusterElementChanged = true;
                    }
                }

                // empty cluster check
                for (int i = 0; i < numberOfClusters; i++)
                {
                    if (DirtyHelper.CheckWetherClusterHasNoStock(masterDict2, i))
                    {
                        while (true)
                        {
                            int tobe = new Random().Next(stockList.Count);
                            if (!DirtyHelper.CheckWetherThisStockIsALonelyStock(masterDict2, masterDict2[stockList[tobe]]))
                            {
                                masterDict2[stockList[tobe]] = i;
                                break;
                            }
                        }
                    }
                }

                // infinite loop check
                if (CompareDictionary(masterDict2, masterDict3) || CompareDictionary(masterDict2, masterDict4))
                {
                    clusterElementChanged = false;
                    Console.WriteLine("\nSSEC: Infinite loop detected, will not go into next loop.");
                }
                else
                {
                    // if clusters are ok, copy as temp and go to next iteration
                    masterDict4 = masterDict3;
                    masterDict3 = CloneDictionary(masterDict2);
                }

                if (iteration == 50)
                {
                    throw new Exception("more than 100");
                }

                // **********
                // Note: massive debug logging here, consider refactoring
                // **********

                Console.WriteLine("SSEC: Iteration " + iteration + " done");

                if (iteration % 3 == 0 || !clusterElementChanged)
                {
                    Console.WriteLine("\nSSEC: Iteration " + iteration + " result");

                    foreach (KeyValuePair<Stock, int> eachKYP in masterDict2)
                    {
                        Console.Write("SSEC: Stock " + eachKYP.Key.stockCode + ", cluster ");

                        if (masterDict4 != null)
                        {
                            Console.Write(masterDict4[eachKYP.Key] + "->");
                        }

                        if (masterDict3 != null)
                        {
                            Console.Write(masterDict3[eachKYP.Key] + "->");
                        }

                        Console.WriteLine(eachKYP.Value);
                    }

                    for (int i = 0; i < numberOfClusters; i++)
                    {
                        Console.WriteLine("SSEC: Cluster " + i + " has " + NumberofElements(masterDict2, i) + " stocks.");
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
                foreach (KeyValuePair<Stock, int> eachStockClusterKYP in masterDict2)
                {
                    if (eachStockClusterKYP.Value == i)
                    {
                        thisCluster.stockCodeList.Add(eachStockClusterKYP.Key.stockCode);
                    }
                }

                foreach (KeyValuePair<string, double> seqOccuranceKYP in clustersCenterList[i])
                {
                    thisCluster.centroid.Add(new FakeTick(seqOccuranceKYP.Key, seqOccuranceKYP.Value));
                }

                toReturn.Add(thisCluster);
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

        // method for recalculating the distance between clusters and individual stocks
        public static double CalculateDistance(List<string> possibleSequences,
            Dictionary<string, double> clusterSeqOccuranceMap, Dictionary<string, int> stockSeqOccuranceMap)
        {
            // below is debugging code, check the length of two map
            if (clusterSeqOccuranceMap.Count != stockSeqOccuranceMap.Count)
            {
                throw new Exception("DEBUG: The length of sequence map between clusters and individual stocks are not the same.");
            }

            double distance = 0.0;
            foreach (string eachPossibleSeq in possibleSequences)
            {
                distance += Math.Pow(stockSeqOccuranceMap[eachPossibleSeq] - clusterSeqOccuranceMap[eachPossibleSeq], 2);
            }

            return Math.Sqrt(distance);
        }

        // method for recalculating the center of each clusters
        public static List<Dictionary<string, double>> CalculateClusterCenter(List<string> possibleSequences,
            Dictionary<Stock, Dictionary<string, int>> seqOccuranceMap, Dictionary<Stock, int> stockClusterMapping, int numberOfClusters)
        {
            List<Dictionary<string, double>> toReturn = new List<Dictionary<string, double>>();
            int hit = 0;

            for (int i = 0; i < numberOfClusters; i++)
            {
                Dictionary<string, double> clusterCenterPointList = SeqListToDblDict(possibleSequences);
                hit = 0;

                // sum the occurance of each sequence of each stock into cluster center point list
                foreach (KeyValuePair<Stock, int> eachStockClusterKYP in stockClusterMapping)
                {
                    if (eachStockClusterKYP.Value == i)
                    {
                        hit++;
                        foreach (KeyValuePair<string, int> eachSeqOccuranceKYP in seqOccuranceMap[eachStockClusterKYP.Key])
                        {
                            // add the occurance of each sequence of each stock into cluster center point list
                            clusterCenterPointList[eachSeqOccuranceKYP.Key] += eachSeqOccuranceKYP.Value;
                        }
                    }
                }

                // take the average
                foreach (string eachPossibleSeq in possibleSequences)
                {
                    clusterCenterPointList[eachPossibleSeq] /= hit;
                }

                toReturn.Add(clusterCenterPointList);
            }

            return toReturn;
        }

        // covert the possible sequences list into dictionary, used in loops and similarity calculations
        public static Dictionary<string, int> SeqListToIntDict(List<string> possibleSequences)
        {
            Dictionary<string, int> sequenceDictionary = new Dictionary<string, int>();
            foreach (string sequence in possibleSequences)
            {
                sequenceDictionary.Add(sequence, 0);
            }
            return sequenceDictionary;
        }

        // covert the possible sequences list into dictionary, used in loops and similarity calculations (double version)
        public static Dictionary<string, double> SeqListToDblDict(List<string> possibleSequences)
        {
            Dictionary<string, double> sequenceDictionary = new Dictionary<string, double>();
            foreach (string sequence in possibleSequences)
            {
                sequenceDictionary.Add(sequence, 0);
            }
            return sequenceDictionary;
        }

        // input the tick objects, convert them into strings
        public static string SequenceString(Tick[] ticks)
        {
            string toReturn = "";
            foreach (Tick tick in ticks)
            {
                toReturn += ((GenusTick)tick).degreeOfChange >= 0 ? "+" + ((GenusTick)tick).degreeOfChange : ((GenusTick)tick).degreeOfChange + "";
            }
            return toReturn;
        }

        // input number of genus and number in sequence, compute all the possible permutations
        public static List<string> SequenceString(int numberOfGenus, int numberInSequence)
        {
            List<string> resultList = new List<string>();
            SequenceString(numberOfGenus, numberInSequence, 0, new int[numberInSequence], resultList);
            return resultList;
        }

        // assisting recursive method for the above public method interface
        private static void SequenceString(int numberOfGenus, int numberInSequence, int seqID, int[] intermidiate, List<string> resultList)
        {
            if (seqID == numberInSequence)
            {
                Tick[] ticks = new Tick[numberInSequence];
                for (int i = 0; i < numberInSequence; i++)
                {
                    ticks[i] = new GenusTick(intermidiate[i]);
                }
                resultList.Add(SequenceString(ticks));
            }
            else
            {
                for (int i = 0; i < numberOfGenus; i++)
                {
                    intermidiate[seqID] = i - (int)Math.Floor(numberOfGenus / 2.0);
                    SequenceString(numberOfGenus, numberInSequence, seqID + 1, (int[])intermidiate.Clone(), resultList);
                }
            }
        }
    }
}
