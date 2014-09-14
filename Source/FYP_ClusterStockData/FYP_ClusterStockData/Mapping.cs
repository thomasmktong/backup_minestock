using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_ClusterStockData
{
    public enum InputType
    {
        GENUS,
        NUMERIC
    }

    public class Mapping
    {
        public static Type[] algorithms = { 
                                              typeof(KMeanHelper), 
                                              typeof(SSECHelper), 
                                              typeof(MotifHelper),
                                              typeof(TempCheckHelper)};

        public static InputType[] inputs = { 
                                               InputType.NUMERIC, 
                                               InputType.GENUS, 
                                               InputType.GENUS,
                                               InputType.GENUS};
    }
}
