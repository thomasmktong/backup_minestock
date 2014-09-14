using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FYP_Common;
using System.Windows.Forms;

namespace FYP_GUI_v1
{
    public class Config
    {
        // exe
        public static string GET_STOCK_DATA_EXE;
        public static string GET_TBILL_DATA_EXE;
        public static string CLUSTER_STOCK_DATA_EXE;
        public static string CATEGORIZE_STOCK_DATA_EXE;
        public static string FILTER_STOCK_DATA_EXE;
        public static string TIMING_STOCK_DATA_EXE;
        public static string COMPILE_STOCK_DATA_EXE;
        public static string OPTIMIZE_PORTFOLIO_EXE;

        // default
        public static string ROOT_PATH_DEFAULT;
        public static string ENVIRONMENT_PATH_DEFAULT;

        public static string DATA_PATH_DEFAULT;
        public static string CLUSTER_PATH_DEFAULT;

        public static string STOCK_PATH_DEFAULT;
        public static string GENUS_PATH_DEFAULT;
        public static string INDEX_PATH_DEFAULT;
        public static string TBILL_PATH_DEFAULT;
        public static string STAT_PATH_DEFAULT;

        public static string LOG_PATH_DEFAULT;
        public static string EXPORT_PATH_DEFAULT;
        public static string AUTO_PATH_DEFAULT;

        // configue
        public static bool LIVE_STATUS;

        static Config()
        {
            try
            {
                Read();
            }
            catch (Exception ex)
            {
                // write the config ini file
                Default();
                Write();
            }
        }

        public static void Default()
        {
            // non environment related
            LIVE_STATUS = false;

            // environement related
            string basePath =
                @"C:\Documents and Settings\Thomas\My Documents\Visual Studio 2010\Projects";

            GET_STOCK_DATA_EXE = basePath +
                @"\FYP_GetStockData\FYP_GetStockData\bin\Release\FYP_GetStockData.exe";

            GET_TBILL_DATA_EXE = basePath +
                @"\FYP_GetTbillData\FYP_GetTbillData\bin\Release\FYP_GetTbillData.exe";

            CLUSTER_STOCK_DATA_EXE = basePath +
                @"\FYP_ClusterStockData\FYP_ClusterStockData\bin\Release\FYP_ClusterStockData.exe";

            CATEGORIZE_STOCK_DATA_EXE = basePath +
                @"\FYP_CategorizeStockData\FYP_CategorizeStockData\bin\Release\FYP_CategorizeStockData.exe";

            FILTER_STOCK_DATA_EXE = basePath +
                @"\FYP_FilterStockData\FYP_FilterStockData\bin\Release\FYP_FilterStockData.exe";

            TIMING_STOCK_DATA_EXE = basePath +
                @"\FYP_TimingStockData\FYP_TimingStockData\bin\Release\FYP_TimingStockData.exe";

            COMPILE_STOCK_DATA_EXE = basePath +
                @"\FYP_CompileStockData\FYP_CompileStockData\bin\Release\FYP_CompileStockData.exe";

            OPTIMIZE_PORTFOLIO_EXE = basePath +
                @"\FYP_OptimizePortfolio\FYP_OptimizePortfolio\bin\Release\FYP_OptimizePortfolio.exe";

            ROOT_PATH_DEFAULT = @"C:\MineStock";
            ENVIRONMENT_PATH_DEFAULT = ROOT_PATH_DEFAULT + @"\Environment";

            DATA_PATH_DEFAULT = ENVIRONMENT_PATH_DEFAULT + @"\Data";
            CLUSTER_PATH_DEFAULT = ENVIRONMENT_PATH_DEFAULT + @"\Cluster";

            STOCK_PATH_DEFAULT = DATA_PATH_DEFAULT + @"\Stock";
            GENUS_PATH_DEFAULT = DATA_PATH_DEFAULT + @"\Genus";
            INDEX_PATH_DEFAULT = DATA_PATH_DEFAULT + @"\Index";
            TBILL_PATH_DEFAULT = DATA_PATH_DEFAULT + @"\Tbill";
            STAT_PATH_DEFAULT = DATA_PATH_DEFAULT + @"\Stat";

            EXPORT_PATH_DEFAULT = @"C:\Temp";
            LOG_PATH_DEFAULT = @"C:\Temp\Log";
            AUTO_PATH_DEFAULT = @"C:\Temp\Auto";

            TryCreateDirectory();
        }

