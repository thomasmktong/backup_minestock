using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FYP_Common
{
    public enum Identifier
    {
        N, // Normal
        W, // Weekend
        D // Dummy
    }

    [XmlInclude(typeof(NumericTick))]
    [XmlInclude(typeof(GenusTick))]
    [XmlInclude(typeof(FakeTick))]
    public class Tick
    {
        public Tick()
        {
            id = Identifier.D;
        }

        public DateTime Time
        {
            get { return time; }
            set
            {
                time = value;
                if (value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday)
                {
                    id = Identifier.W;
                }
            }
        }

        private DateTime time;
        public Identifier id;
    }
}
