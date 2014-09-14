using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace FYP_Common
{
    public enum SpecialFileName
    {
        HSI = 0
    }

    public class XMLHelper
    {
        public static void StockToXML(Stock stock, String path)
        {
            string fileName = stock.stockCode + "";
            foreach (SpecialFileName s in Enum.GetValues(typeof(SpecialFileName)))
            {
                if ((int)s == stock.stockCode)
                {
                    stock.stockName = s.ToString();
                    fileName = s.ToString();
                }
            }

            // **********
            // Note: code & example from: http://www.switchonthecode.com/tutorials/csharp-tutorial-xml-serialization
            // **********

            XmlSerializer serializer = new XmlSerializer(typeof(Stock));
            TextWriter textWriter = new StreamWriter(path + "\\" + fileName + ".xml");
            serializer.Serialize(textWriter, stock);
            textWriter.Close();
        }

        public static void TbillToXML(Tbill tbill, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Tbill));
            TextWriter textWriter = new StreamWriter(path + "\\" + tbill.period + ".xml");
            serializer.Serialize(textWriter, tbill);
            textWriter.Close();
        }

        public static void ClusterToXML(Cluster cluster, String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Cluster));
            TextWriter textWriter = new StreamWriter(path + "\\" + cluster.clusterCode + ".xml");
            serializer.Serialize(textWriter, cluster);
            textWriter.Close();
        }

        public static void ObjectToXML(Object obj, string path, string name)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            TextWriter textWriter = new StreamWriter(path + "\\" + name + ".xml");
            serializer.Serialize(textWriter, obj);
            textWriter.Close();
        }

        public static Stock StockFromXML(string stockCode, string path)
        {
            return StockFromXML(path + "\\" + stockCode + ".xml");
        }

        public static Stock StockFromXML(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Stock));
            TextReader textReader = new StreamReader(path);
            Stock stock = (Stock)deserializer.Deserialize(textReader);
            textReader.Close();
            return stock;
        }

        public static Tbill TbillFromXML(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Tbill));
            TextReader textReader = new StreamReader(path);
            Tbill tbill = (Tbill)deserializer.Deserialize(textReader);
            textReader.Close();
            return tbill;
        }

        public static Cluster ClusterFromXML(string clusterID, string path)
        {
            return ClusterFromXML(path + "\\" + clusterID + ".xml");
        }

        public static Cluster ClusterFromXML(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Cluster));
            TextReader textReader = new StreamReader(path);
            Cluster cluster = (Cluster)deserializer.Deserialize(textReader);
            textReader.Close();
            return cluster;
        }

        public static Object ObjectFromXML(string path, Type type)
        {
            XmlSerializer deserializer = new XmlSerializer(type);
            TextReader textReader = new StreamReader(path);
            Object obj = deserializer.Deserialize(textReader);
            textReader.Close();
            return obj;
        }
    }
}
