using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using FYP_Common;

namespace FYP_GUI_v1
{
    // **********
    // Note: 
    // chart module by JChampion: http://www.codeproject.com/KB/graphics/zedgraph.aspx
    // color list tutorial by Fuad Bin Omar: http://www.codeproject.com/KB/custom-controls/csMultiColorDropDownList.aspx
    // **********
    public partial class Form_StockChart : Form
    {
        private string title = "";
        private List<Model_ShockChart> stockLineList = null;

        public Form_StockChart(Stock stock)
        {
            InitializeComponent();
            stockLineList = new List<Model_ShockChart>();
            stockLineList.Add(new Model_ShockChart(stock, Color.Blue));
            this.title = "Stock Chart of " + stock.stockCode + ".HK";
        }

        public Form_StockChart(string title, List<Stock> stockList)
        {
            InitializeComponent();
            stockLineList = new List<Model_ShockChart>();
            for (int i = 0; i < stockList.Count; i++)
            {
                stockLineList.Add(new Model_ShockChart(stockList[i], Model_ShockChart.getLineColor(i)));
            }

            if (title == null || title.Trim().Length == 0)
            {
                title = "Stock Chart of";
                for (int i = 0; i < stockList.Count; i++)
                {
                    title += ", " + stockList[i].stockCode + ".HK";
                }
            }
            else
            {
                this.title = title;
            }
        }

        public Form_StockChart(string title, List<Model_ShockChart> stockLineList)
        {
            InitializeComponent();
            this.stockLineList = stockLineList;

            if (title == null || title.Trim().Length == 0)
            {
                title = "Stock Chart of";
                for (int i = 0; i < stockLineList.Count; i++)
                {
                    title += ", " + stockLineList[i].stock.stockCode + ".HK";
                }
            }
            else
            {
                this.title = title;
            }
        }

        private void Form_StockChart_Load(object sender, EventArgs e)
        {
            // Get a reference to the GraphPane instance in the ZedGraphControl
            GraphPane myPane = zg1.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = this.Text = title;
            myPane.XAxis.Title.Text = "Date";
            myPane.YAxis.Title.Text = "Close price";

            foreach (Model_ShockChart eachModel in stockLineList)
            {
                // Make up some data points based on the Sine function
                StockPointList spl = new StockPointList();

                foreach (Tick eachTick in eachModel.stock.priceList)
                {
                    double x = new XDate(eachTick.Time);
                    double open = ((NumericTick)eachTick).open;
                    double close = ((NumericTick)eachTick).close;
                    double high = ((NumericTick)eachTick).high;
                    double low = ((NumericTick)eachTick).low;
                    double vol = 0.0;

                    try
                    {
                        vol = double.Parse(((NumericTick)eachTick).volume);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                    }

                    spl.Add(new StockPt(x, high, low, open, close, vol));
                }

                // Generate a blue curve with circle symbols, and "Beta" in the legend
                myPane.AddCurve(eachModel.stock.stockCode + ".HK", spl, eachModel.color, SymbolType.None);
            }

            // JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick(baseStock.stockCode + ".HK", spl);
            // myCurve.Stick.IsAutoSize = true;
            // myCurve.Stick.Color = Color.Blue;

            // myCurve = myPane.AddCurve("Beta", list2, Color.Blue, SymbolType.Circle);
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            // myCurve.IsY2Axis = true;

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis scale red
            // myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            // myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            // myPane.YAxis.Scale.Min = -30;
            // myPane.YAxis.Scale.Max = 30;
            // myPane.XAxis.Scale.Max = baseStock.priceList.Count;

            // Set the XAxis to date type
            myPane.XAxis.Type = AxisType.Date;

            // Enable the Y2 axis display
            // myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            // myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            // myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            // myPane.Y2Axis.MajorTic.IsOpposite = false;
            // myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            // myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            // myPane.Y2Axis.Scale.Align = AlignP.Inside;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Add a text box with instructions
            // TextObj text = new TextObj(
            //     "Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse",
            //     0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
            // text.FontSpec.StringAlignment = StringAlignment.Near;
            // myPane.GraphObjList.Add(text);

            // Enable scrollbars if needed
            zg1.IsShowHScrollBar = true;
            zg1.IsShowVScrollBar = true;
            zg1.IsAutoScrollRange = true;
            zg1.IsScrollY2 = true;

            // OPTIONAL: Show tooltips when the mouse hovers over a point
            zg1.IsShowPointValues = true;
            zg1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            // OPTIONAL: Add a custom context menu item
            // zg1.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            // OPTIONAL: Handle the Zoom Event
            zg1.ZoomEvent += new ZedGraphControl.ZoomEventHandler(MyZoomEvent);

            // Size the control to fit the window
            // SetSize();

            // Tell ZedGraph to calculate the axis ranges
            // Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            // up the proper scrolling parameters
            zg1.AxisChange();
            // Make sure the Graph gets redrawn
            zg1.Invalidate();
        }

        /// <summary>
        /// Display customized tooltips when the mouse hovers over a point
        /// </summary>
        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane,
                        CurveItem curve, int iPt)
        {
            // Get the PointPair that is under the mouse
            PointPair pt = curve[iPt];

            return curve.Label.Text + " is at price " + pt.Y.ToString("f2") + " when " + pt.X.ToString("f1") + " days";
        }

        /// <summary>
        /// Customize the context menu by adding a new item to the end of the menu
        /// </summary>
        private void MyContextMenuBuilder(ZedGraphControl control, ContextMenuStrip menuStrip,
                        Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Name = "add-beta";
            item.Tag = "add-beta";
            item.Text = "Add a new Beta Point";
            item.Click += new System.EventHandler(AddBetaPoint);

            menuStrip.Items.Add(item);
        }

        /// <summary>
        /// Handle the "Add New Beta Point" context menu item.  This finds the curve with
        /// the CurveItem.Label = "Beta", and adds a new point to it.
        /// </summary>
        private void AddBetaPoint(object sender, EventArgs args)
        {
            // Get a reference to the "Beta" curve IPointListEdit
            IPointListEdit ip = zg1.GraphPane.CurveList["Beta"].Points as IPointListEdit;
            if (ip != null)
            {
                double x = ip.Count * 5.0;
                double y = Math.Sin(ip.Count * Math.PI / 15.0) * 16.0 * 13.5;
                ip.Add(x, y);
                zg1.AxisChange();
                zg1.Refresh();
            }
        }

        // Respond to a Zoom Event
        private void MyZoomEvent(ZedGraphControl control, ZoomState oldState,
                    ZoomState newState)
        {
            // Here we get notification everytime the user zooms
        }
    }
}
