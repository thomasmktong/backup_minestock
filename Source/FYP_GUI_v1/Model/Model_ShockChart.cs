using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;
using System.Drawing;

namespace FYP_GUI_v1
{
    public class Model_ShockChart
    {
        // static
        private static string[] allColors = Enum.GetNames(typeof(System.Drawing.KnownColor));

        public static Color getLineColor(int color)
        {
            return getLineColor(allColors[(color) % allColors.Length]);
        }

        public static Color getLineColor(string color)
        {
            return Color.FromName(color);
        }

        // object
        public Stock stock;
        public Color color;

        public Model_ShockChart(Stock stock, Color color)
        {
            this.stock = stock;
            this.color = color;
            this.color.ToKnownColor();
        }

        public override string ToString()
        {
            return stock.stockCode + ", " + color.Name;
        }
    }
}
