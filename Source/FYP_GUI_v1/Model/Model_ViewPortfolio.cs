using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FYP_Common;
using System.Xml.Serialization;

namespace FYP_GUI_v1
{
    public class Model_ViewPortfolio
    {
        public enum CalculationMode
        {
            CURRENT, TARGET
        }

        // static
        public static BindingList<Model_ViewPortfolio> list = null;

        public static void WriteList()
        {
            if (list != null)
            {
                List<Portfolio> toOutput = new List<Portfolio>();

                foreach (Model_ViewPortfolio eachElm in list)
                {
                    if (eachElm.stockCode != null && eachElm.stockCode.Trim().Length != 0)
                    {
                        toOutput.Add(eachElm.getPrimitive());
                    }
                }

                XMLHelper.ObjectToXML(toOutput, Config.ENVIRONMENT_PATH_DEFAULT, "Portfolio");
            }
        }

        public static void LoadList()
        {
            list = new BindingList<Model_ViewPortfolio>();
            try
            {
                string file = Config.ENVIRONMENT_PATH_DEFAULT + "\\Portfolio.xml";
                List<Portfolio> temp = (List<Portfolio>)XMLHelper.ObjectFromXML(file, typeof(List<Portfolio>));

                foreach (Portfolio eachElm in temp)
                {
                    list.Add(new Model_ViewPortfolio(eachElm));
                }

                UpdateList();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                DefaultList();
            }
        }

        public static void DefaultList()
        {
            // nothing
        }

        public static void UpdateList()
        {
            double portfolioTotal = 0;

            foreach (Model_ViewPortfolio eachElm in list)
            {
                eachElm.Update();
                portfolioTotal += eachElm.buyingQuantity * eachElm.currentPrice;
            }

            foreach (Model_ViewPortfolio eachElm in list)
            {
                if (eachElm.buyingQuantity != 0)
                {
                    eachElm.contributionToPortfolio =
                        eachElm.buyingQuantity * eachElm.currentPrice * 100 / portfolioTotal;
                }
                else
                {
                    eachElm.contributionToPortfolio = 0;
                }
            }
        }

        public static void ResetWeighting()
        {
            foreach (Model_ViewPortfolio eachElm in list)
            {
                eachElm.optimalToPortfolio = "<Press calc>";
            }
        }

        public static double PortfolioReturn(CalculationMode mode)
        {
            double toReturn = 0.0;

            foreach (Model_ViewPortfolio eachPortfolioElm in list)
            {
                string eachPath = Config.STAT_PATH_DEFAULT + @"\" + eachPortfolioElm.stockCode + ".xml";
                Statistic eachStat = (Statistic)XMLHelper.ObjectFromXML(eachPath, typeof(Statistic));

                if (mode == CalculationMode.CURRENT)
                {
                    toReturn += eachStat.annualReturn / 100 * eachPortfolioElm.contributionToPortfolio / 100;
                }
                else
                {
                    toReturn += eachStat.annualReturn / 100 * double.Parse(eachPortfolioElm.optimalToPortfolio) / 100;
                }
            }

            return toReturn;
        }

        public static double PortfolioVolatility(CalculationMode mode)
        {
            List<Portfolio> selectedStockList = new List<Portfolio>();
            List<Tick>[] ticksList = new List<Tick>[list.Count];
            double[] valueOfStockList = new double[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                selectedStockList.Add(list[i].getPrimitive());
                string eachPath = Config.STOCK_PATH_DEFAULT + @"\" + list[i].stockCode + ".xml";
                Stock eachStock = XMLHelper.StockFromXML(eachPath);
                ticksList[i] = eachStock.priceList;

                if (mode == CalculationMode.CURRENT)
                {
                    valueOfStockList[i] = list[i].contributionToPortfolio;
                }
                else
                {
                    valueOfStockList[i] = double.Parse(list[i].optimalToPortfolio);
                }
            }

            return StatHelper.GetPortfolioSD(selectedStockList,
                valueOfStockList, 100, StatHelper.GetCovarianceMatrix(ticksList));
        }

        public static double PortfolioSharpe(CalculationMode mode)
        {
            try
            {
                Tbill tbill = XMLHelper.TbillFromXML(Config.TBILL_PATH_DEFAULT + @"\2.xml");
                return (PortfolioReturn(mode) - tbill.ytm / 100) / PortfolioVolatility(mode);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                return 0.0;
            }
        }

