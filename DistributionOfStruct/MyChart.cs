using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public MyChart(Chart chart)
        {
            SeriesOne = chart.Series[0];
            AxisX = chart.ChartAreas[0].AxisX;
            AxisY = chart.ChartAreas[0].AxisY;
            CursorX = chart.ChartAreas[0].CursorX;
            CursorY = chart.ChartAreas[0].CursorY;

            chart.MouseClick += ChartOnMouseClick;
            chart.MouseDown += ChartOnMouseDown;
            chart.MouseMove += ChartOnMouseMove;

            CursorX.IsUserSelectionEnabled = true;
            CursorY.IsUserSelectionEnabled = true;

            //SeriesOne.ChartType = SeriesChartType.StepLine;
            DigitsX = 0;
            DigitsY = 2;

            //Test
            //for (int i = 1; i <500; i++) SeriesOne.Points.AddXY(i,180*Math.Sin(i*Math.PI/180));
        }

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
