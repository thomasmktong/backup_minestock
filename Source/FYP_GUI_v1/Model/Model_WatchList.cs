using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;
using System.ComponentModel;

namespace FYP_GUI_v1
{
    public class Model_WatchList : INotifyPropertyChanged
    {
        // static
        public static BindingList<Model_WatchList> list = null;
        public static string DEFAULT_STOCK_NAME = "Undefined";
        public static double DEFAULT_STOCK_PRICE = 0.0;

        public static void WriteList()
        {
            if (list != null)
            {
                XMLHelper.ObjectToXML(list, Config.ENVIRONMENT_PATH_DEFAULT, "WatchList");
            }
        }

        public static void LoadList()
        {
            try
            {
                string file = Config.ENVIRONMENT_PATH_DEFAULT + "\\WatchList.xml";
                list = (BindingList<Model_WatchList>)XMLHelper.ObjectFromXML(file, typeof(BindingList<Model_WatchList>));
                UpdateList();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                list = new BindingList<Model_WatchList>();
                DefaultList();
            }
        }

        public static void DefaultList()
        {
            // nothing
        }

        public static void UpdateList()
        {
            foreach (Model_WatchList eachElm in list)
            {
                eachElm.Update();
            }
        }

        // object
        private string stockCode;

        [DisplayName("Code")]
        public string StockCode
        {
            get { return stockCode; }
            set { stockCode = value; this.NotifyPropertyChanged("StockCode"); }
        }

        private string stockName;

        [DisplayName("Name")]
        public string StockName
        {
            get { return stockName; }
            set { stockName = value; this.NotifyPropertyChanged("StockName"); }
        }

        private double price;

        [DisplayName("Px")]
        public double Price
        {
            get { return price; }
            set { price = value; this.NotifyPropertyChanged("Price"); }
        }

        private double change;

        [DisplayName("Chg %")]
        public double Change
        {
            get { return change; }
            set { change = value; this.NotifyPropertyChanged("Change"); }
        }

        public Model_WatchList()
        {
            stockCode = "";
            stockName = "";
            price = 0.0;
            change = 0.0;
        }

        public Model_WatchList(string stockCode)
            : this(stockCode, DEFAULT_STOCK_NAME, DEFAULT_STOCK_PRICE, DEFAULT_STOCK_PRICE)
        {
            // nothing
        }

        public Model_WatchList(string stockCode, string nameIfNE, double priceIfNE, double changeIfNE)
        {
            this.stockCode = stockCode.Trim().Replace(".HK", "").Replace(".hk", "");

            try
            {
                string path = Config.STOCK_PATH_DEFAULT + @"\" + this.stockCode + ".xml";
                Stock stock = XMLHelper.StockFromXML(path);
                this.stockName = stock.stockName;
                this.price = Math.Round(((NumericTick)stock.priceList[stock.priceList.Count - 1]).close, 2);
                this.change = Math.Round(((NumericTick)stock.priceList[stock.priceList.Count - 1]).change, 2);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                this.stockName = nameIfNE;
                this.price = priceIfNE;
                this.change = changeIfNE;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
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
                this.price = Math.Round(((NumericTick)stock.priceList[stock.priceList.Count - 1]).close, 2);
                this.change = Math.Round(((NumericTick)stock.priceList[stock.priceList.Count - 1]).change, 2);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                this.stockName = DEFAULT_STOCK_NAME;
                this.price = DEFAULT_STOCK_PRICE;
                this.change = DEFAULT_STOCK_PRICE;
            }
        }

        public Stock GetStockInstance()
        {
            try
            {
                string path = Config.STOCK_PATH_DEFAULT + @"\" + this.stockCode + ".xml";
                return XMLHelper.StockFromXML(path);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                return null;
            }
        }
    }
}
