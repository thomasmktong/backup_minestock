using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FYP_Common
{
    public class Portfolio
    {
        public string stockCode;
        public string stockName;
        public double buyingQuantity;
        public double buyingPrice;

        [XmlIgnoreAttribute]
        public double annualReturn;

        [XmlIgnoreAttribute]
        public double annualVolatility;

        public double optimumPercent;
    }
}
