using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FYP_Common;
using System.Text.RegularExpressions;
using System.IO;

namespace FYP_GetTbillData
{
    class GetDataMain
    {
        static void Main(string[] args)
        {
            string filePath;

            Console.WriteLine("########################################");
            Console.WriteLine("# Module:\tFYP_GetTbillData");
            Console.WriteLine("# Author:\tThomas Tong");
            Console.WriteLine("# Email:\tmankintong@gmail.com");
            Console.WriteLine("########################################\n");

            if (args.Length != 1)
            {
                Console.WriteLine("\nEnter store path (e.g. C:\\Temp\\Tbill): ");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[0];
            }

            // here we start everything - create directory if not exist
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            // remove all files in the output folder first - added 8 feb 
            Array.ForEach(Directory.GetFiles(filePath), delegate(string path) { File.Delete(path); });

            try
            {
                foreach (Tbill eachTerm in DownloadTbillData())
                {
                    XMLHelper.TbillToXML(eachTerm, filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nProcess exited.");
        }

        static List<Tbill> DownloadTbillData()
        {
            List<Tbill> toReturn = new List<Tbill>();
            string regex = @"<td class=""name"">(?<period>.*)</td>\n *<td class=""value"">(?<coupon>.*)</td>\n *<td class=""value"">(?<maturity>\d{2}/\d{2}/\d{4})</td>\n *<td class=""value"">(?<price>.*)/(?<yield>.*)</td>";

            // **********
            // Note: regex for tbill info extraction
            // <td class="name">(?<period>.*)</td>[\r\n]*<td class="value">(?<coupon>.*)</td>[\r\n]*<td class="value">(?<maturity>\d{2}/\d{2}/\d{4})</td>[\r\n]*<td class="value">.*[\r\n]*.*/\r\n(?<yield>.*)</td>
            // 
            // Match the characters “<td class="name">” literally «<td class="name">»
            // Match the regular expression below and capture its match into backreference with name “period” «(?<period>.*)»
            //    Match any single character that is not a line break character «.*»
            //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            // Match the characters “</td>” literally «</td>»
            // Match a single character present in the list below «[\r\n]*»
            //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            //    A carriage return character «\r»
            //    A line feed character «\n»
            // Match the characters “<td class="value">” literally «<td class="value">»
            // Match the regular expression below and capture its match into backreference with name “coupon” «(?<coupon>.*)»
            //    Match any single character that is not a line break character «.*»
            //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            // Match the characters “</td>” literally «</td>»
            // Match a single character present in the list below «[\r\n]*»
            //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            //    A carriage return character «\r»
            //    A line feed character «\n»
            // Match the characters “<td class="value">” literally «<td class="value">»
            // Match the regular expression below and capture its match into backreference with name “maturity” «(?<maturity>\d{2}/\d{2}/\d{4})»
            //    Match a single digit 0..9 «\d{2}»
            //       Exactly 2 times «{2}»
            //    Match the character “/” literally «/»
            //    Match a single digit 0..9 «\d{2}»
            //       Exactly 2 times «{2}»
            //    Match the character “/” literally «/»
            //    Match a single digit 0..9 «\d{4}»
            //       Exactly 4 times «{4}»
            // Match the characters “</td>” literally «</td>»
            // Match a single character present in the list below «[\r\n]*»
            //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            //    A carriage return character «\r»
            //    A line feed character «\n»
            // Match the characters “<td class="value">” literally «<td class="value">»
            // Match any single character that is not a line break character «.*»
            //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            // Match a single character present in the list below «[\r\n]*»
            //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            //    A carriage return character «\r»
            //    A line feed character «\n»
            // Match any single character that is not a line break character «.*»
            //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            // Match the character “/” literally «/»
            // Match a carriage return character «\r»
            // Match a line feed character «\n»
            // Match the regular expression below and capture its match into backreference with name “yield” «(?<yield>.*)»
            //    Match any single character that is not a line break character «.*»
            //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
            // Match the characters “</td>” literally «</td>»

            try
            {
                Regex regexObj = new Regex(regex);

                Match matchResult = regexObj.Match(DownloadBloombergPage());
                while (matchResult.Success && (toReturn.Count == 0 || toReturn.Last().period < 8))
                {
                    Tbill tbill = new Tbill();
                    tbill.SetPeriodByString(matchResult.Groups["period"].Value.Trim());
                    tbill.coupon = double.Parse(matchResult.Groups["coupon"].Value.Trim());
                    // maturity
                    tbill.price = matchResult.Groups["price"].Value.Trim();
                    tbill.ytm = double.Parse(matchResult.Groups["yield"].Value.Trim());
                    tbill.time = DateTime.Now;
                    toReturn.Add(tbill);
                    matchResult = matchResult.NextMatch();
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }

            return toReturn;
        }

        static string DownloadBloombergPage()
        {
            string url = "http://www.bloomberg.com/markets/rates-bonds/government-bonds/us/";
            return MiscHelper.FetchInternetPlainText(url);
        }
    }
}
