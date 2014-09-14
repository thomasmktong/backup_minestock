using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using LumenWorks.Framework.IO.Csv;
using System.Text.RegularExpressions;
using FYP_Common;
using System.IO;

namespace FYP_GetStockData
{
    class GetDataMain
    {
        static void Main(string[] args)
        {
            int stockCode;
            int d_from;
            int m_from;
            int y_from;
            int d_to;
            int m_to;
            int y_to;
            string filePath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_GetStockData");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 8 || !int.TryParse(args[0], out stockCode))
            {
                do
                {
                    Console.WriteLine("\nEnter stock code (-1 to get all, 0 to get HSI): ");
                } while (!int.TryParse(Console.ReadLine(), out stockCode));
            }

            if (args.Length != 8 || !int.TryParse(args[1], out y_from))
            {
                do
                {
                    Console.WriteLine("\nEnter starting year (yyyy): ");
                } while (!int.TryParse(Console.ReadLine(), out y_from));
            }

            if (args.Length != 8 || !int.TryParse(args[2], out m_from))
            {
                do
                {
                    Console.WriteLine("\nEnter starting month (mm): ");
                } while (!int.TryParse(Console.ReadLine(), out m_from));
            }

            if (args.Length != 8 || !int.TryParse(args[3], out d_from))
            {
                do
                {
                    Console.WriteLine("\nEnter starting day (dd): ");
                } while (!int.TryParse(Console.ReadLine(), out d_from));
            }

            if (args.Length != 8 || !int.TryParse(args[4], out y_to))
            {
                do
                {
                    Console.WriteLine("\nEnter ending year (yyyy): ");
                } while (!int.TryParse(Console.ReadLine(), out y_to));
            }

            if (args.Length != 8 || !int.TryParse(args[5], out m_to))
            {
                do
                {
                    Console.WriteLine("\nEnter ending month (mm): ");
                } while (!int.TryParse(Console.ReadLine(), out m_to));
            }

            if (args.Length != 8 || !int.TryParse(args[6], out d_to))
            {
                do
                {
                    Console.WriteLine("\nEnter ending day (dd): ");
                } while (!int.TryParse(Console.ReadLine(), out d_to));
            }

            if (args.Length != 8)
            {
                Console.WriteLine("\nEnter store path (e.g. C:\\Temp\\Stock): ");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[7];
            }

            // here we start everything - create directory if not exist
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (stockCode >= 0)
            {
                Stock newStock = new Stock();
                newStock.stockCode = stockCode;
                Console.WriteLine("\nDownloading stock price for " + newStock.stockCode + "...");

                try
                {
                    DownloadStockPrice(newStock, d_from, m_from, y_from, d_to, m_to, y_to);
                    ((NumericTick)newStock.priceList.ElementAt(0)).change = 0;
                    ((NumericTick)newStock.priceList.ElementAt(0)).adjustedChange = 0;

                    // health check
                    foreach (NumericTick eachTick in newStock.priceList)
                    {
                        if ((double.IsInfinity(eachTick.change) || double.IsNaN(eachTick.change) ||
                            double.IsInfinity(eachTick.adjustedChange) || double.IsNaN(eachTick.adjustedChange))
                            && !newStock.priceList.ElementAt(0).Equals(eachTick))
                        {
                            Console.WriteLine(newStock.stockCode + " have invalid change % on " + String.Format("{0:yyyyMMdd}", eachTick.Time));

                            // dirty trick
                            eachTick.change = (double.IsInfinity(eachTick.change) || double.IsNaN(eachTick.change)) ? 0 : eachTick.change;
                            eachTick.adjustedChange = (double.IsInfinity(eachTick.adjustedChange) || double.IsNaN(eachTick.adjustedChange)) ? eachTick.change : eachTick.adjustedChange;
                        }
                    }

                    XMLHelper.StockToXML(newStock, @filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                // remove all files in the output folder first - added 8 feb 
                Array.ForEach(Directory.GetFiles(filePath), delegate(string path) { File.Delete(path); });

                List<Stock> stockList = new List<Stock>();
                Console.WriteLine("\nDownloading stock list...");
                DownloadStockCode(stockList, stockCode);
                foreach (Stock eachStock in stockList)
                {
                    Console.WriteLine("\nDownloading stock price for " + eachStock.stockCode + "...");
                    try
                    {
                        DownloadStockPrice(eachStock, d_from, m_from, y_from, d_to, m_to, y_to);
                        ((NumericTick)eachStock.priceList.ElementAt(0)).change = 0;
                        ((NumericTick)eachStock.priceList.ElementAt(0)).adjustedChange = 0;

                        // health check
                        foreach (NumericTick eachTick in eachStock.priceList)
                        {
                            if ((double.IsInfinity(eachTick.change) || double.IsNaN(eachTick.change) ||
                                double.IsInfinity(eachTick.adjustedChange) || double.IsNaN(eachTick.adjustedChange))
                                && !eachStock.priceList.ElementAt(0).Equals(eachTick))
                            {
                                Console.WriteLine(eachStock.stockCode + " have invalid change % on " + String.Format("{0:yyyyMMdd}", eachTick.Time));

                                // dirty trick
                                eachTick.change = (double.IsInfinity(eachTick.change) || double.IsNaN(eachTick.change)) ? 0 : eachTick.change;
                                eachTick.adjustedChange = (double.IsInfinity(eachTick.adjustedChange) || double.IsNaN(eachTick.adjustedChange)) ? eachTick.change : eachTick.adjustedChange;
                            }
                        }

                        Console.WriteLine("Writing stock " + eachStock.stockCode + "...");
                        XMLHelper.StockToXML(eachStock, @filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("\nProcess exited.");
        }

        static void DownloadStockCode(List<Stock> list, int mode)
        {
            string url_main = "http://www.hkex.com.hk/eng/market/sec_tradinfo/stockcode/eisdeqty_pf.htm";
            string url_gem = "http://www.hkex.com.hk/eng/market/sec_tradinfo/stockcode/eisdgems_pf.htm";

            // **********
            // Note: regex for stock code & stock name extraction
            // <td.*?>(?<code>[0-9]{5})</td><td.*?><a.*?>(?<name>.*?)</a></td>
            // 
            // Match the characters “<td” literally «<td»
            // Match any single character that is not a line break character «.*?»
            //    Between zero and unlimited times, as few times as possible, expanding as needed (lazy) «*?»
            // Match the character “>” literally «>»
            // Match the regular expression below and capture its match into backreference with name “code” «(?<code>[0-9]{5})»
            //    Match a single character in the range between “0” and “9” «[0-9]{5}»
            //       Exactly 5 times «{5}»
            // Match the characters “</td><td” literally «</td><td»
            // Match any single character that is not a line break character «.*?»
            //    Between zero and unlimited times, as few times as possible, expanding as needed (lazy) «*?»
            // Match the characters “><a” literally «><a»
            // Match any single character that is not a line break character «.*?»
            //    Between zero and unlimited times, as few times as possible, expanding as needed (lazy) «*?»
            // Match the character “>” literally «>»
            // Match the regular expression below and capture its match into backreference with name “name” «(?<name>.*?)»
            //    Match any single character that is not a line break character «.*?»
            //       Between zero and unlimited times, as few times as possible, expanding as needed (lazy) «*?»
            // Match the characters “</a></td>” literally «</a></td>»
            // **********

            try
            {
                Regex regexObj = new Regex("<td.*?>(?<code>[0-9]{5})</td><td.*?><a.*?>(?<name>.*?)</a></td>");
                Match matchResult = null;

                if (mode == -1 || mode == -3)
                {
                    // main board
                    matchResult = regexObj.Match(FetchWebsite(url_main));
                    while (matchResult.Success)
                    {
                        Stock newStock = new Stock();
                        newStock.stockCode = int.Parse(matchResult.Groups["code"].Value);
                        newStock.stockName = matchResult.Groups["name"].Value.Trim();
                        list.Add(newStock);
                        matchResult = matchResult.NextMatch();
                    }
                }

                if (mode == -2 || mode == -3)
                {
                    // growth enterprise market
                    matchResult = regexObj.Match(FetchWebsite(url_gem));
                    while (matchResult.Success)
                    {
                        Stock newStock = new Stock();
                        newStock.stockCode = int.Parse(matchResult.Groups["code"].Value);
                        newStock.stockName = matchResult.Groups["name"].Value.Trim();
                        list.Add(newStock);
                        matchResult = matchResult.NextMatch();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }

        }

        static void DownloadStockPrice(Stock stock, int d_from, int m_from, int y_from, int d_to, int m_to, int y_to)
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

            String text = FetchWebsite(url);
            stock.priceList = new List<Tick>();

            // **********
            // Note: csv reader library by Sebastien Lorion: http://www.codeproject.com/KB/database/CsvReader.aspx
            // **********

            NumericTick lastTick = new NumericTick();

            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv =
                   new CsvReader(new StringReader(text), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();

                while (csv.ReadNextRecord())
                {
                    // code sample shipped with library
                    // for (int i = 0; i < fieldCount; i++)
                    //    Console.Write(string.Format("{0} = {1};",
                    //                  headers[i], csv[i]));
                    // Console.WriteLine();

                    string tempDate = csv[0];
                    string tempOpen = csv[1];
                    string tempHigh = csv[2];
                    string tempLow = csv[3];
                    string tempClose = csv[4];
                    string volume = csv[5];
                    string adjClose = csv[6];

                    NumericTick newTick = new NumericTick();
                    newTick.Time = new DateTime(
                        int.Parse(tempDate.Substring(0, 4)),
                        int.Parse(tempDate.Substring(5, 2)),
                        int.Parse(tempDate.Substring(8, 2)));

                    newTick.change = 0;
                    newTick.adjustedChange = 0;
                    newTick.high = double.Parse(tempHigh);
                    newTick.low = double.Parse(tempLow);
                    newTick.open = double.Parse(tempOpen);
                    newTick.close = double.Parse(tempClose);
                    newTick.adjustedClose = double.Parse(adjClose);
                    newTick.volume = volume;

                    newTick.id = Identifier.N;

                    if (newTick.close == 0) continue;

                    // add a dummy tick if the price collected is not continuum
                    if (stock.priceList.Count != 0)
                    {
                        for (int i = lastTick.Time.Subtract(newTick.Time).Days; i > 1; i--)
                        {
                            NumericTick dummyTick = new NumericTick();
                            dummyTick.Time = lastTick.Time.AddDays(-1);

                            dummyTick.change = 0;
                            dummyTick.adjustedChange = 0;
                            dummyTick.volume = "0";
                            dummyTick.high = newTick.close;
                            dummyTick.low = newTick.close;
                            dummyTick.open = newTick.close;
                            dummyTick.close = newTick.close;
                            dummyTick.adjustedClose = newTick.adjustedClose;

                            stock.priceList.Add(dummyTick);
                            lastTick = dummyTick;
                        }
                    }

                    stock.priceList.Add(newTick);
                    lastTick = newTick;
                }
            }

            // reverse the tick order to ascending and calculate the change
            stock.priceList.Reverse();
            double lastPrice = 0.0;
            double lastAdjPrice = 0.0;

            foreach (NumericTick eachTick in stock.priceList)
            {
                eachTick.change = ((eachTick.close - lastPrice) * 100);

                if (eachTick.change != 0)
                {
                    eachTick.change /= lastPrice;
                }

                eachTick.adjustedChange = ((eachTick.adjustedClose - lastAdjPrice) * 100);

                if (eachTick.adjustedChange != 0)
                {
                    eachTick.adjustedChange /= lastAdjPrice;
                }

                lastPrice = eachTick.close;
                lastAdjPrice = eachTick.adjustedClose;
            }
        }

        static String FetchWebsite(String url)
        {
            // refactored: moved to common
            return MiscHelper.FetchInternetPlainText(url);
        }
    }
}
