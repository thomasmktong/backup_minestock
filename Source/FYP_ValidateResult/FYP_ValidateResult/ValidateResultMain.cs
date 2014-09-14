using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FYP_Common;

namespace FYP_ValidateResult
{
    class ValidateResultMain
    {
        static void Main(string[] args)
        {
            int mode = 0; // 0: intra cluster corelation, 1: inter cluster corelation
            string clusterPath;
            string stockPath;
            string outPath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_ValidateResult");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 4 || !int.TryParse(args[0], out mode))
            {
                do
                {
                    Console.WriteLine("\nEnter mode (0 for intra-cluster corelation, 1 for inter-cluster corelation): ");
                } while (!int.TryParse(Console.ReadLine(), out mode));
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter cluster file path (e.g. C:\\Temp\\Cluster): ");
                clusterPath = Console.ReadLine();
            }
            else
            {
                clusterPath = args[1];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter stock path (e.g. C:\\Temp\\Stock): ");
                stockPath = Console.ReadLine();
            }
            else
            {
                stockPath = args[2];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter output path (e.g. C:\\Temp\\): ");
                outPath = Console.ReadLine();
            }
            else
            {
                outPath = args[3];
            }

            // debug
            //clusterPath = @"C:\MineStock\Environment\Cluster\MOTIF";
            //stockPath = @"C:\MineStock\Environment\Data\Stock";
            //outPath = @"C:\Temp\";

            // remove existing
            Array.ForEach(Directory.GetFiles(outPath), delegate(string path) { File.Delete(path); });
            Console.WriteLine();

            // intra cluster distance
            if (mode == 0)
            {
                int temp = 0;

                foreach (string fileName in Directory.GetFiles(clusterPath))
                {
                    if (fileName.EndsWith(".xml"))
                    {
                        Cluster eachCluster = XMLHelper.ClusterFromXML(fileName);
                        temp += eachCluster.stockCodeList.Count;
                    }
                }

                intra(clusterPath, stockPath, outPath, temp);
                Console.WriteLine("\nDone");
            }

            // inter cluster distance
            if (mode == 1)
            {
                Console.WriteLine("\nInter-cluster Correlation:");
                Console.WriteLine("Path " + clusterPath + "\n");

                List<int> clusteredStockCodeList = new List<int>();
                List<double> clusteredStockSDList = new List<double>();
                List<List<Tick>> clusteredStockTicksList = new List<List<Tick>>();

                // populate stock list
                foreach (string fileName in Directory.GetFiles(clusterPath))
                {
                    if (fileName.EndsWith(".xml"))
                    {
                        Cluster eachCluster = XMLHelper.ClusterFromXML(fileName);

                        foreach (int eachStockCode in eachCluster.stockCodeList)
                        {
                            string stockFileTempPath = stockPath + "\\" + eachStockCode + ".xml";
                            Stock stockFileTempObj = XMLHelper.StockFromXML(stockFileTempPath);
                            clusteredStockCodeList.Add(eachStockCode);
                            clusteredStockSDList.Add(StatHelper.GetDailySD(stockFileTempObj.priceList));
                            clusteredStockTicksList.Add(stockFileTempObj.priceList);
                        }
                    }
                }

                double[,] covMatrix = StatHelper.GetCovarianceMatrix(clusteredStockTicksList.ToArray());
                clusteredStockTicksList = null;

                // correlation of everything
                Console.WriteLine("Before Clustering");
                int length = (int)Math.Sqrt(covMatrix.Length);
                int count = 0;
                double average = 0.0;

                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (i >= j)
                        {
                            // correlation
                            double temp = clusteredStockSDList[i] * clusteredStockSDList[j];
                            temp = temp == 0 ? 0 : covMatrix[i, j] / temp;

                            // add back correlation
                            average += temp;
                            count++;
                        }
                    }
                }

                Console.WriteLine("Avg=" + average / count + "\n");

                List<List<String>> iterationClusterList = new List<List<string>>();
                inter1(clusterPath, covMatrix, 1, iterationClusterList);

                // populate iteration list - proved ok
                for (int i = 0; i < iterationClusterList.Count - 1; i++)
                {
                    foreach (string eachClusterInEarierIteration in iterationClusterList[i])
                    {
                        bool isIncluded = false;

                        foreach (string eachClusterInLatterIteration in iterationClusterList[i + 1])
                        {
                            if (eachClusterInLatterIteration.Contains(eachClusterInEarierIteration.Replace(".xml", "")))
                            {
                                isIncluded = true;
                                continue;
                            }
                        }

                        if (!isIncluded)
                        {
                            iterationClusterList[i + 1].Add(eachClusterInEarierIteration);
                        }
                    }
                }

