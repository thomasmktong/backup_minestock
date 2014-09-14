using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_CategorizeStockData
{
    class Mapping
    {
        public static Type[] algorithms = { 
                                              typeof(UpDownChangeHelper), 
                                              typeof(AboveBelowAvgHelper) };
    }
}
