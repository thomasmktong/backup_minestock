using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FYP_Common;

namespace FYP_CompileStockData
{
    class CompileDataMain
    {
        static void Main(string[] args)
        {
            string stockPath;
            string indexPath;
            string tbillPath;
            string outputPath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_CompileStockData");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter stock path (e.g. C:\\Temp\\Stock): ");
                stockPath = Console.ReadLine();
            }
            else
            {
                stockPath = args[0];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter index path (e.g. C:\\Temp\\Index): ");
                indexPath = Console.ReadLine();
            }
            else
            {
                indexPath = args[1];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter index path (e.g. C:\\Temp\\Tbill): ");
                tbillPath = Console.ReadLine();
            }
            else
            {
                tbillPath = args[2];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter statistics path (e.g. C:\\Temp\\Stat): ");
                outputPath = Console.ReadLine();
            }
            else
            {
                outputPath = args[3];
            }

            // debug
            //stockPath = @"C:\MineStock\Environment\Data\Stock";
            //indexPath = @"C:\MineStock\Environment\Data\Index";
            //tbillPath = @"C:\MineStock\Environment\Data\Tbill";
            //outputPath = @"C:\MineStock\Environment\Data\Stat";

            Console.WriteLine("");

            // var - check stocks with insufficient data
            Dictionary<int, int> distribution = new Dictionary<int, int>();
            int cntStock = 0;
            int maxTick = 0;
            int temp = 0;

            // here we start everything - create directory if not exist
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            // remove all files in the output folder first - added 8 feb 
            Array.ForEach(Directory.GetFiles(outputPath), delegate(string path) { File.Delete(path); });

            // read the index first
            Stock hsiIndex = XMLHelper.StockFromXML(indexPath + @"\hsi.xml");

            // read the stocks and perform computation
            foreach (string fileName in Directory.GetFiles(stockPath))
            {
                if (fileName.EndsWith(".xml"))
                {
                    Console.Write("Reading " + fileName + "...");
                    Stock stock = XMLHelper.StockFromXML(fileName);
                    cntStock++;
                    Console.WriteLine(stock.priceList.Count + " tick");

                    // check stocks with insufficient data
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

                    // initate a new entity object
                    Statistic stat = new Statistic();
                    stat.stockCode = stock.stockCode;
                    stat.stockName = stock.stockName;
                    stat.stockPrice = StatHelper.GetLastPrice(stock.priceList);
                    stat.annualReturn = StatHelper.GetAnnualGeoReturn(stock.priceList);
                    stat.annualVolatility = StatHelper.GetAnnualSD(stock.priceList);

                    Tbill tbill = XMLHelper.TbillFromXML(tbillPath + @"\2.xml");
                    tbill.ytm /= 100;

                    if (stock.priceList.Count > 1 & hsiIndex.priceList.Count > 1)
                    {
                        stat.beta = StatHelper.GetBeta(stock.priceList, hsiIndex.priceList);
                        stat.alpha = stat.annualReturn - stat.beta * (StatHelper.GetAnnualGeoReturn(hsiIndex.priceList) - tbill.ytm);
                    }
                    else
                    {
                        stat.beta = 0;
                        stat.alpha = 0;
                    }

                    // stat.sharpeRatio
                    if (stat.annualVolatility != 0)
                    {
                        stat.sharpeRatio = (stat.annualReturn - tbill.ytm) / (stat.annualVolatility);
                    }
                    else
                    {
                        stat.sharpeRatio = 0;
                    }

                    stat.paraPercentVaR = StatHelper.GetParaPercentVaR(stock.priceList, 0.05);
                    stat.histPercentVaR = StatHelper.GetHistPercentVaR(stock.priceList, 0.05);
                    stat.paraDollarVaR = StatHelper.GetParaDollarVaR(stock.priceList, 0.05);
                    stat.histDollarVaR = StatHelper.GetHistDollarVaR(stock.priceList, 0.05);

                    stat.sampleCount = stock.priceList.Count;

                    // amend: for all store in percentage, multiply by 100
                    stat.annualReturn *= 100;
                    stat.annualVolatility *= 100;
                    stat.alpha *= 100;
                    stat.paraPercentVaR *= 100;
                    stat.histPercentVaR *= 100;

                    // write out the stat object
                    XMLHelper.ObjectToXML(stat, outputPath, stat.stockCode + "");
                }
            }

            // check stocks with insufficient data
            Console.WriteLine("\nNumber of file processed: " + cntStock + ", maximum ticks of single stock: " + maxTick + "\n");
            temp = 0;

            foreach (KeyValuePair<int, int> eachKYP in distribution)
            {
                Console.WriteLine("Stock with " + eachKYP.Key + " ticks: " + eachKYP.Value);

                if (eachKYP.Value >= temp)
                {
                    temp = eachKYP.Value;
                    maxTick = eachKYP.Key;
                }
            }

            Statistic fakeStat = new Statistic();
            fakeStat.sampleCount = (int)(maxTick * 0.8);
            Console.WriteLine("\nNote: stock with less than " + fakeStat.sampleCount +
                " ticks are considered to have inaccurate results");

            XMLHelper.ObjectToXML(fakeStat, outputPath, Statistic.FAKE_FILE_FILE_NAME);
        }
    }
}
