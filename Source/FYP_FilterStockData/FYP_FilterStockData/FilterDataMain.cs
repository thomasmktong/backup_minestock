using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;
using System.IO;

namespace FYP_FilterStockData
{
    class FilterDataMain
    {
        static void Main(string[] args)
        {
            Stock referencingStock;
            int stockCode;
            string filePath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_FilterStockData");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 2 || !int.TryParse(args[0], out stockCode))
            {
                do
                {
                    Console.WriteLine("\nReferencing stock code (0 to get HSI): ");
                } while (!int.TryParse(Console.ReadLine(), out stockCode));
            }

            if (args.Length != 2)
            {
                Console.WriteLine("\nEnter store path (e.g. C:\\Temp\\Stock): ");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[1];
            }

            Console.WriteLine("");

            List<Stock> stockList = new List<Stock>();

            foreach (string fileName in Directory.GetFiles(filePath))
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

            // find out the min and max
            DateTime minDateTime = DateTime.Now;
            DateTime maxDateTime = new DateTime(1990, 1, 1);

            foreach (Stock eachStock in stockList)
            {
                if (DateTime.Compare(minDateTime, eachStock.priceList[0].Time) > 0)
                {
                    minDateTime = eachStock.priceList[0].Time;
                }

                if (DateTime.Compare(maxDateTime, eachStock.priceList[eachStock.priceList.Count - 1].Time) < 0)
                {
                    maxDateTime = eachStock.priceList[eachStock.priceList.Count - 1].Time;
                }
            }

            // collect the tick dates of the referencing stock
            referencingStock = DownloadStock(stockCode, minDateTime, maxDateTime);
            bool holiday = true;

            // remove the ticks of each stock if the tick date is not exist in the referencing stock
            foreach (Stock eachStock in stockList)
            {
                List<Tick> filteredTickList = new List<Tick>();
                foreach (Tick eachTick in eachStock.priceList)
                {
                    holiday = true;
                    foreach (Tick eachRefTick in referencingStock.priceList)
                    {
                        if (DateTime.Compare(eachTick.Time, eachRefTick.Time) == 0)
                        {
                            holiday = false;
                            break;
                        }
                    }

                    if (!holiday)
                    {
                        filteredTickList.Add(eachTick);
                    }
                    else
                    {
                        Console.WriteLine("FILTER: Stock " + eachStock.stockCode +
                            ", tick: " + String.Format("{0:yyyyMMdd}", eachTick.Time) +
                            ", change: " + ((NumericTick)eachTick).adjustedChange + ", skipped");
                    }
                }

                for (int i = 1; i < filteredTickList.Count; i++)
                {
                    ((NumericTick)filteredTickList[i]).change =
                        (((NumericTick)filteredTickList[i]).close - ((NumericTick)filteredTickList[i - 1]).close) * 100;

                    ((NumericTick)filteredTickList[i]).adjustedChange =
                        (((NumericTick)filteredTickList[i]).adjustedClose - ((NumericTick)filteredTickList[i - 1]).adjustedClose) * 100;

                    // change - calculation and error checking

                    if (((NumericTick)filteredTickList[i]).change != 0)
                    {
                        if (((NumericTick)filteredTickList[i - 1]).close != 0)
                        {
                            ((NumericTick)filteredTickList[i]).change /= ((NumericTick)filteredTickList[i - 1]).close;
                        }
                        else
                        {
                            ((NumericTick)filteredTickList[i]).change = 0;
                        }
                    }

                    // adjusted change - calculation and error checking

                    if (((NumericTick)filteredTickList[i]).adjustedChange != 0)
                    {
                        if (((NumericTick)filteredTickList[i - 1]).adjustedClose != 0)
                        {
                            ((NumericTick)filteredTickList[i]).adjustedChange /= ((NumericTick)filteredTickList[i - 1]).adjustedClose;
                        }
                        else
                        {
                            ((NumericTick)filteredTickList[i]).adjustedChange = ((NumericTick)filteredTickList[i]).change;
                        }
                    }

                    // debug

                    if (double.IsInfinity(((NumericTick)filteredTickList[i]).change) || double.IsInfinity(((NumericTick)filteredTickList[i]).adjustedChange) ||
                        double.IsNaN(((NumericTick)filteredTickList[i]).change) || double.IsNaN(((NumericTick)filteredTickList[i]).adjustedChange))
                    {
                        //throw new Exception();
                    }
                }

                eachStock.priceList = filteredTickList;
            }

            Console.WriteLine();

            // output
            foreach (Stock eachStock in stockList)
            {
                Console.WriteLine("Writing stock " + eachStock.stockCode + "...");
                XMLHelper.StockToXML(eachStock, filePath);
            }

            Console.WriteLine("\nProcess exited.");
        }

        static String FetchWebsite(String url)
        {
            // refactored: moved to common
            return MiscHelper.FetchInternetPlainText(url);
        }

        static Stock DownloadStock(int stockCode, DateTime dateFrom, DateTime dateTo)
        {
            Stock stock = new Stock();
            stock.stockCode = stockCode;
            DownloadStockDate(stock, dateFrom.Day, dateFrom.Month, dateFrom.Year, dateTo.Day, dateTo.Month, dateTo.Year);
            return stock;
        }

        static void DownloadStockDate(Stock stock, int d_from, int m_from, int y_from, int d_to, int m_to, int y_to)
        {
            // **********
            // Note: price tick in yahoo finance is in reverse order
            // **********

            String url = String.Format(
                "http://ichart.yahoo.com/table.csv?s={0:0000}.HK&a={1:00}&b={2}&c={3:0000}&d={4:00}&e={5}&f={6:0000}&g=d&ignore=.csv",
                stock.stockCode, m_from - 1, d_from, y_from, m_to - 1, d_to, y_to
                );

            // ^HSI special handling
            if (stock.stockCode == 0)
            {
                url = url.Replace("0000.HK", "^HSI");
            }

            string text = FetchWebsite(url);
            StringReader sr = new StringReader(text);
            string line = sr.ReadLine();
            stock.priceList = new List<Tick>();

            while (true)
            {
                line = sr.ReadLine();

                if (line != null)
                {
                    FakeTick dateTick = new FakeTick();
                    dateTick.Time = new DateTime(
                        int.Parse(line.Substring(0, 4)),
                        int.Parse(line.Substring(5, 2)),
                        int.Parse(line.Substring(8, 2)));

                    stock.priceList.Add(dateTick);
                }
                else
                {
                    break;
                }
            }

            stock.priceList.Reverse();
        }
    }
}
