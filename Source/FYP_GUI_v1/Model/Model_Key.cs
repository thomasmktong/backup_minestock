using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_GUI_v1
{
    class Model_Key
    {
        public static string STOCK_CODE = "Stock code: code of the stock";
        public static string STOCK_NAME = "Stock name: name of the stock";
        public static string LAST_PRICE = "Last price: last traded price";
        public static string EXPECTED_RETURN = "E(R), % p.a.: expected return per annum, expressed in %";
        public static string SHARPE = "Sharpe: risk adjusted return, higher the better";
        public static string BETA = "Beta: sensitivity to the market according to CAPM model, higher the risker";
        public static string ALPHA = "Alpha: abnormal return according to CAPM model, expressed in %, higher the better";
        public static string VAR_1 = "%VaR, 5%: value at risk at 5% of the time, parametric calc., expressed in %, lower the better";
        public static string VAR_2 = "%VaR, 5% hist: value at risk at 5% of the time, historical data, expressed in %, lower the better";
        public static string VAR_3 = "%VaR, 5%: value at risk at 5% of the time, parametric calc., expressed in $, lower the better";
        public static string VAR_4 = "%VaR, 5% hist: value at risk at 5% of the time, historical data, expressed in $, lower the better";

        public static string results_key()
        {
            return STOCK_CODE + "\n" + STOCK_NAME + "\n" + LAST_PRICE + "\n" + EXPECTED_RETURN + "\n" +
                SHARPE + "\n" + BETA + "\n" + ALPHA + "\n" + VAR_1 + "\n" + VAR_2 + "\n" + VAR_3 + "\n" + VAR_4;
        }

        public static string portfolio_key()
        {
            return STOCK_CODE + "\n" + STOCK_NAME + "\n" + LAST_PRICE + "\n" + EXPECTED_RETURN + "\n" +
                 SHARPE + "\n" + BETA + "\n" + ALPHA + "\n" + VAR_1;
        }
    }
}
