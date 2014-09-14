using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FYP_Common;

namespace FYP_TimingStockData
{
    class TimingDataMain
    {
        static void Main(string[] args)
        {
            int ticksCombining;
            string filePath;
            string outPath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_TimingStockData");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 3 || !int.TryParse(args[0], out ticksCombining))
            {
                do
                {
                    Console.WriteLine("\nCombining number of ticks (positive number, -1 to combine daily, -2 monthly, -3 yearly: ");
                } while (!int.TryParse(Console.ReadLine(), out ticksCombining));
            }

            if (args.Length != 3)
            {
                Console.WriteLine("\nEnter input path (e.g. C:\\Temp\\Stock): ");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[1];
            }

            if (args.Length != 3)
            {
                Console.WriteLine("\nEnter output path (e.g. C:\\Temp\\Stock): ");
                outPath = Console.ReadLine();
            }
            else
            {
                outPath = args[2];
            }

            Console.WriteLine("");

            // here we start everything - create directory if not exist
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }

            // remove all files in the output folder first - added 8 feb 
            Array.ForEach(Directory.GetFiles(outPath), delegate(string path) { File.Delete(path); });

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

            List<Tick> newPriceList = null;
            NumericTick nt = null;
            UInt64 u_int_64 = 0;

            // start processing
            for (int h = 0; h < stockList.Count; h++)
            {
                Stock eachStock = stockList.ElementAt(h);
                newPriceList = new List<Tick>();

                if (ticksCombining > 0)
                {
                    for (int i = 1; i <= eachStock.priceList.Count; i++)
                    {
                        if (nt == null)
                        {
                            nt = new NumericTick();
                            nt.open = ((NumericTick)eachStock.priceList[i - 1]).open;
                            nt.low = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).high > nt.high)
                        {
                            nt.high = ((NumericTick)eachStock.priceList[i - 1]).high;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).low < nt.low)
                        {
                            nt.low = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        u_int_64 += UInt64.Parse(((NumericTick)eachStock.priceList[i - 1]).volume);

                        // EOC / EOL - add to list in current iteration
                        if (i % ticksCombining == 0 || i == eachStock.priceList.Count)
                        {
                            nt.close = ((NumericTick)eachStock.priceList[i - 1]).close;
                            nt.adjustedClose = ((NumericTick)eachStock.priceList[i - 1]).adjustedClose;
                            nt.volume = u_int_64 + "";
                            nt.id = Identifier.N;
                            nt.Time = eachStock.priceList[i - 1].Time;
                            newPriceList.Add(nt);
                            nt = null;
                            u_int_64 = 0;
                        }
                    }
                }
                else if (ticksCombining == -1)
                {
                    // weekly
                    DayOfWeek temp = eachStock.priceList[0].Time.DayOfWeek;

                    for (int i = 1; i <= eachStock.priceList.Count; i++)
                    {
                        // EOC - add to list in next iteration
                        if (eachStock.priceList[i - 1].Time.DayOfWeek < temp)
                        {
                            nt.id = Identifier.N;
                            nt.Time = eachStock.priceList[i - 1].Time;
                            nt.volume = u_int_64 + "";
                            newPriceList.Add(nt);
                            nt = null;
                            u_int_64 = 0;
                        }

                        if (nt == null)
                        {
                            nt = new NumericTick();
                            nt.open = ((NumericTick)eachStock.priceList[i - 1]).open;
                            nt.low = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).high > nt.high)
                        {
                            nt.high = ((NumericTick)eachStock.priceList[i - 1]).high;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).low < nt.low)
                        {
                            nt.high = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        nt.close = ((NumericTick)eachStock.priceList[i - 1]).close;
                        nt.adjustedClose = ((NumericTick)eachStock.priceList[i - 1]).adjustedClose;
                        temp = eachStock.priceList[i - 1].Time.DayOfWeek;
                        u_int_64 += UInt64.Parse(((NumericTick)eachStock.priceList[i - 1]).volume);

                        // EOL - add to list in current iteration
                        if (i == eachStock.priceList.Count)
                        {
                            nt.id = Identifier.N;
                            nt.Time = eachStock.priceList[i - 1].Time;
                            nt.volume = u_int_64 + "";
                            newPriceList.Add(nt);
                            nt = null;
                            u_int_64 = 0;
                        }
                    }
                }
                else if (ticksCombining == -2)
                {
                    // monthly
                    int temp = eachStock.priceList[0].Time.Day;

                    for (int i = 1; i <= eachStock.priceList.Count; i++)
                    {
                        // EOC - add to list in next iteration
                        if (eachStock.priceList[i - 1].Time.Day < temp)
                        {
                            nt.id = Identifier.N;
                            nt.Time = eachStock.priceList[i - 1].Time;
                            nt.volume = u_int_64 + "";
                            newPriceList.Add(nt);
                            nt = null;
                            u_int_64 = 0;
                        }

                        if (nt == null)
                        {
                            nt = new NumericTick();
                            nt.open = ((NumericTick)eachStock.priceList[i - 1]).open;
                            nt.low = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).high > nt.high)
                        {
                            nt.high = ((NumericTick)eachStock.priceList[i - 1]).high;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).low < nt.low)
                        {
                            nt.high = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        nt.close = ((NumericTick)eachStock.priceList[i - 1]).close;
                        nt.adjustedClose = ((NumericTick)eachStock.priceList[i - 1]).adjustedClose;
                        temp = eachStock.priceList[i - 1].Time.Day;
                        u_int_64 += UInt64.Parse(((NumericTick)eachStock.priceList[i - 1]).volume);

                        // EOL - add to list in current iteration
                        if (i == eachStock.priceList.Count)
                        {
                            nt.id = Identifier.N;
                            nt.Time = eachStock.priceList[i - 1].Time;
                            nt.volume = u_int_64 + "";
                            newPriceList.Add(nt);
                            nt = null;
                            u_int_64 = 0;
                        }
                    }
                }
                else if (ticksCombining == -3)
                {
                    // yearly
                    int temp = eachStock.priceList[0].Time.DayOfYear;

                    for (int i = 1; i <= eachStock.priceList.Count; i++)
                    {
                        // EOC - add to list in next iteration
                        if (eachStock.priceList[i - 1].Time.DayOfYear < temp)
                        {
                            nt.id = Identifier.N;
                            nt.Time = eachStock.priceList[i - 1].Time;
                            newPriceList.Add(nt);
                            nt = null;
                        }

                        if (nt == null)
                        {
                            nt = new NumericTick();
                            nt.open = ((NumericTick)eachStock.priceList[i - 1]).open;
                            nt.low = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).high > nt.high)
                        {
                            nt.high = ((NumericTick)eachStock.priceList[i - 1]).high;
                        }

                        if (((NumericTick)eachStock.priceList[i - 1]).low < nt.low)
                        {
                            nt.high = ((NumericTick)eachStock.priceList[i - 1]).low;
                        }

                        nt.close = ((NumericTick)eachStock.priceList[i - 1]).close;
                        nt.adjustedClose = ((NumericTick)eachStock.priceList[i - 1]).adjustedClose;
                        temp = eachStock.priceList[i - 1].Time.Day;

                        // EOL - add to list in current iteration
                        if (i == eachStock.priceList.Count)
                        {
                            nt.id = Identifier.N;
                            nt.Time = eachStock.priceList[i - 1].Time;
                            newPriceList.Add(nt);
                            nt = null;
                        }
                    }
                }

                for (int i = 1; i < newPriceList.Count; i++)
                {
                    ((NumericTick)newPriceList[i]).change =
                        (((NumericTick)newPriceList[i]).close - ((NumericTick)newPriceList[i - 1]).close)
                        * 100 / ((NumericTick)newPriceList[i - 1]).close;

                    ((NumericTick)newPriceList[i]).adjustedChange =
                        (((NumericTick)newPriceList[i]).adjustedClose - ((NumericTick)newPriceList[i - 1]).adjustedClose)
                        * 100 / ((NumericTick)newPriceList[i - 1]).adjustedClose;
                }

                eachStock.priceList = newPriceList;
                Console.WriteLine("Writing stock " + eachStock.stockCode + "...");
                XMLHelper.StockToXML(eachStock, outPath);
            }
        }
    }
}
