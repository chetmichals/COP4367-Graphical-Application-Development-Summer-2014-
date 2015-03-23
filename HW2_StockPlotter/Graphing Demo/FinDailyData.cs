using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing_Demo
{
    public class FinDailyData
    {
        public double hi { get; set; }
        public double lo { get; set; }
        public double open { get; set; }
        public double close { get; set; }
        public DateTime date { get; set; }





        //public double hi
        //{
        //    get { return _hi; }
        //    set { _hi = value ;  }
        //}

        //private double _hi;


        public void draw(Graphics g,float dayIndex)
        {
            Pen pen = new Pen(Color.Black,0.2f);
            g.DrawLine(pen, dayIndex, (float)hi, dayIndex, (float)lo);
            if (open < close)
            {
                g.FillRectangle(Brushes.Green, dayIndex - 0.3f, (float)open, 0.6f, (float)(close - open));
            }
            else
            {
                g.FillRectangle(Brushes.Red, dayIndex - 0.3f, (float)close, 0.6f, (float)(open - close));
            }
        }

        public void draw2(Graphics g, float dayIndex, float yScale)
        {
            Pen pen = new Pen(Color.Black, (float)Math.Log10(yScale)/20);
            g.DrawLine(pen, dayIndex, (float)hi, dayIndex, (float)lo);
            g.DrawLine(pen, dayIndex, (float)open, dayIndex - .4f, (float)open);
            g.DrawLine(pen, dayIndex, (float)close, dayIndex + .4f, (float)close);
           
        }


        internal void getFromString(string line)
        {
            String[] x = line.Split(',');
            date = Convert.ToDateTime(x[0]);
            open = Convert.ToDouble(x[1]);
            hi = Convert.ToDouble(x[2]);
            lo = Convert.ToDouble(x[3]);
            close = Convert.ToDouble(x[4]);
        }
    }
}
