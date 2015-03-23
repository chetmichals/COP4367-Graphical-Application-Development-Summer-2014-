using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing_Demo
{
    class T_Transform
    {
        float u1,v1;
        float u2,v2;
        float x1,y1;
        float x2,y2;

        float scaleX;
        float scaleY;

        float shiftX;
        float shiftY;

        public Matrix matrix
        {
            get { return _transformMatrix; }
            set { _transformMatrix = value; }
        }


        private Matrix _transformMatrix;

        public float xRange
        {
            get { return Math.Abs(x2 - x1); }
        }

        public float yRange
        {
            get { return Math.Abs(y2 - y1); }
        }


        public float X1
        {
            get { return x1; }
        }

        public float X2
        {
            get { return x2; }
        }

        public float Y1
        {
            get { return y1; }
        }

        public float Y2
        {
            get { return y2; }
        }

        public void setupBoundries(float U1, float V1, float U2, float V2, float X1, float Y1, float X2, float Y2)
        {
            u1 = U1;
            u2 = U2;
            v1 = V1;
            v2 = V2;

            x1 = X1;
            x2 = X2;
            y1 = Y1;
            y2 = Y2;
            if (y2 == y1) y2 = y1 + 1;
        }




        public PointF convertToUV(PointF pXY)
        {
            PointF pUV = new PointF();
            pUV.X = (pXY.X + shiftX) * scaleX;
            pUV.Y = (pXY.Y + shiftY) * scaleY;
            return pUV;
        }


        public PointF convertToUV(float x,float y)
        {
            return convertToUV(new PointF(x, y));
        }


        public void setupMatrix(bool aspectRatioLock)
        {

            _transformMatrix = new Matrix();

            scaleX = (u2 - u1) / (x2 - x1);
            scaleY = (v2 - v1) / (y2 - y1);

            float oldscaleX = scaleX;
            scaleX *= .9f;
            scaleY *= .9f;

            float extraX = 0;
            float extraY = 0;

            if (aspectRatioLock)
            {
                extraX = 0;
                extraY = 0;
                if (Math.Abs(scaleX) < Math.Abs(scaleY))
                {
                    float oldRange = (v2 - v1) / scaleY;
                    scaleY = Math.Abs(scaleX) * Math.Sign(scaleY);
                    float newRange = (v2 - v1) / scaleY;
                    extraY = newRange - oldRange;
                }
                else
                {
                    float oldRange = (u2 - u1) / scaleX;
                    scaleX = Math.Abs(scaleY) * Math.Sign(scaleX);
                    float newRange = (u2 - u1) / scaleX;
                    extraX = newRange - oldRange;
                }
            }

            _transformMatrix.Scale(scaleX, scaleY);

            //shiftX = -x1 + (extraX / 2);
            shiftX = -x1 + (x2 - x1)/10;
            shiftY = -y1 + (extraY / 2);

            _transformMatrix.Translate(shiftX, shiftY);

        }


        public PointF convertToXY(PointF pUV)
        {
            PointF pXY = new PointF();
            pXY.X = (pUV.X / scaleX) - shiftX;
            pXY.Y = (pUV.Y / scaleY) - shiftY;
            return pXY;
        }


        internal PointF convertToXY(int u, int v)
        {
            return convertToXY(new PointF(u, v));
        }

        public void removeShift()
        {
            _transformMatrix.Translate(-x1, -y1);
        }
    }
}
