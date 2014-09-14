using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_Common
{
    public class GenusTick : Tick
    {
        public int degreeOfChange;

        public GenusTick()
        {
            this.degreeOfChange = 0;
        }

        public GenusTick(int change)
        {
            this.degreeOfChange = change;
        }
    }
}
