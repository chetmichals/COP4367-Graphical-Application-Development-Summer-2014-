using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphing_Demo
{
    public partial class GraphForm : Form
    {
        Random random = new Random();

        public FinDataSet finDataSet = new FinDataSet();

        public GraphControlForm graphControlForm
        {
            set{_graphControlForm=value;}
            get{return _graphControlForm;}
        }

    
        GraphControlForm _graphControlForm;
        public GraphForm()
        {
            InitializeComponent();
            for (int i = 0; i < 50; i++)
            {
                polyPoints.Add(randPointF(100, 200, 200, 300));
            }
            FinDataSet fds = new FinDataSet();
        }


        Pen lightGrayPen = new Pen(Color.LightGray, 0.05f);
        Pen grayPen = new Pen(Color.Gray, 0.1f);
        Pen blackPen = new Pen(Color.Black, 1f);
        Pen redPen = new Pen(Color.Red, 1f);
        Font arialFont = new Font("Arial", 10);
        Font tnrFont = new Font("Times New Roman", 10);
        Font tnrFont20 = new Font("Times New Roman", 20);
        Matrix identityMatrix = new Matrix();

        PointF origin = new PointF();

        List<PointF> polyPoints = new List<PointF>();


        private void GraphForm_Paint(object sender, PaintEventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            SetGraphingTransform(e);

            drawGrid(e.Graphics);

            //drawAxes(e);

            finDataSet.draw(e.Graphics, graphControlForm.drawType,(graphControlForm.maxY - graphControlForm.minY));
            drawMovingAverage(e.Graphics, (graphControlForm.maxY - graphControlForm.minY));
           
            clearMargine(e.Graphics);
            e.Graphics.Transform = identityMatrix;
            drawIndex(e.Graphics);
            clearMargine2(e.Graphics);
            drawDays(e.Graphics);
            
            e.Graphics.Transform = tTransform.matrix;
            this.Cursor = currentCursor;
        }

        private void drawMovingAverage(Graphics graphics, float yScale)
        {
            if (finDataSet.dayCount == 0) return;
            if(graphControlForm.movingAverage == true)
            {
                double averageValue = 0;
                double yesterdayAverageValue = 0;
                for (int i = (int)Math.Floor(graphControlForm.minX); i <= (int)Math.Ceiling(graphControlForm.maxX); i++)
                {
                    int dayCounter = 0;
                    averageValue = 0;
                    for (int j = graphControlForm.averageDay; j >= 0; j--)
                    {
                        if ((i - j) >= 0)
                        {
                            averageValue += finDataSet.getClose(i - j);
                            dayCounter++;
                        }
                    }
                    averageValue /= dayCounter;
                    if (i != (int)Math.Floor(graphControlForm.minX))
                    {
                        Pen pen = new Pen(Color.Red, (float)Math.Log10(yScale) / 20);
                        graphics.DrawLine(pen, (float)(i - 1), (float)yesterdayAverageValue, (float)i, (float)averageValue);
                    }
                    yesterdayAverageValue = averageValue;
                }
            }
        }



        public PointF randPointF(float minX, float maxX, float minY, float maxY)
        {
            return new PointF(randFloat(minX, maxX), randFloat(minY,maxY));
        }


        public float randFloat()
        {
            return (float)random.NextDouble();
        }

        public float randFloat(float max)
        {
            return randFloat() * max;
        }

        public float randFloat(float min,float max)
        {
            return randFloat(max-min) + min;
        }


        private void drawCircle(Graphics g, Pen pen, PointF center, float radius)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2f, radius * 2f);
        }

        private PointF markPoint(Graphics g, PointF pf, float size=10f)
        {
            g.DrawLine(blackPen, pf.X - (size / 2f), pf.Y, pf.X + (size / 2f), pf.Y);
            g.DrawLine(blackPen, pf.X, pf.Y - (size / 2f), pf.X, pf.Y + (size / 2f));
            g.DrawEllipse(blackPen, pf.X - (size / 4f), pf.Y - (size / 4f), (size / 2f), (size / 2f));
            return pf;
        }

        private void drawGrid(Graphics g)
        {

            if (graphControlForm.showGrid)
            {

                float xInc = (float)Math.Pow(10.0, Math.Floor(Math.Log10(tTransform.xRange)) - 1);

                for (float x = 0f; x > tTransform.X1; x -= xInc)
                {
                    g.DrawLine(lightGrayPen, x, tTransform.Y1, x, tTransform.Y2);
                }

                for (float x = 0f; x < tTransform.X2; x += xInc)
                {
                    g.DrawLine(lightGrayPen, x, tTransform.Y1, x, tTransform.Y2);
                }
                float yInc = (float)Math.Pow(10.0, Math.Floor(Math.Log10(tTransform.yRange)) - 1);

                for (float y = 0f; y < tTransform.Y1; y += yInc)
                {
                    g.DrawLine(lightGrayPen, tTransform.X1, y, tTransform.X2, y);
                }

                for (float y = 0f; y > tTransform.Y2; y -= yInc)
                {
                    g.DrawLine(lightGrayPen, tTransform.X1, y, tTransform.X2, y);
                }

                xInc = (float)Math.Pow(10.0, Math.Floor(Math.Log10(tTransform.xRange)) );

                for (float x = 0f; x > tTransform.X1; x -= xInc)
                {
                    g.DrawLine(grayPen, x, tTransform.Y1, x, tTransform.Y2);
                }

                for (float x = 0f; x < tTransform.X2; x += xInc)
                {
                    g.DrawLine(grayPen, x, tTransform.Y1, x, tTransform.Y2);
                }
                yInc = (float)Math.Pow(10.0, Math.Floor(Math.Log10(tTransform.yRange)));

                for (float y = 0f; y < tTransform.Y1; y += yInc)
                {
                    g.DrawLine(grayPen, tTransform.X1, y, tTransform.X2, y);
                }

                for (float y = 0f; y > tTransform.Y2; y -= yInc)
                {
                    g.DrawLine(grayPen, tTransform.X1, y, tTransform.X2, y);
                }
            }
        }

        private void drawAxes(PaintEventArgs e)
        {
            if (graphControlForm.showAxes)
            {
                e.Graphics.DrawLine(blackPen, 0f, graphControlForm.maxY, 0f, graphControlForm.minY);
                e.Graphics.DrawLine(blackPen, graphControlForm.maxX, 0f, graphControlForm.minX, 0f);
            }
        }

        T_Transform tTransform = new T_Transform();
        
        private void SetGraphingTransform(PaintEventArgs e)
        {
            Rectangle winRect = this.ClientRectangle;
            Rectangle subWinRect = winRect;

            float u1 = subWinRect.X;
            float v1 = subWinRect.Y;
            float u2 = subWinRect.X + subWinRect.Width;
            float v2 = subWinRect.Y + subWinRect.Height;

            float x1 = graphControlForm.minX;
            float y1 = graphControlForm.maxY;
            float x2 = graphControlForm.maxX;
            float y2 = graphControlForm.minY;

            tTransform.setupBoundries(u1, v1, u2, v2, x1, y1, x2, y2);
            tTransform.setupMatrix(graphControlForm.aspectRatio);


            e.Graphics.Transform = tTransform.matrix;
        }

        private void GraphForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public bool alreadyClosing = false;

        private void GraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            alreadyClosing = true;
            if (!graphControlForm.alreadyClosing)
            {
                graphControlForm.Close();
            }
        }


        List<PointF> markPoints = new List<PointF>();

        private void GraphForm_MouseClick(object sender, MouseEventArgs e)
        {
            //int mouseX = e.X;
            //int mouseY = e.Y;
            //markPoints.Add(tTransform.convertToXY(mouseX, mouseY));
            //Invalidate();


        }

        private void drawIndex(Graphics g)
        {
            Rectangle winRect = this.ClientRectangle;
            Rectangle subWinRect = winRect;
            float xOffset = tTransform.X1 - (tTransform.X2 - tTransform.X1) / 10;
            float fontsize = subWinRect.Width / 60f;
            float smallFont= subWinRect.Width / 100f;
            Font numberFont = new Font("Arial", fontsize);
            Font smallnumberFont = new Font("Arial", smallFont);
            if (tTransform.yRange > 2000)
            {
                for (int i = 1000; i < tTransform.Y1; i+= 1000)
                {
                    PointF pointLocation = new PointF(xOffset, i + 6.0f);
                    g.DrawString("$" + Convert.ToString(i) + ".00", numberFont, Brushes.DarkBlue, tTransform.convertToUV(pointLocation));
                }
            }
            else if (tTransform.yRange > 200)
            {
                for (int i = 100; i < tTransform.Y1; i += 100)
                {
                    PointF pointLocation = new PointF(xOffset, i + 6f);
                    g.DrawString("$" + Convert.ToString(i) + ".00", numberFont, Brushes.DarkBlue, tTransform.convertToUV(pointLocation));
                }

            }
            else if (tTransform.yRange > 20)
            {
                for (int i = 10; i < tTransform.Y1; i += 10)
                {
                    PointF pointLocation = new PointF(xOffset, i + .60f);
                    g.DrawString("$" + Convert.ToString(i) + ".00", numberFont, Brushes.DarkBlue, tTransform.convertToUV(pointLocation));
                }
            }
            else if (tTransform.yRange > 2)
            {
                for (int i = 1; i < tTransform.Y1; i += 1)
                {
                    PointF pointLocation = new PointF(xOffset, i + .060f);
                    g.DrawString("$" + Convert.ToString(i) + ".00", numberFont, Brushes.DarkBlue, tTransform.convertToUV(pointLocation));
                }
            }
            else
            {
                for (float i = .1f; i < tTransform.Y1; i += .1f)
                {
                    PointF pointLocation = new PointF(xOffset, i + .006f);
                    if ((int)(Math.Round(i, 2) * 10) % 10 == 0)
                    {
                        g.DrawString("$" + Convert.ToString(Math.Round(i, 2)) + ".00", numberFont, Brushes.DarkBlue, tTransform.convertToUV(pointLocation));
                    }
                    else
                    {
                        g.DrawString("$" + Convert.ToString(Math.Round(i, 2)) + "0", numberFont, Brushes.DarkBlue, tTransform.convertToUV(pointLocation));
                    }
                    
                }
            }

            //for (int i = 1; i < 10; i++)
            //{
            //    Font numberFont = new Font("Arial", fontsize);
            //    PointF pointLocation = new PointF(xOffset, i * 100 + 6);
            //    g.DrawString("$" + Convert.ToString(i * 100) + ".00", numberFont, Brushes.DarkBlue, tTransform.convertToUV(pointLocation));
                
            //}
        }

        private void drawDays(Graphics g)
        {
            //break if a graph hasn't been loaded
            if (finDataSet.dayCount == 0) return;

            //Sets up text to be draw to correct part of screen
            Rectangle winRect = this.ClientRectangle;
            Rectangle subWinRect = winRect;
            float xOffset = tTransform.X1 - (tTransform.X2 - tTransform.X1) / 10;
            float fontsize = subWinRect.Width / 80f;           
            Font numberFont = new Font("Arial", fontsize);

            //Sets up text to be drawn virtically
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            string drawString = "Sample Text";

            if (tTransform.xRange < 15)
            {
                for (float i = tTransform.X1; i < tTransform.X2 + 1; i++)
                {
                    drawString = finDataSet.getDay((int)i).Month.ToString() + "/" + finDataSet.getDay((int)i).Day.ToString() + "/" + finDataSet.getDay((int)i).Year.ToString().Substring(2);
                    PointF pointLocation = new PointF(i, tTransform.Y2);
                    g.DrawString(drawString, numberFont, drawBrush, tTransform.convertToUV(pointLocation), drawFormat);
                }
            }
            else if (tTransform.xRange < 31)
            {
                for (float i = tTransform.X1 + 1; i < tTransform.X2 +1; i+=5)
                {
                    drawString = finDataSet.getDay((int)i).Month.ToString() + "/" + finDataSet.getDay((int)i).Day.ToString() + "/" + finDataSet.getDay((int)i).Year.ToString().Substring(2);
                    PointF pointLocation = new PointF(i+.5f, tTransform.Y2);
                    g.DrawString(drawString, numberFont, drawBrush, tTransform.convertToUV(pointLocation), drawFormat);
                }
            }
            else if (tTransform.xRange < 300)
            {
                for (float i = tTransform.X1; i < tTransform.X2; i += 21)
                {
                    drawString = finDataSet.getDay((int)i).Month.ToString() + "/" + finDataSet.getDay((int)i).Year.ToString().Substring(2);
                    PointF pointLocation = new PointF(i + .5f, tTransform.Y2);
                    g.DrawString(drawString, numberFont, drawBrush, tTransform.convertToUV(pointLocation), drawFormat);
                }
            }
            else
            {
                int multipler = (int)Math.Ceiling((tTransform.X2-tTransform.X1) / 800f);
                for (float i = tTransform.X1; i < tTransform.X2; i += 21 * multipler)
                {
                    drawString = finDataSet.getDay((int)i).Month.ToString() + "/" + finDataSet.getDay((int)i).Year.ToString().Substring(2);
                    PointF pointLocation = new PointF(i + .5f, tTransform.Y2);
                    g.DrawString(drawString, numberFont, drawBrush, tTransform.convertToUV(pointLocation), drawFormat);
                }
            }
        }
        
        private void clearMargine(Graphics g)
        {
            g.FillRectangle(Brushes.White, 0, 0, graphControlForm.minX, graphControlForm.maxY);

        }

        private void clearMargine2(Graphics g)
        {
            

            PointF pointLocation = new PointF(-(graphControlForm.maxX - graphControlForm.minX), graphControlForm.minY);
            PointF pointLocation2 = new PointF(graphControlForm.maxX*2, -graphControlForm.maxY);

            pointLocation = tTransform.convertToUV(pointLocation);
            pointLocation2 = tTransform.convertToUV(pointLocation2);

            RectangleF rect = new RectangleF(pointLocation.X, pointLocation.Y, pointLocation2.X - pointLocation.X, pointLocation2.Y - pointLocation.Y);
            g.FillRectangle(Brushes.White, rect);
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {

        }
    }
}
