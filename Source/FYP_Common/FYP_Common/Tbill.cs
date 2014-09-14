using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_Common
{

    public class Tbill
    {
        private static string[] terms = { "3-Month","6-Month", "12-Month", // T-bill
            "2-Year", "3-Year", "5-Year", "7-Year", "10-Year", // T-note
            "30-Year" }; // T-bond

        public int period = -1;

        public void SetPeriodByString(string p)
        {
            for (int i = 0; i < terms.Length; i++)
            {
                if (p.CompareTo(terms[i]) == 0)
                {
                    period = i;
                }
            }
        }

        public string GetStringPeriod()
        {
            string toReturn;
            try
            {
                toReturn = terms[period];
            }
            catch (Exception ex)
            {
                toReturn = "Undefined";
            }
            return toReturn;
        }

        public double GetDoublePrice(double par)
        {
            double toReturn;

            // short term
            if (Double.TryParse(price, out toReturn))
            {
                toReturn = par / (1 + toReturn);
                return toReturn;
            }

            // long term
            int prefixPart = int.Parse(price.Split(new Char[] { '-' }, 2)[0]);
            int suffixPart = int.Parse(price.Split(new Char[] { '-' }, 2)[1].Trim().Replace("+", "").Replace("&#189;", ""));

            toReturn = (par * (prefixPart + (double)suffixPart / 32)) / 100;

            if (price.Contains("&#189;"))
            {
                toReturn = toReturn + par * ((double)0.5 / 32) / 100;
            }

            if (price.Contains("+"))
            {
                toReturn = toReturn + par * ((double)1 / 64) / 100;
            }

            return toReturn;
        }

        public double coupon;
        // public DateTime maturity;
        public string price;
        public double ytm;
        public DateTime time;
    }
}
