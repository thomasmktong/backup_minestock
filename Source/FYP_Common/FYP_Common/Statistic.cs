using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FYP_Common
{
    public class Statistic
    {
        [XmlIgnoreAttribute()]
        public static string FAKE_FILE_FILE_NAME = "Acceptance";

        public int stockCode;
        public string stockName;
        public double stockPrice;

        public double annualReturn;
        public double annualVolatility;
        public double sharpeRatio;
        public double beta;
        public double alpha;

        public double paraPercentVaR;
        public double histPercentVaR;

        public double paraDollarVaR;
        public double histDollarVaR;

        public int sampleCount;
    }
}