        public static void Write()
        {
            string path = Application.ExecutablePath;
            path = path.Substring(0, path.LastIndexOf(@"\"));
            INIHelper file = new INIHelper(path + @"\\Config.ini");

            file.IniWriteValue("PROGRAM", "GET_STOCK_DATA_EXE", GET_STOCK_DATA_EXE);
            file.IniWriteValue("PROGRAM", "GET_TBILL_DATA_EXE", GET_TBILL_DATA_EXE);
            file.IniWriteValue("PROGRAM", "CLUSTER_STOCK_DATA_EXE", CLUSTER_STOCK_DATA_EXE);
            file.IniWriteValue("PROGRAM", "CATEGORIZE_STOCK_DATA_EXE", CATEGORIZE_STOCK_DATA_EXE);
            file.IniWriteValue("PROGRAM", "FILTER_STOCK_DATA_EXE", FILTER_STOCK_DATA_EXE);
            file.IniWriteValue("PROGRAM", "TIMING_STOCK_DATA_EXE", TIMING_STOCK_DATA_EXE);
            file.IniWriteValue("PROGRAM", "COMPILE_STOCK_DATA_EXE", COMPILE_STOCK_DATA_EXE);
            file.IniWriteValue("PROGRAM", "OPTIMIZE_PORTFOLIO_EXE", OPTIMIZE_PORTFOLIO_EXE);

            file.IniWriteValue("ENVIRONMENT", "ENVIRONMENT_PATH_DEFAULT", ENVIRONMENT_PATH_DEFAULT);
            file.IniWriteValue("ENVIRONMENT", "DATA_PATH_DEFAULT", DATA_PATH_DEFAULT);
            file.IniWriteValue("ENVIRONMENT", "CLUSTER_PATH_DEFAULT", CLUSTER_PATH_DEFAULT);
            file.IniWriteValue("ENVIRONMENT", "STOCK_PATH_DEFAULT", STOCK_PATH_DEFAULT);
            file.IniWriteValue("ENVIRONMENT", "GENUS_PATH_DEFAULT", GENUS_PATH_DEFAULT);
            file.IniWriteValue("ENVIRONMENT", "INDEX_PATH_DEFAULT", INDEX_PATH_DEFAULT);
            file.IniWriteValue("ENVIRONMENT", "TBILL_PATH_DEFAULT", TBILL_PATH_DEFAULT);
            file.IniWriteValue("ENVIRONMENT", "STAT_PATH_DEFAULT", STAT_PATH_DEFAULT);

            file.IniWriteValue("SAVING", "EXPORT_PATH_DEFAULT", EXPORT_PATH_DEFAULT);
            file.IniWriteValue("SAVING", "LOG_PATH_DEFAULT", LOG_PATH_DEFAULT);
        }

        public static void Read()
        {
            string path = Application.ExecutablePath;
            path = path.Substring(0, path.LastIndexOf(@"\"));

            if (!File.Exists(path + @"\\Config.ini")) throw new Exception("Config.ini not exist");
            INIHelper file = new INIHelper(path + @"\\Config.ini");

            GET_STOCK_DATA_EXE = FormatPath(file.IniReadValue("PROGRAM", "GET_STOCK_DATA_EXE"));
            GET_TBILL_DATA_EXE = FormatPath(file.IniReadValue("PROGRAM", "GET_TBILL_DATA_EXE"));
            CLUSTER_STOCK_DATA_EXE = FormatPath(file.IniReadValue("PROGRAM", "CLUSTER_STOCK_DATA_EXE"));
            CATEGORIZE_STOCK_DATA_EXE = FormatPath(file.IniReadValue("PROGRAM", "CATEGORIZE_STOCK_DATA_EXE"));
            FILTER_STOCK_DATA_EXE = FormatPath(file.IniReadValue("PROGRAM", "FILTER_STOCK_DATA_EXE"));
            TIMING_STOCK_DATA_EXE = FormatPath(file.IniReadValue("PROGRAM", "TIMING_STOCK_DATA_EXE"));
            COMPILE_STOCK_DATA_EXE = FormatPath(file.IniReadValue("PROGRAM", "COMPILE_STOCK_DATA_EXE"));
            OPTIMIZE_PORTFOLIO_EXE = FormatPath(file.IniReadValue("PROGRAM", "OPTIMIZE_PORTFOLIO_EXE"));

            ENVIRONMENT_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "ENVIRONMENT_PATH_DEFAULT"));
            DATA_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "DATA_PATH_DEFAULT"));
            CLUSTER_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "CLUSTER_PATH_DEFAULT"));
            STOCK_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "STOCK_PATH_DEFAULT"));
            GENUS_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "GENUS_PATH_DEFAULT"));
            INDEX_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "INDEX_PATH_DEFAULT"));
            TBILL_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "TBILL_PATH_DEFAULT"));
            STAT_PATH_DEFAULT = FormatPath(file.IniReadValue("ENVIRONMENT", "STAT_PATH_DEFAULT"));

            EXPORT_PATH_DEFAULT = FormatPath(file.IniReadValue("SAVING", "EXPORT_PATH_DEFAULT"));
            LOG_PATH_DEFAULT = FormatPath(file.IniReadValue("SAVING", "LOG_PATH_DEFAULT"));
            AUTO_PATH_DEFAULT = EXPORT_PATH_DEFAULT + @"\Auto";
        }

        public static void TryCreateDirectory()
        {
            TryCreateDirectory(ROOT_PATH_DEFAULT);
            TryCreateDirectory(ENVIRONMENT_PATH_DEFAULT);
            TryCreateDirectory(DATA_PATH_DEFAULT);
            TryCreateDirectory(CLUSTER_PATH_DEFAULT);
            TryCreateDirectory(STOCK_PATH_DEFAULT);
            TryCreateDirectory(GENUS_PATH_DEFAULT);
            TryCreateDirectory(INDEX_PATH_DEFAULT);
            TryCreateDirectory(TBILL_PATH_DEFAULT);
            TryCreateDirectory(STAT_PATH_DEFAULT);
            TryCreateDirectory(LOG_PATH_DEFAULT);
            TryCreateDirectory(EXPORT_PATH_DEFAULT);
            TryCreateDirectory(AUTO_PATH_DEFAULT);
        }

        private static bool TryCreateDirectory(String path)
        {
            bool toReturn = true;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                toReturn = false;
            }
            return toReturn;
        }

        private static string FormatPath(string path)
        {
            return path.EndsWith(@"\") ? path.Substring(0, path.Length - 1) : path;
        }
    }
}
