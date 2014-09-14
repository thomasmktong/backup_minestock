using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_Common
{
    public class FakeTick : Tick
    {
        public FakeTick()
        {
            this.key = "";
            this.value = 0.0;
        }

        public FakeTick(string key, double value)
        {
            this.key = key;
            this.value = value;
        }

        public string key;
        public double value;
    }
}
