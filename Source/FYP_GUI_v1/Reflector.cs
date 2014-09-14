using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

namespace FYP_GUI_v1
{
    class Reflector
    {
        public static Button AssignButtonEvent(Button b, System.EventHandler e)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic); object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null); list.RemoveHandler(obj, list[obj]);
            b.Click += e;
            return b;
        }
    }
}
