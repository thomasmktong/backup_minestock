using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_Common
{
    public class NumericTick : Tick
    {
        public double open;
        public double close;
        public double high;
        public double low;
        public double adjustedClose;
        public double change;
        public double adjustedChange;
        public string volume;

        public NumericTick()
        {
            volume = "0";
        }
    }
}
