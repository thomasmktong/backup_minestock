using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FYP_Common;
using System.Reflection;

namespace FYP_ClusterStockData
{
    public class ClusterDataMain
    {
        public static void Main(string[] args)
        {
            string additionalArgs = "";

            int numberOfAlgorithm;
            int numberOfClusters;
            string dataPath;
            string resultPath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_ClusterStockData");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length < 5 || !int.TryParse(args[0], out numberOfAlgorithm))
            {
                do
                {
                    Console.WriteLine("\nEnter number of algorithm: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfAlgorithm));
            }

            if (args.Length < 5 || !int.TryParse(args[1], out numberOfClusters))
            {
                do
                {
                    Console.WriteLine("\nEnter number of clusters: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfClusters));
            }

            if (args.Length < 5)
            {
                Console.WriteLine("\nEnter data path (e.g. C:\\Temp\\Stock): ");
                dataPath = Console.ReadLine();
            }
            else
            {
                dataPath = args[2];
            }

            if (args.Length < 5)
            {
                Console.WriteLine("\nEnter result path (e.g. C:\\Temp\\Cluster): ");
                resultPath = Console.ReadLine();
            }
            else
            {
                resultPath = args[3];
            }

            if (args.Length < 5)
            {
                Console.WriteLine("\nAdditional parameters: ");
                additionalArgs = Console.ReadLine();
            }
            else
            {
                for (int i = 4; i < args.Length; i++)
                {
                    additionalArgs += args[i] + " ";
                }
            }

            Console.WriteLine("");

            // debug
            //dataPath = @"C:\MineStock\Environment\Data\Genus";
            //resultPath = @"C:\MineStock\Environment\Cluster";

            if (!Directory.Exists(resultPath))
            {
                Directory.CreateDirectory(resultPath);
            }

            // remove all files in the output folder first - added 8 feb 
            Array.ForEach(Directory.GetFiles(resultPath), delegate(string path) { File.Delete(path); });
            Array.ForEach(Directory.GetDirectories(resultPath), delegate(string path) { Directory.Delete(path, true); });

            List<Stock> stockList = new List<Stock>();
            Dictionary<int, int> distribution = new Dictionary<int, int>();
            int cntStock = 0;
            int maxTick = 0;
            int temp = 0;

            foreach (string fileName in Directory.GetFiles(dataPath))
            {
                if (fileName.EndsWith(".xml"))
                {
                    Console.Write("Reading " + fileName + "...");
                    Stock stock = XMLHelper.StockFromXML(fileName);
                    cntStock++;
                    Console.WriteLine(stock.priceList.Count + " ticks");

                    if (distribution.TryGetValue(stock.priceList.Count, out temp))
                    {
                        distribution.Remove(stock.priceList.Count);
                        distribution.Add(stock.priceList.Count, temp + 1);
                    }
                    else
                    {
                        distribution.Add(stock.priceList.Count, 1);
                    }

                    maxTick = stock.priceList.Count > maxTick ? stock.priceList.Count : maxTick;
                    stockList.Add(stock);
                }
            }

            Console.WriteLine("\nNumber of file processed: " + cntStock + ", maximum ticks of single stock: " + maxTick + "\n");
            temp = 0;

            foreach (KeyValuePair<int, int> eachKYP in distribution)
            {
                if ((double)eachKYP.Value / cntStock > 0.05)
                {
                    Console.WriteLine("Stock with " + eachKYP.Key + " ticks: " + eachKYP.Value);
                }

                if (eachKYP.Value >= temp)
                {
                    temp = eachKYP.Value;
                    maxTick = eachKYP.Key;
                }
            }

            Console.WriteLine("...\n(statistics with less than 5% occourance are omitted)");

            Console.WriteLine("\nNote: stock with as least " + maxTick + " ticks" +
                " will be used in clustering process as they are majority in the data set given." +
                " Stocks with insufficient data points are considered to be inactive and" +
                " will not be used in the clustering process.");

            // start clustering process
            List<Stock> shortlistedStock = new List<Stock>();

            foreach (Stock eachStock in stockList)
            {
                if (eachStock.priceList.Count >= maxTick)
                {
                    // testing code
                    // if (eachStock.stockCode <= 5)
                    // {
                    shortlistedStock.Add(eachStock);
                    // }
                }
            }

            Console.WriteLine("\nNumber of stocks to be processed: " + shortlistedStock.Count);

            Object[] methodParam = { shortlistedStock, numberOfClusters, maxTick, additionalArgs };
            Type[] methodParamTypes = { typeof(List<Stock>), typeof(int), typeof(int), typeof(string) };
            MethodInfo method = Mapping.algorithms[numberOfAlgorithm].GetMethod("Cluster", methodParamTypes);

            //debug
            //List<Cluster> clusterList = MotifHelper.Cluster(shortlistedStock, numberOfClusters, maxTick, additionalArgs);

            List<Cluster> clusterList = (List<Cluster>)method.Invoke(null, methodParam);
            Console.WriteLine();

            foreach (Cluster eachCluster in clusterList)
            {
                Console.WriteLine("Writing cluster " + eachCluster.clusterCode + "...");
                XMLHelper.ClusterToXML(eachCluster, resultPath);
            }

            Console.WriteLine("\nProcess exited.");
        }
    }
}
