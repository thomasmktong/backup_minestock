using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_GUI_v1
{
    public class Form_Autoseqdef
    {
        public enum AutomationFlow
        {
            USE_SUBSET, USE_UNIVERSAL_SET
        }

        public enum Criteria
        {
            CLUSTER_WITH_STOCKS_MORE_THAN, CLUSTER_MARKED_AS_SIGNIFICANT
        }

        public string dataPath;
        public string clusterPath;
        public string logPath;
        public AutomationFlow automationFlow;
        public Criteria criteria;
        public int minimumStocks;
    }
}
