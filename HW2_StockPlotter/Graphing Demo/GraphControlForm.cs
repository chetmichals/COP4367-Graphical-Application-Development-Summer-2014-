using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphing_Demo
{
    public partial class GraphControlForm : Form
    {
        public bool showGrid
        {
            get { return checkBoxGridLines.Checked; }
        }
        public bool showAxes
        {
            get { return false; }
        }
        public bool aspectRatio
        {
            get { return false; }
        }
        public bool movingAverage
        {
            get { return movingAverageBox.Checked; }
        }

        public int averageDay
        {
            get
            {
                if (average10.Checked == true)
                {
                    return 10;
                }
                else if (average30.Checked == true)
                {
                    return 30;
                }
                else
                {
                    int temp = Convert.ToInt32(averageDayCustom.Text);
                    if (temp <= 0) temp = 1;
                    return temp;
                }
            }
        }

        public float minX
        {
            get { return Convert.ToSingle(textBoxMinX.Text); }
            set { textBoxMinX.Text = Convert.ToString(value); }
        }
        public float maxX
        {
            get { return (float)Convert.ToDouble(textBoxMaxX.Text); }
            set { textBoxMaxX.Text = Convert.ToString(value); }
        }
        public float minY
        {
            get { return (float)Convert.ToDouble(textBoxMinY.Text); }
            set
            {
                if (value == 0) value = 1;
                textBoxMinY.Text = Convert.ToString(value); 
            }
        }
        public float maxY
        {
            get { return (float)Convert.ToDouble(textBoxMaxY.Text); }
            set { textBoxMaxY.Text = Convert.ToString(value); }
        }

        public float graphPenWidth
        {
            get { return (float)numericUpDownGraphPenWidth.Value; }
        }

        public RectangleF worldRectF
        {
            
            get 
            {
                return new RectangleF(minX,minY,maxX-minX,maxY-minY); 
            }
        }

        public int drawType
        {
            get
            {
                if (drawOption1.Checked)
                {
                    return 1;
                }
                else if (drawOption2.Checked)
                {
                    return 2;
                }
                else //Drawoption 3
                {
                    return 3;
                }
            }
        }


        public GraphForm graphForm
        {
            set { _graphForm = value; }
            get { return _graphForm; }
        }

        GraphForm _graphForm;

        public GraphControlForm()
        {
            InitializeComponent();
        }

        public bool alreadyClosing = false;

        private void GraphControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            alreadyClosing = true;
            if (!graphForm.alreadyClosing)
            {
                graphForm.Close();
            }
        }

        private void invalidaateGraphForm(object sender, EventArgs e)
        {
            if (maxX < minX) { maxX = minX + 1; }
            if (maxY < minY) { maxY = minY + 1; }
            graphForm.Invalidate();
        }

        private void buttonGetFile_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.DefaultExt = "csv";
            fd.Filter = "(*.csv)|*.csv|All files (*.*)|*.*";
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                graphForm.finDataSet.readFromFile(fd.FileName);
                minDateTimePicker1.Value = graphForm.finDataSet.firstDay;
                maxDateTimePicker.Value = graphForm.finDataSet.lastDay;
                minX = 0;
                maxX = graphForm.finDataSet.dayCount-1;
                minY = graphForm.finDataSet.minPrice;
                maxY = graphForm.finDataSet.maxPrice;
                int startName = fd.FileName.LastIndexOf(@"\");
                string windowName = fd.FileName.Substring(startName+1);
                graphForm.Text = windowName;
                this.Text = windowName + " Control Form";
            }
            graphForm.Invalidate();
        }




        private void maxDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(graphForm.finDataSet.dayCount != 0)
            {
                int counter = 0;
                for (int i = 0; i < graphForm.finDataSet.dayCount; i++)
                {
                    if (graphForm.finDataSet.getDay(i) <= maxDateTimePicker.Value) counter = i;
                }
                maxX = counter;
                if (maxX <= minX) maxX = minX + 1;
                graphForm.Invalidate();
            }
        }

        private void minDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (graphForm.finDataSet.dayCount != 0)
            {
                int counter = 0;
                for (int i = 0; i < graphForm.finDataSet.dayCount; i++)
                {
                    if (graphForm.finDataSet.getDay(i) <= minDateTimePicker1.Value) counter = i;
                }
                minX = counter;
                if (minX >= graphForm.finDataSet.dayCount -1)
                {
                    minX = graphForm.finDataSet.dayCount - 2;
                    maxX = minX + 1;
                }

                graphForm.Invalidate();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void Last30Days_Click(object sender, EventArgs e)
        {
            ChangeDays(30);
            
        }

        private void ChangeDays(int dayCount)
        {
            if (graphForm.finDataSet.dayCount < 1) return;
            maxX = graphForm.finDataSet.dayCount - 1;
            minX = maxX - dayCount;

            minDateTimePicker1.Value = graphForm.finDataSet.getDay((int)minX);
            maxDateTimePicker.Value = graphForm.finDataSet.getDay((int)maxX);

            double low = graphForm.finDataSet.dayLow((int)maxX);
            double high = graphForm.finDataSet.dayHigh((int)maxX);
            for (int i = (int)maxX; i > (int)maxX - dayCount; i--)
            {
                if (graphForm.finDataSet.dayLow(i) < low) low = graphForm.finDataSet.dayLow(i);
                if (graphForm.finDataSet.dayHigh(i) > high) high = graphForm.finDataSet.dayHigh(i);
            }

            //Add a small buff to the top and bottom, the floor/cealing it
            float buffer = (float)(high - low) / 20;
            maxY = (float)Math.Ceiling(high + buffer);
            minY = (float)Math.Floor(low - buffer);
            graphForm.Invalidate();
        }


        private void GraphControlForm_Load(object sender, EventArgs e)
        {
            this.Left = graphForm.Right;
            this.Top = graphForm.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeDays(10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeDays(120);
        }

        private void movingAverageBox_CheckedChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void drawOption2_CheckedChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void drawOption3_CheckedChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void averageC_CheckedChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void average30_CheckedChanged(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (graphForm.finDataSet.dayCount < 1) return;

            minDateTimePicker1.Value = graphForm.finDataSet.getDay((int)minX);
            maxDateTimePicker.Value = graphForm.finDataSet.getDay((int)maxX);

            double low = graphForm.finDataSet.dayLow((int)maxX);
            double high = graphForm.finDataSet.dayHigh((int)maxX);

            for (int i = (int)maxX; i > (int)minX; i--)
            {
                if (graphForm.finDataSet.dayLow(i) < low) low = graphForm.finDataSet.dayLow(i);
                if (graphForm.finDataSet.dayHigh(i) > high) high = graphForm.finDataSet.dayHigh(i);
            }

            //Add a small buff to the top and bottom, the floor/cealing it
            float buffer = (float)(high - low) / 20;
            maxY = (float)Math.Ceiling(high + buffer);
            minY = (float)Math.Floor(low - buffer);
            graphForm.Invalidate();
        }

        private void quickBack_Click(object sender, EventArgs e)
        {
            int dayDiff = 30;
            if (graphForm.finDataSet.dayCount < 31) return;
            maxX = maxX - dayDiff;
            minX = minX - dayDiff;

            if (minX < 0 ) minX = 0;
            if (minX >= maxX) maxX = maxX + 1;

            minDateTimePicker1.Value = graphForm.finDataSet.getDay((int)minX);
            maxDateTimePicker.Value = graphForm.finDataSet.getDay((int)maxX);

            double low = graphForm.finDataSet.dayLow((int)maxX);
            double high = graphForm.finDataSet.dayHigh((int)maxX);
            for (int i = (int)maxX; i > (int)minX; i--)
            {
                if (graphForm.finDataSet.dayLow(i) < low) low = graphForm.finDataSet.dayLow(i);
                if (graphForm.finDataSet.dayHigh(i) > high) high = graphForm.finDataSet.dayHigh(i);
            }

            //Add a small buff to the top and bottom, the floor/cealing it
            float buffer = (float)(high - low) / 20;
            maxY = (float)Math.Ceiling(high + buffer);
            minY = (float)Math.Floor(low - buffer);
            graphForm.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int dayDiff = 30;
            if (graphForm.finDataSet.dayCount < 31) return;
            maxX = maxX + dayDiff;
            minX = minX + dayDiff;

            if (maxX > graphForm.finDataSet.dayCount) maxX = graphForm.finDataSet.dayCount - 1;
            if (minX >= maxX) minX = maxX - 1;


            minDateTimePicker1.Value = graphForm.finDataSet.getDay((int)minX);
            maxDateTimePicker.Value = graphForm.finDataSet.getDay((int)maxX);

            double low = graphForm.finDataSet.dayLow((int)maxX);
            double high = graphForm.finDataSet.dayHigh((int)maxX);
            for (int i = (int)maxX; i > minX; i--)
            {
                if (graphForm.finDataSet.dayLow(i) < low) low = graphForm.finDataSet.dayLow(i);
                if (graphForm.finDataSet.dayHigh(i) > high) high = graphForm.finDataSet.dayHigh(i);
            }

            //Add a small buff to the top and bottom, the floor/cealing it
            float buffer = (float)(high - low) / 20;
            maxY = (float)Math.Ceiling(high + buffer);
            minY = (float)Math.Floor(low - buffer);
            graphForm.Invalidate();
        }

        private void textBoxMaxY_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
