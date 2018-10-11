using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Cursor = System.Windows.Forms.DataVisualization.Charting.Cursor;

namespace DistributionOfStruct
{
    public struct PointD
    {
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }

    /// <summary>
    /// Класс управления графиком
    /// <para>Левая кнопка мыши - выделить и увеличить область</para> 
    /// <para>Средняя кнопка мыши - отменить последнее масштабирование</para> 
    /// <para>Средняя кнопка мыши с нажатым Ctrl - сбросить масштаб</para> 
    /// <para>Правая кнопка мыши - перетащить график</para>
    /// </summary> 

    public class MyChart
    {
        private Series SeriesOne { get; }
        private Axis AxisX { get; }
        private Axis AxisY { get;  }
        private Cursor CursorX { get;  }
        private Cursor CursorY { get;  }

        private bool IsChartScroll { get; set; }
        private PointD StartMousePosition { get; set; }

        private readonly Chart _chart;

        public MyChart(Chart chart)
        {
            _chart = chart;
            SeriesOne = chart.Series[0];
            AxisX = chart.ChartAreas[0].AxisX;
            AxisY = chart.ChartAreas[0].AxisY;
            CursorX = chart.ChartAreas[0].CursorX;
            CursorY = chart.ChartAreas[0].CursorY;

            chart.MouseClick += ChartOnMouseClick;
            chart.MouseDown += ChartOnMouseDown;
            chart.MouseMove += ChartOnMouseMove;
           // chart.MouseHover += ChartOnMouseHover;
            

            CursorX.IsUserSelectionEnabled = true;
            CursorY.IsUserSelectionEnabled = true;

            AxisX.IsStartedFromZero = false;

            //SeriesOne.ChartType = SeriesChartType.StepLine;
            DigitsX = 0;
            DigitsY = 1;
          

         //   chart.SaveImage("x",ChartImageFormat.Emf);
           
           // var dp = new DataPoint() { };
           // dp.ToolTip
           //Test
           // for (int i = 1; i <500; i++) SeriesOne.Points.AddXY(i,180*Math.Sin(i*Math.PI/180));
        }

        private void ChartOnMouseHover(object sender, EventArgs e)
        {
            var chart = sender as Chart;
            if (chart == null) return;
            
                var results = chart.HitTest(
                    System.Windows.Forms.Cursor.Position.X,
                    System.Windows.Forms.Cursor.Position.Y, 
                    true,
                    ChartElementType.DataPoint);

            if (results.Any())
            {
                var result = results[0];
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        ToolTip tt = new ToolTip();
                        tt.Show(prop.ToolTip, chart,
                            System.Windows.Forms.Cursor.Position.X,
                            System.Windows.Forms.Cursor.Position.Y-15);
                    }
                }
            }

        }

        public bool IsPublication
        {
            set
            {
                AxisX.MajorGrid.Enabled = !value;
                AxisY.MajorGrid.Enabled = !value;

                AxisX.ScrollBar.Enabled = !value;
                AxisY.ScrollBar.Enabled = !value;

                AxisX.IsLabelAutoFit = !value;
                AxisY.IsLabelAutoFit = !value;

                if (value)
                {
                    var xInterval = (AxisX.ScaleView.ViewMaximum - AxisX.ScaleView.ViewMinimum) / 2;
                    AxisX.Interval = Math.Round(xInterval, DigitsX);
                    var yInterval = (AxisY.ScaleView.ViewMaximum - AxisY.ScaleView.ViewMinimum) / 2;
                    AxisY.Interval = Math.Round(yInterval, DigitsY);

                    AxisX.MajorTickMark.LineColor = Color.Transparent;
                    AxisY.MajorTickMark.LineColor = Color.Transparent;

                    AxisX.MajorTickMark.Size = 2;
                    AxisY.MajorTickMark.Size = 2;

                    AxisX.LabelStyle.Font = new Font("Times New Roman", 10);
                    AxisY.LabelStyle.Font = new Font("Times New Roman", 10);



                   
                }
                else
                {
                   // AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
                   // AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;

                    AxisX.MajorTickMark.LineColor = Color.Black;
                    AxisY.MajorTickMark.LineColor = Color.Black;

                    AxisX.MajorTickMark.Size = 1;
                    AxisY.MajorTickMark.Size = 1;

                    AxisX.Interval = 0;
                    AxisY.Interval = 0;
                }
            }
        }


        public SeriesChartType SeriesType
        {
            get { return SeriesOne.ChartType; }
            set { SeriesOne.ChartType = value; }
        }


        public DataPointCollection SeriesDataPoints => SeriesOne.Points;


        /// <summary>
        /// Коллекция точек данных
        /// </summary>
        public IEnumerable<double> SeriesPoints
        {
            set
            {
                var i = 0;
                SeriesOne.Points.Clear();
                foreach (var val in value) SeriesOne.Points.AddXY(++i, val); 
            }
        }


        private int _digitsX;
        /// <summary>
        /// Количество дробных разрядов по оси X, диапазон значений от 0 до 15
        /// </summary>
        public int DigitsX
        {
            get { return _digitsX; }
            set
            {
                _digitsX = value;
                CursorX.Interval = Math.Pow(10, -value);
                AxisX.LabelStyle.Format = $"F{value}";
            }
        } 

        private int _digitsY;
        /// <summary>
        /// Количество дробных разрядов по оси Y, диапазон значений от 0 до 15
        /// </summary>
        public int DigitsY
        {
            get { return _digitsY; }
            set
            {
                _digitsY = value;
                CursorY.Interval = Math.Pow(10, -value);
                AxisY.LabelStyle.Format = $"F{value}";
            }
        }

        private void ChartOnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle) return;
            var n = Control.ModifierKeys == Keys.Control ? 0 : 1;
            AxisX.ScaleView.ZoomReset(n);
            AxisY.ScaleView.ZoomReset(n);
        }

        private void ChartOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            try
            {
                StartMousePosition = new PointD(
                    AxisX.PixelPositionToValue(e.X),
                    AxisY.PixelPositionToValue(e.Y));
                IsChartScroll = true;
            }
            catch (ArgumentException)
            {
                IsChartScroll = false;
            }
        }
        
        private void ChartOnMouseMove(object sender, MouseEventArgs e)
        {
            if (IsChartScroll && e.Button == MouseButtons.Right)
            {
                try
                {
                    var x = AxisX.ScaleView.Position + StartMousePosition.X - AxisX.PixelPositionToValue(e.X);
                    var y = AxisY.ScaleView.Position + StartMousePosition.Y - AxisY.PixelPositionToValue(e.Y);
                    x = Math.Round(x, DigitsX); //0..15
                    y = Math.Round(y, DigitsY);
                    AxisX.ScaleView.Scroll(x);
                    AxisY.ScaleView.Scroll(y);   
                }
                catch (ArgumentException)
                {
                   
                }
            }
            else IsChartScroll = false;
        }
    }
}