                // for each iteration
                for (int i = 0; i < iterationClusterList.Count; i++)
                {
                    Console.WriteLine("Iteration " + (i + 1));
                    double iterationAvg = 0.0;
                    int iterationCount = 0;
                    if (iterationClusterList[i].Count < 2) continue;

                    // for each cluster A
                    for (int j = 0; j < iterationClusterList[i].Count; j++)
                    {
                        Cluster clsA = XMLHelper.ClusterFromXML(iterationClusterList[i][j]);
                        double clusterAvg = 0.0;
                        int clusterStockCount = 0;

                        // debug
                        Console.Write(iterationClusterList[i][j].Replace(clusterPath + "\\", "") +
                            ",selfcount=" + clsA.stockCodeList.Count);

                        // compare with each cluster B
                        for (int k = 0; k < iterationClusterList[i].Count; k++)
                        {
                            if (j != k)
                            {
                                //if (iterationClusterList[i][j].Replace(clusterPath + "\\", "")[0] ==
                                //    iterationClusterList[i][k].Replace(clusterPath + "\\", "")[0])
                                //{
                                //    continue;
                                //}

                                Cluster clsB = XMLHelper.ClusterFromXML(iterationClusterList[i][k]);
                                int twoClsComperationCount = 0;
                                double corr = inter2(clsA, clsB, clusteredStockCodeList, clusteredStockSDList, covMatrix,
                                    out twoClsComperationCount);

                                // do no remove the following commented section
                                //iterationAvg += (twoClsComperationCount * corr);
                                //iterationCount += twoClsComperationCount;

                                //Console.WriteLine("Cls " + iterationClusterList[i][j].Replace(clusterPath + "\\", "") +
                                //    " vs Cls " + iterationClusterList[i][k].Replace(clusterPath + "\\", "") + ",corr=" + corr +
                                //    ",cnt=" + twoClsComperationCount);

                                clusterAvg += corr * clsB.stockCodeList.Count;
                                clusterStockCount += clsB.stockCodeList.Count;
                            }
                        }

                        double clsTemp = clusterAvg / clusterStockCount;

                        Console.WriteLine(",comparison=" + clusterStockCount + ",corr=" + clsTemp);
                        iterationAvg += clsTemp * clsA.stockCodeList.Count;
                        iterationCount += clsA.stockCodeList.Count;
                    }

                    double temp = iterationAvg / iterationCount;
                    Console.WriteLine("Avg=" + temp + "\n");
                }
            }
        }

        private static void intra(string clusterPath, string stockPath, string outPath, int clusteredStockCount)
        {
            Array.ForEach(Directory.GetDirectories(clusterPath), delegate(string path)
            {
                intra(path, stockPath, outPath, clusteredStockCount);
            });

            Console.WriteLine("\nIntra-cluster Correlation:");
            Console.WriteLine("Path " + clusterPath + "\n");

            // intra cluster
            foreach (string fileName in Directory.GetFiles(clusterPath))
            {
                if (fileName.EndsWith(".xml"))
                {
                    Cluster eachCluster = XMLHelper.ClusterFromXML(fileName);
                    Console.Write("Cluster " + eachCluster.clusterCode + ": count=" + eachCluster.stockCodeList.Count);

                    if (eachCluster.stockCodeList.Count <= 1)
                    {
                        Console.Write(",avg correlation=1,weighted=" + eachCluster.stockCodeList.Count / (double)clusteredStockCount);
                        Console.WriteLine();
                        continue;
                    }

                    int[] stockCodeList = new int[eachCluster.stockCodeList.Count];
                    double[] stockSDList = new double[eachCluster.stockCodeList.Count];
                    List<Tick>[] ticksList = new List<Tick>[eachCluster.stockCodeList.Count];

                    for (int i = 0; i < eachCluster.stockCodeList.Count; i++)
                    {
                        string stockFileTempPath = stockPath + "\\" + eachCluster.stockCodeList[i] + ".xml";
                        Stock stockFileTempObj = XMLHelper.StockFromXML(stockFileTempPath);
                        stockCodeList[i] = stockFileTempObj.stockCode;
                        stockSDList[i] = StatHelper.GetDailySD(stockFileTempObj.priceList);
                        ticksList[i] = stockFileTempObj.priceList;
                        stockFileTempObj = null;
                    }

                    double[,] covMatrix = StatHelper.GetCovarianceMatrix(ticksList);
                    int length = (int)Math.Sqrt(covMatrix.Length);
                    int count = 0;
                    double average = 0.0;

                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (i >= j)
                            {
                                // correlation
                                double temp = stockSDList[i] * stockSDList[j];
                                temp = temp == 0 ? 0 : covMatrix[i, j] / temp;

                                // add back correlation
                                average += temp;
                                count++;
                            }
                        }
                    }

                    // calculation
                    average /= count;
                    Console.Write(",avg correlation=" + average);
                    average *= (eachCluster.stockCodeList.Count / (double)clusteredStockCount);
                    Console.WriteLine(",weighted=" + average);
                }
            }
        }

        private static void inter1(string clusterPath, double[,] covMatrix, int iterationCount,
            List<List<String>> iterationClusterList)
        {
            Array.ForEach(Directory.GetDirectories(clusterPath), delegate(string path)
            {
                inter1(path, covMatrix, iterationCount + 1, iterationClusterList);
            });

            while (iterationClusterList.Count < iterationCount)
            {
                iterationClusterList.Add(new List<string>());
            }

            foreach (string fileName in Directory.GetFiles(clusterPath))
            {
                if (fileName.EndsWith(".xml"))
                {
                    iterationClusterList[iterationCount - 1].Add(fileName);
                }
            }
        }

        private static double inter2(Cluster cls1, Cluster cls2, List<int> clusteredStockCodeList,
            List<double> clusteredStockSDList, double[,] covMatrix, out int count)
        {
            double avg = 0.0;
            count = 0;

            for (int i = 0; i < cls1.stockCodeList.Count; i++)
            {
                for (int j = 0; j < cls2.stockCodeList.Count; j++)
                {
                    int posI = clusteredStockCodeList.IndexOf(cls1.stockCodeList[i]);
                    int posJ = clusteredStockCodeList.IndexOf(cls2.stockCodeList[j]);

                    double temp = clusteredStockSDList[posI] * clusteredStockSDList[posJ];
                    temp = temp == 0 ? 0 : covMatrix[posI, posJ] / temp;

                    avg += temp;
                    count++;
                }
            }

            return avg / count;
        }
    }
}
