using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_Common
{
    public class Cluster
    {
        public int clusterCode;
        public List<int> stockCodeList;
        public List<Tick> centroid;

        // in some algorithm, some clusters may be able to directly identified as useless
        // public bool significant = true;
    }
}
