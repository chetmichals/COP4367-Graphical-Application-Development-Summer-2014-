using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing_Demo
{
    public class FinDataSet
    {
        List<FinDailyData> dataSet = new List<FinDailyData>();
        
        public FinDataSet()
        {
        }

        
        public int dayCount
        {
            get { return dataSet.Count ; }
        }
        public DateTime lastDay
        {
            get { return dataSet[dataSet.Count-1].date; }
        }

        public DateTime firstDay
        {
            get { return dataSet[0].date; }
        }



        public double dayHigh (int i)
        {
            return dataSet[i].hi;
        }

        public double dayLow(int i)
        {
            return dataSet[i].lo;
        }

        public DateTime getDay(int i)
        {
            return dataSet[i].date;
        }

        public double getClose(int i)
        {
            return dataSet[i].close;
        }

        public float maxPrice
        {
            get
            {
                double maxprice = 0;
                for (int i = 0; i < dataSet.Count; i++)
                {
                    if (dataSet[i].hi > maxprice)
                    {
                        maxprice = dataSet[i].hi;
                    }

                }
                maxprice = Math.Ceiling(maxprice * 1.05);
                return (float)maxprice;
            }
        }

        public float minPrice
        {
            get
            {
                double minPrice = this.maxPrice;
                for (int i = 0; i < dataSet.Count; i++)
                {
                    if (dataSet[i].lo < minPrice)
                    {
                        minPrice = dataSet[i].lo;
                    }

                }
                minPrice = Math.Floor(minPrice / 1.05);
                return (float)minPrice;
            }
        }

        public void draw(Graphics g, int drawType, float yScale)
        {
            if (drawType == 1)
            { 
                for (int i = 0; i < dataSet.Count; i++)
                {
                    dataSet[i].draw(g, i);
                }
            }
            else if (drawType == 2)
            {
                for (int i = 0; i < dataSet.Count; i++)
                {
                    dataSet[i].draw2(g, i,yScale);
                }
            }
            else //Drawtype == 3 
            {
                for (int i = 1; i < dataSet.Count; i++)
                {
                    Pen pen = new Pen(Color.Black, (float)Math.Log10(yScale)/20);
                    g.DrawLine(pen, (float)(i - 1), (float)dataSet[i - 1].close, (float)i, (float)dataSet[i].close);
                }
            }
        }


        public void readFromFile(string fileName)
        {
            dataSet.Clear();
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(fileName);
            file.ReadLine(); 
            line = file.ReadLine();
            while (line != null)
            {
                // put what you are going do with each line
                FinDailyData fdd = new FinDailyData();
                fdd.getFromString(line);
                line = file.ReadLine();
                dataSet.Add(fdd);
            }
            dataSet.Reverse();
            file.Close();

        }

    }
}
