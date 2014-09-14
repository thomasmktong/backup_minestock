using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;
using System.Collections.Specialized;

namespace FYP_OptimizePortfolio
{
    class OptimPortfolioMain
    {
        public static void Main(string[] args)
        {
            string portfolioPath;
            string stockPath;
            string tbillPath;
            string statPath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_OptimizePortfolio");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter protfolio file path (e.g. C:\\Temp\\): ");
                portfolioPath = Console.ReadLine();
            }
            else
            {
                portfolioPath = args[0];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter stock path (e.g. C:\\Temp\\Stock): ");
                stockPath = Console.ReadLine();
            }
            else
            {
                stockPath = args[1];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter tbill path (e.g. C:\\Temp\\Tbill): ");
                tbillPath = Console.ReadLine();
            }
            else
            {
                tbillPath = args[2];
            }

            if (args.Length != 4)
            {
                Console.WriteLine("\nEnter stat path (e.g. C:\\Temp\\Stat): ");
                statPath = Console.ReadLine();
            }
            else
            {
                statPath = args[3];
            }

            // debug
            //portfolioPath = @"C:\MineStock\Environment";
            //stockPath = @"C:\MineStock\Environment\Data\Stock";
            //tbillPath = @"C:\MineStock\Environment\Data\Tbill";
            //statPath = @"C:\MineStock\Environment\Data\Stat";

            // start
            Console.WriteLine();
            List<Portfolio> portfolioList = (List<Portfolio>)XMLHelper.ObjectFromXML(portfolioPath + @"\Portfolio.xml", typeof(List<Portfolio>));
            Tbill tbill = XMLHelper.TbillFromXML(tbillPath + @"\2.xml");

            foreach (Portfolio eachElm in portfolioList)
            {
                string statFile = statPath + @"\" + eachElm.stockCode.Trim() + ".xml";
                Statistic statObj = (Statistic)XMLHelper.ObjectFromXML(statFile, typeof(Statistic));
                eachElm.annualReturn = statObj.annualReturn;
                eachElm.annualVolatility = statObj.annualVolatility;
            }

            // fast method
            if (portfolioList.Count == 0)
            {
                return;
            }
            else if (portfolioList.Count == 1)
            {
                portfolioList[0].optimumPercent = 100;
            }
            else if (portfolioList.Count == 2 && false)
            {
                // this method will generate false result if asset return is negative
                // it will turns out to borrow the asset will negative interest rate

                Stock a = XMLHelper.StockFromXML(stockPath + @"\" + portfolioList[0].stockCode + ".xml");
                Stock b = XMLHelper.StockFromXML(stockPath + @"\" + portfolioList[1].stockCode + ".xml");

                // MPT - arithmetric approach, formula acquired by taking the 1st derivative
                double aYield = portfolioList[0].annualReturn / 100;
                double bYield = portfolioList[1].annualReturn / 100;
                double fYield = tbill.ytm / 100;
                double aVar = Math.Pow(portfolioList[0].annualVolatility / 100, 2);
                double bVar = Math.Pow(portfolioList[1].annualVolatility / 100, 2);
                double covAB = StatHelper.GetDailyCovariance(a.priceList, b.priceList);

                portfolioList[0].optimumPercent =
                    100 * ((aYield - fYield) * bVar - (bYield - fYield) * covAB);
                portfolioList[0].optimumPercent /=
                    (aYield - fYield) * bVar + (bYield - fYield) * aVar - (aYield + bYield - 2 * fYield) * covAB;
                portfolioList[1].optimumPercent =
                    (100 - portfolioList[0].optimumPercent);
            }
            else if (portfolioList.Count < 100)
            {
                int count = portfolioList.Count;
                List<Tick>[] tickList = new List<Tick>[count];

                for (int i = 0; i < count; i++)
                {
                    Stock temp = XMLHelper.StockFromXML(stockPath + @"\" + portfolioList[i].stockCode + ".xml");
                    tickList[i] = temp.priceList;
                }

                double[,] covariance = StatHelper.GetCovarianceMatrix(tickList);

                // debug
                for (int i = 0; i < Math.Sqrt(covariance.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(covariance.Length); j++)
                    {
                        Console.Write(covariance[i, j] + ", ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                tickList = null;
                double[] bestWeighting = new double[portfolioList.Count];
                int max = 100;
                double sharpe = double.NegativeInfinity;

                // MPT - trial and error approach
                recursiveTrial(1, max, portfolioList, covariance, tbill.ytm / 100, 0,
                    new double[portfolioList.Count], bestWeighting, new List<double[]>(), ref sharpe);

                Console.WriteLine();

                for (int i = 0; i < portfolioList.Count; i++)
                {
                    portfolioList[i].optimumPercent = (double)bestWeighting[i] / max * 100;
                    Console.WriteLine(portfolioList[i].stockCode + " is " + portfolioList[i].optimumPercent + "%");
                }
            }

            // ok - write the result out
            XMLHelper.ObjectToXML(portfolioList, portfolioPath, "Portfolio");
        }

        public static void recursiveTrial(int min, int max, List<Portfolio> pList, double[,] cMatrix,
            double tbillYtm, int currentElm, double[] currentWeighting, double[] bestWeighting, List<double[]> failWeighting,
            ref double bestSharpe)
        {
            if (1 + currentElm <= pList.Count)
            {
                // generate a weighting combination
                for (int i = min; i <= max; i++)
                {
                    currentWeighting[currentElm] = i;
                    recursiveTrial(min, max, pList, cMatrix,
                        tbillYtm, currentElm + 1, currentWeighting, bestWeighting, failWeighting, ref bestSharpe);
                }
                if (1 + currentElm != pList.Count()) failWeighting.Clear();
            }
            else
            {
                // test - whether the weighting exceed defined max
                int current = 0;

                foreach (int i in currentWeighting)
                {
                    current += i;
                }

                // ok - calculate annual portfolio return and volatility
                if (current == max && failWeighting.Count < 3)
                {
                    double pYield = 0;
                    double pVol = 0;

                    pYield = StatHelper.GetPortfolioReturn(pList, currentWeighting, max);
                    pVol = StatHelper.GetPortfolioSD(pList, currentWeighting, max, cMatrix);

                    double currentSharpe = ((pYield - tbillYtm) / pVol);
                    string debug = "";

                    for (int i = 0; i < currentWeighting.Length; i++)
                    {
                        // output to console
                        debug += currentWeighting[i] + ", ";
                    }

                    // output to console
                    debug += "shapre = " + currentSharpe;
                    Console.Write(debug);

                    // new optimal
                    if (currentSharpe > bestSharpe)
                    {
                        for (int i = 0; i < currentWeighting.Length; i++)
                        {
                            // store the weighting
                            bestWeighting[i] = currentWeighting[i];
                        }

                        // store the sharpe
                        bestSharpe = (pYield - tbillYtm) / pVol;
                        failWeighting.Clear();
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.WriteLine("");
                        failWeighting.Add((double[])currentWeighting.Clone());
                    }
                }
            }
        }
    }
}
