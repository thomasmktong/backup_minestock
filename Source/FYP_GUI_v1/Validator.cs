using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FYP_GUI_v1
{
    public class Validator
    {
        public enum Identifier
        {
            INT, DOUBLE, PATH, DATE
        }

        public static string fastCheck(string tb, Identifier id)
        {
            return check(tb, id) ? "" : tb + " ";
        }

        public static string fastCheck(TextBox tb, Identifier id)
        {
            return check(tb.Text, id) ? "" : tb.Text + " ";
        }

        public static bool check(string tb, Identifier id)
        {
            if (id == Identifier.INT)
            {
                try
                {
                    int.Parse(tb);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            if (id == Identifier.DOUBLE)
            {
                try
                {
                    double.Parse(tb);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            if (id == Identifier.PATH)
            {
                if (!Directory.Exists(tb))
                {
                    return false;
                }
            }

            if (id == Identifier.DATE)
            {
                try
                {
                    new DateTime(int.Parse(tb.Substring(0, 4)),
                            int.Parse(tb.Substring(4, 2)),
                            int.Parse(tb.Substring(6, 2)));
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
