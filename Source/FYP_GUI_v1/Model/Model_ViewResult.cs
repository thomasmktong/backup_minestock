using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FYP_Common;

namespace FYP_GUI_v1
{
    public class Model_ViewResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int stockCode;
        private string stockName;
        private double stockPrice;
        private double annualReturn;
        private double sharpe;
        private double beta;
        private double alpha;
        private double paraPercentVaR;
        private double histPercentVaR;
        private double paraDollarVaR;
        private double histDollarVaR;

        // constructor & methods
        public Model_ViewResult()
        {
            // do nothing
        }

        public Model_ViewResult(Statistic stockStat)
        {
            this.stockCode = stockStat.stockCode;
            this.stockName = (stockStat.stockName == null || stockStat.stockName.Length == 0) ? "Unknown" : stockStat.stockName;
            this.stockPrice = stockStat.stockPrice;
            this.annualReturn = Math.Round(stockStat.annualReturn, 2);
            this.sharpe = Math.Round(stockStat.sharpeRatio, 2);
            this.beta = Math.Round(stockStat.beta, 2);
            this.alpha = Math.Round(stockStat.alpha, 2);
            this.paraPercentVaR = Math.Round(stockStat.paraPercentVaR, 2);
            this.histPercentVaR = Math.Round(stockStat.histPercentVaR, 2);
            this.paraDollarVaR = Math.Round(stockStat.paraDollarVaR, 2);
            this.histDollarVaR = Math.Round(stockStat.histDollarVaR, 2);
        }

        [DisplayName("Stock code")]
        public int StockCode
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

        [DisplayName("Last price")]
        public double StockPrice
        {
            get { return stockPrice; }
            set { stockPrice = value; this.NotifyPropertyChanged("StockPrice"); }
        }

        [DisplayName("E(R), % p.a.")]
        public double AnnualReturn
        {
            get { return annualReturn; }
            set { annualReturn = value; this.NotifyPropertyChanged("AnnualReturn"); }
        }

        public double Sharpe
        {
            get { return sharpe; }
            set { sharpe = value; this.NotifyPropertyChanged("Sharpe"); }
        }

        public double Beta
        {
            get { return beta; }
            set { beta = value; this.NotifyPropertyChanged("Beta"); }
        }

        public double Alpha
        {
            get { return alpha; }
            set { alpha = value; this.NotifyPropertyChanged("Alpha"); }
        }

        [DisplayName("%VaR, 5%")]
        public double ParaPercentVaR
        {
            get { return paraPercentVaR; }
            set { paraPercentVaR = value; this.NotifyPropertyChanged("ParaPercentVaR"); }
        }

        [DisplayName("%VaR, 5% hist")]
        public double HistPercentVaR
        {
            get { return histPercentVaR; }
            set { histPercentVaR = value; this.NotifyPropertyChanged("HistPercentVaR"); }
        }

        [DisplayName("$VaR, 5%")]
        public double ParaDollarVaR
        {
            get { return paraDollarVaR; }
            set { paraDollarVaR = value; this.NotifyPropertyChanged("ParaDollarVaR"); }
        }

        [DisplayName("$VaR, 5% hist")]
        public double HistDollarVaR
        {
            get { return histDollarVaR; }
            set { histDollarVaR = value; this.NotifyPropertyChanged("HistDollarVaR"); }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
