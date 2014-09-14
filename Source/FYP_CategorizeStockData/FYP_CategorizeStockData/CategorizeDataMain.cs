using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FYP_Common;
using System.Reflection;

namespace FYP_CategorizeStockData
{
    class CategorizeDataMain
    {
        public static void Main(string[] args)
        {
            string additionalArgs;

            int numberOfAlgorithm;
            int numberOfGenus;
            int numberOfDaysAsReferencingPeriod;
            string dataPath;
            string resultPath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_CategorizeStockData");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 6 || !int.TryParse(args[0], out numberOfAlgorithm))
            {
                do
                {
                    Console.WriteLine("\nEnter number of algorithm: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfAlgorithm));
            }

            if (args.Length != 6 || !int.TryParse(args[1], out numberOfGenus))
            {
                do
                {
                    Console.WriteLine("\nEnter number of categories (odd number): ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfGenus));
            }

            if (args.Length != 6 || !int.TryParse(args[2], out numberOfDaysAsReferencingPeriod))
            {
                do
                {
                    Console.WriteLine("\nEnter number of input ticks as referencing period: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfDaysAsReferencingPeriod));
            }

            if (args.Length != 6)
            {
                Console.WriteLine("\nEnter data path (e.g. C:\\Temp\\Stock): ");
                dataPath = Console.ReadLine();
            }
            else
            {
                dataPath = args[3];
            }

            if (args.Length != 6)
            {
                Console.WriteLine("\nEnter result path (e.g. C:\\Temp\\Genus): ");
                resultPath = Console.ReadLine();
            }
            else
            {
                resultPath = args[4];
            }

            if (args.Length != 6)
            {
                Console.WriteLine("\nAdditional parameters: ");
                additionalArgs = Console.ReadLine();
            }
            else
            {
                additionalArgs = args[5];
            }

            Console.WriteLine("");

            if (!Directory.Exists(resultPath))
            {
                Directory.CreateDirectory(resultPath);
            }

            // remove all files in the output folder first - added 8 feb 
            Array.ForEach(Directory.GetFiles(resultPath), delegate(string path) { File.Delete(path); });

            List<Stock> stockList = new List<Stock>();

            foreach (string fileName in Directory.GetFiles(dataPath))
            {
                if (fileName.EndsWith(".xml"))
                {
                    Console.Write("Reading " + fileName + "...");
                    Stock stock = XMLHelper.StockFromXML(fileName);
                    Console.WriteLine(stock.priceList.Count + " tick");
                    stockList.Add(stock);
                }
            }

            Console.WriteLine("\nNumber of stocks to be processed: " + stockList.Count);

            // original
            // stockList = UpDownChangeHelper.Categorize(stockList, numberOfGenus, numberOfDaysAsReferencingPeriod, "");

            Object[] methodParam = { stockList, numberOfGenus, numberOfDaysAsReferencingPeriod, "" };
            Type[] methodParamTypes = { typeof(List<Stock>), typeof(int), typeof(int), typeof(string) };
            MethodInfo method = Mapping.algorithms[numberOfAlgorithm].GetMethod("Categorize", methodParamTypes);

            stockList = (List<Stock>)method.Invoke(null, methodParam);
            Console.WriteLine();

            foreach (Stock eachStock in stockList)
            {
                Console.WriteLine("Writing stock " + eachStock.stockCode + "...");
                XMLHelper.StockToXML(eachStock, resultPath);
            }

            Console.WriteLine("\nProcess exited.");
        }
    }
}