        public static double PortfolioBeta(CalculationMode mode)
        {
            double toReturn = 0.0;

            foreach (Model_ViewPortfolio eachPortfolioElm in list)
            {
                string eachPath = Config.STAT_PATH_DEFAULT + @"\" + eachPortfolioElm.stockCode + ".xml";
                Statistic eachStat = (Statistic)XMLHelper.ObjectFromXML(eachPath, typeof(Statistic));

                if (mode == CalculationMode.CURRENT)
                {
                    toReturn += eachStat.beta * eachPortfolioElm.contributionToPortfolio / 100;
                }
                else
                {
                    toReturn += eachStat.beta * double.Parse(eachPortfolioElm.optimalToPortfolio) / 100;
                }
            }

            return toReturn;
        }

        public static double PortfolioAlpha(CalculationMode mode)
        {
            string tempPath = Config.STAT_PATH_DEFAULT + @"\" + Model_ViewPortfolio.list[0].stockCode + ".xml";
            Statistic tempStat = (Statistic)XMLHelper.ObjectFromXML(tempPath, typeof(Statistic));
            Tbill tbill = XMLHelper.TbillFromXML(Config.TBILL_PATH_DEFAULT + @"\2.xml");
            double riskPrem = (tempStat.annualReturn - tempStat.alpha - tbill.ytm) / 100 / tempStat.beta;

            return PortfolioReturn(mode) - tbill.ytm / 100 - PortfolioBeta(mode) * riskPrem;
        }

        public static bool PortfolioOptimized()
        {
            try
            {
                foreach (Model_ViewPortfolio eachElm in list)
                {
                    double.Parse(eachElm.optimalToPortfolio);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                return false;
            }
        }

        private string stockCode;
        private string stockName;
        private double buyingQuantity;
        private double buyingPrice;
        private double currentPrice;
        private double pnlPercent;
        private double contributionToPortfolio;
        private string optimalToPortfolio = "<Press calculate>";

        public Model_ViewPortfolio()
        {
            // original constructor
        }

        public Model_ViewPortfolio(Portfolio primitive)
        {
            this.stockCode = primitive.stockCode;
            this.stockName = primitive.stockName;
            this.buyingQuantity = primitive.buyingQuantity;
            this.buyingPrice = primitive.buyingPrice;

            if (primitive.optimumPercent > 0)
            {
                this.optimalToPortfolio = primitive.optimumPercent + "";
            }
            else
            {
                this.optimalToPortfolio = "<Press calculate>";
            }
        }

        [DisplayName("Stock code")]
        public string StockCode
        {
            get { return stockCode; }
            set { stockCode = value; this.NotifyPropertyChanged("StockCode"); }
        }

        [DisplayName("Stock name")]
        public string StockName
        {
            get { return stockName; }
            set { stockName = value; this.NotifyPropertyChanged("StockName"); }
        }

        [DisplayName("Quantity")]
        public double BuyingQuantity
        {
            get { return buyingQuantity; }
            set { buyingQuantity = value; this.NotifyPropertyChanged("BuyingQuantity"); }
        }

        [DisplayName("Buying price")]
        public double BuyingPrice
        {
            get { return buyingPrice; }
            set { buyingPrice = value; this.NotifyPropertyChanged("BuyingPrice"); }
        }

        [DisplayName("Last price")]
        public double CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; this.NotifyPropertyChanged("CurrentPrice"); }
        }

        [DisplayName("PnL %")]
        public double PnlPercent
        {
            get { return Math.Round(pnlPercent, 2); }
            set { pnlPercent = value; this.NotifyPropertyChanged("PnlPercent"); }
        }

        [DisplayName("Proportion %")]
        public double ContributionToPortfolio
        {
            get { return Math.Round(contributionToPortfolio, 2); }
            set { contributionToPortfolio = value; this.NotifyPropertyChanged("ContributionToPortfolio"); }
        }

        [DisplayName("Optimal %")]
        public string OptimalToPortfolio
        {
            get { return optimalToPortfolio; }
            set { optimalToPortfolio = value; this.NotifyPropertyChanged("OptimalToPortfolio"); }
        }

        public Portfolio getPrimitive()
        {
            Portfolio toReturn = new Portfolio();
            toReturn.stockCode = this.stockCode.Trim();
            toReturn.stockName = this.stockName;
            toReturn.buyingPrice = this.buyingPrice;
            toReturn.buyingQuantity = this.buyingQuantity;
            toReturn.optimumPercent = 0;

            double.TryParse(this.optimalToPortfolio, out toReturn.optimumPercent);
            return toReturn;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Update()
        {
            try
            {
                string path = Config.STOCK_PATH_DEFAULT + @"\" + this.stockCode + ".xml";
                Stock stock = XMLHelper.StockFromXML(path);
                this.stockName = stock.stockName;
                this.currentPrice = ((NumericTick)stock.priceList[stock.priceList.Count - 1]).close;
                this.pnlPercent = (currentPrice - buyingPrice) * 100 / buyingPrice;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
            }
        }
    }
}
