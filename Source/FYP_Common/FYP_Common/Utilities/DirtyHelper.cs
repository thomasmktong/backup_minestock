using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_Common
{
    public class DirtyHelper
    {
        public static bool CheckWetherThisStockIsALonelyStock(Dictionary<Stock, int> stockClusterMapping, int checkClusterCode)
        {
            if (checkClusterCode < 0) return false;

            int count = 0;
            foreach (KeyValuePair<Stock, int> eachKYP in stockClusterMapping)
            {
                if (eachKYP.Value == checkClusterCode)
                {
                    count++;
                    if (count > 1) return false;
                }
            }

            if (count == 1)
            {
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static bool CheckWetherClusterHasNoStock(Dictionary<Stock, int> stockClusterMapping, int checkClusterCode)
        {
            if (checkClusterCode < 0) return false;

            foreach (KeyValuePair<Stock, int> eachKYP in stockClusterMapping)
            {
                if (eachKYP.Value == checkClusterCode)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
