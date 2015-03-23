//*********************************************************
//
// (c) Copyright 2014 Dr. Thomas Fernandez
// 
// All rights reserved.
//
//*********************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTransducer
{
    class ArtEvaluator : EvaluatorForDoubles
    {

        static public BitmapImage targetBitmap;
        static public RenderTargetBitmap genBitmap=null;
        Random rand = new Random();

        byte[] targetPixelArray=null;
        byte[] genPixelArray=null;

        int pixelArrayStride;

        int sampleSize = 750;
        int XRes = 128;
        int YRes = 120;

        Canvas genCanvas = null;

        public ArtEvaluator()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            string filename = dlg.FileName;
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
            }
            targetBitmap = new BitmapImage(new Uri(filename, UriKind.Relative));

            GetByteArrayFromBitmap(targetBitmap,ref targetPixelArray);

            pixelArrayStride = targetBitmap.PixelWidth * 4;

        }

        public double evaluate(List<double> solution)
        {
            //GenotypeToPhenotype(solution);
            double fitness = FitnessFunction(solution);
            return fitness;
        }


        void getColorFromPixelArrayTarget(byte[] pixelArray, int x, int y, out byte r, out byte g, out byte b, out byte a)
        {
            double localX = x * (targetBitmap.Width / 128.0);
            double localY = y * (targetBitmap.Height / 120.0);
            int index = ((int)localY * 4 * (int)targetBitmap.Width) + (int)localX * 4;
            r = pixelArray[index];
            g = pixelArray[index + 1];
            b = pixelArray[index + 2];
            a = pixelArray[index + 3];
        }

        void getColorFromPixelArrayGen(List<double> solution, int x, int y, out byte r, out byte g, out byte b, out byte a)
        {
            int solutionNumber = (128 * y) + x + 50;
            int colorNumber = (int)(solution[solutionNumber]*64) % 64;
            Color NESColor = getNESColor(colorNumber);
            r = NESColor.R;
            b = NESColor.B;
            g = NESColor.G;
            a = 0;
        }


        private void GetByteArrayFromBitmap(BitmapSource b, ref byte[] bArray)
        {
            int size; 
            if (bArray == null)
            {
                pixelArrayStride = b.PixelWidth * 4;
                size = b.PixelHeight * pixelArrayStride;
                bArray = new byte[size];
            }
            b.CopyPixels(bArray, pixelArrayStride, 0);
        }


        static public double clamp(double v, double min, double max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }





        private double FitnessFunction(List<double> solution)
        {
            ////Convert the genCanvas to the genBitmap
            //ConvertFEtoRTB(genCanvas, ref genBitmap);
            ////Convert the genBitmap to the genPixelArray
            //GetByteArrayFromBitmap(genBitmap, ref genPixelArray);

            double fitness = 0.0;

            // acumualte the fitness from all the sample points
            for (int i = 0; i < sampleSize; i++)
            {
                // Get the random sample point
                int rx = rand.Next(0, XRes);
                int ry = rand.Next(0, YRes);

                //Target Color Values
                byte tRed;
                byte tGreen;
                byte tBlue;
                byte tAlpha;

                //Generated Color Values
                byte gRed;
                byte gGreen;
                byte gBlue;
                byte gAlpha;

                // Get the Target color values
                getColorFromPixelArrayTarget(targetPixelArray, rx, ry, out tRed, out tGreen, out tBlue, out tAlpha);

                //Get the Generated color values
                getColorFromPixelArrayGen(solution, rx, ry, out gRed, out gGreen, out gBlue, out gAlpha);

                //Ge the color differences
                double RedError = Math.Abs(tRed - gRed);
                double GreenError = Math.Abs(tGreen - gGreen);
                double BlueError = Math.Abs(tBlue - gBlue);

                ////square each of the color differences (optional but probably a good idea, as mentioned in class on July 9th 2014)
                RedError *= RedError;
                GreenError *= GreenError;
                BlueError *= BlueError;

                //get the total error for the current pixel (rx,ry).
                double pixelError = (RedError + GreenError + BlueError) / 256.0;

                //square the total difference 

                //pixelError *= pixelError;



                //add that to all the other pixel errors.
                fitness += pixelError;
            }
            //normalize by taking the average pixel error.
            fitness /= sampleSize;

            //return the negative of the sum of all the pixel errors because the GA expects higher values to be better.
            return -fitness;
        }



        public Canvas GenotypeToPhenotype(List<double> solution)
        {
            List<int> localPallet = new List<int> { };
            // Make a new canvas 4x as large as the NES Resulution, and create Rectangel's for each pixel
            if (genCanvas == null)
            {
                genCanvas = new Canvas();
                genCanvas.Width = XRes * 2;
                genCanvas.Height = YRes *2;
                for (int i = 0; i < 15360; i++)
                {
                    Rectangle pixel = new Rectangle();

                    pixel.Fill = new SolidColorBrush();
                    pixel.Height = 2;
                    pixel.Width = 2;
                    genCanvas.Children.Add(pixel);
                }
            }

            //Inizile the Local Pallet
            //for (int i = 0; i < 25; i++)
            //{
            //    localPallet.Add(solution[i] % 64);
            //}

            //genCanvas.Children.Clear();

            //The sizeFactor allows the phenotype to implement smaller and smaller ellipses as it implements the list of ellipses.
            //double sizeFactor = solution.Count() / 400;
            int circleCount = 0;

            int solutionIndex=50;
            foreach (UIElement uie in genCanvas.Children)
            {
                Rectangle pixel = uie as Rectangle;
                // In this case we are using 8 doubles for each ellipse.
                // The position of the ellipse is at x,y.
                // The Height and Width is h and w.
                // The color is determined by the a,r,g and b
                //double x = solution[solutionIndex + 0];
                //double y = solution[solutionIndex + 1];
                //double h = solution[solutionIndex + 2];
                //double w = solution[solutionIndex + 3];
                //double r = solution[solutionIndex + 4];
                //double g = solution[solutionIndex + 5];
                //double b = solution[solutionIndex + 6];
                //double a = solution[solutionIndex + 7];
                
                //The NES can have a total of 25 colors displayed at once with stock hardware, so each pixel can be 1 of those 25 colors
                int colorNumber = (int)(solution[solutionIndex] * 64) % 64;

                //Used to determine which pixel is being drawn to.
                int XLine = (solutionIndex - 50) % 128;
                int YLine = (solutionIndex - 50) / 128;


                solutionIndex ++;

                // Normalize the values for position ,height and width.
                //x = (genCanvas.Width * 2 * x) - genCanvas.Width;
                //y = (genCanvas.Height * 2 * y) - genCanvas.Height;
                //h = clamp((genCanvas.Height * 0.5 * h), 0.0, genCanvas.Height);
                //w = clamp((genCanvas.Height * 0.5 * w), 0.0, genCanvas.Height); //I used genCanvas.Height instead of genCanvas.Width. Can anyone figure out why?
                
                //x = (genCanvas.Width * 1.2 * x) - (genCanvas.Width * 0.2);
                //y = (genCanvas.Height * 1.2 * y) - (genCanvas.Height * 0.2);
                //h = clamp((genCanvas.Height * 0.2 * sizeFactor * h), genCanvas.Height * 0.01, genCanvas.Height * 0.2 * sizeFactor);
                //w = clamp((genCanvas.Height * 0.2 * sizeFactor * w), genCanvas.Height * 0.01, genCanvas.Height * 0.2 * sizeFactor); //I used genCanvas.Height instead of genCanvas.Width. Can anyone figure out why?


                ////sizeFactor *= 0.99;
                //if (circleCount > 40) sizeFactor = 1.0;
                //if (circleCount > 100) sizeFactor = 0.5;
                //if (circleCount > 200) sizeFactor = 0.25;


                //// Normalize and clamp values for colors.
                //byte rb = Convert.ToByte(clamp(r * 256.0, 0, 255));
                //byte gb = Convert.ToByte(clamp(g * 256.0, 0, 255));
                //byte bb = Convert.ToByte(clamp(b * 256.0, 0, 255));
                //byte ab = Convert.ToByte(clamp(a * 256.0, 0, 255));


 
                // This allows positioning the ellipse without the need for TranslationTransforms
                Canvas.SetLeft(pixel, XLine);
                Canvas.SetTop(pixel, YLine);


                //ellipse.Fill = new SolidColorBrush(Color.FromArgb(ab, rb, gb, bb));

                SolidColorBrush scb = pixel.Fill as SolidColorBrush;

                scb.Color = getNESColor(colorNumber);

                circleCount++;
            }

            return genCanvas;
        }

        public Color getNESColor(int colorNumber)
        {
            Color returnColor = new Color();
            returnColor = Color.FromRgb(0,0,0);
            switch(colorNumber)
            {
                case 0: returnColor = Color.FromRgb(124, 124, 124); break;
                case 1: returnColor = Color.FromRgb(0, 0, 252); break;
                case 2: returnColor = Color.FromRgb(0, 0, 188); break;
                case 3: returnColor = Color.FromRgb(68, 40, 188); break;
                case 4: returnColor = Color.FromRgb(148, 0, 132); break;
                case 5: returnColor = Color.FromRgb(168, 0, 32); break;
                case 6: returnColor = Color.FromRgb(168, 16, 0); break;
                case 7: returnColor = Color.FromRgb(136, 20, 0); break;
                case 8: returnColor = Color.FromRgb(80, 48, 0); break;
                case 9: returnColor = Color.FromRgb(0, 120, 0); break;
                case 10: returnColor = Color.FromRgb(0, 104, 0); break;
                case 11: returnColor = Color.FromRgb(0, 88, 0); break;
                case 12: returnColor = Color.FromRgb(0, 64, 88); break;
                case 13: returnColor = Color.FromRgb(0, 0, 0); break;
                case 14: returnColor = Color.FromRgb(0, 0, 0); break;
                case 15: returnColor = Color.FromRgb(0, 0, 0); break;
                case 16: returnColor = Color.FromRgb(188, 188, 188); break;
                case 17: returnColor = Color.FromRgb(0, 120, 248); break;
                case 18: returnColor = Color.FromRgb(0, 88, 248); break;
                case 19: returnColor = Color.FromRgb(104, 68, 252); break;
                case 20: returnColor = Color.FromRgb(216, 0, 204); break;
                case 21: returnColor = Color.FromRgb(228, 0, 88); break;
                case 22: returnColor = Color.FromRgb(248, 56, 0); break;
                case 23: returnColor = Color.FromRgb(228, 92, 16); break;
                case 24: returnColor = Color.FromRgb(172, 124, 0); break;
                case 25: returnColor = Color.FromRgb(0, 184, 0); break;
                case 26: returnColor = Color.FromRgb(0, 168, 0); break;
                case 27: returnColor = Color.FromRgb(0, 168, 68); break;
                case 28: returnColor = Color.FromRgb(0, 136, 136); break;
                case 29: returnColor = Color.FromRgb(0, 0, 0); break;
                case 30: returnColor = Color.FromRgb(0, 0, 0); break;
                case 31: returnColor = Color.FromRgb(0, 0, 0); break;
                case 32: returnColor = Color.FromRgb(248, 248, 248); break;
                case 33: returnColor = Color.FromRgb(60, 188, 252); break;
                case 34: returnColor = Color.FromRgb(104, 136, 252); break;
                case 35: returnColor = Color.FromRgb(152, 120, 248); break;
                case 36: returnColor = Color.FromRgb(248, 120, 248); break;
                case 37: returnColor = Color.FromRgb(248, 88, 152); break;
                case 38: returnColor = Color.FromRgb(248, 120, 88); break;
                case 39: returnColor = Color.FromRgb(252, 160, 68); break;
                case 40: returnColor = Color.FromRgb(248, 184, 0); break;
                case 41: returnColor = Color.FromRgb(184, 248, 24); break;
                case 42: returnColor = Color.FromRgb(88, 216, 84); break;
                case 43: returnColor = Color.FromRgb(88, 248, 152); break;
                case 44: returnColor = Color.FromRgb(0, 232, 216); break;
                case 45: returnColor = Color.FromRgb(120, 120, 120); break;
                case 46: returnColor = Color.FromRgb(0, 0, 0); break;
                case 47: returnColor = Color.FromRgb(0, 0, 0); break;
                case 48: returnColor = Color.FromRgb(252, 252, 252); break;
                case 49: returnColor = Color.FromRgb(164, 228, 252); break;
                case 50: returnColor = Color.FromRgb(184, 184, 248); break;
                case 51: returnColor = Color.FromRgb(216, 184, 248); break;
                case 52: returnColor = Color.FromRgb(248, 184, 248); break;
                case 53: returnColor = Color.FromRgb(248, 164, 192); break;
                case 54: returnColor = Color.FromRgb(240, 208, 176); break;
                case 55: returnColor = Color.FromRgb(252, 224, 168); break;
                case 56: returnColor = Color.FromRgb(248, 216, 120); break;
                case 57: returnColor = Color.FromRgb(216, 248, 120); break;
                case 58: returnColor = Color.FromRgb(184, 248, 184); break;
                case 59: returnColor = Color.FromRgb(184, 248, 216); break;
                case 60: returnColor = Color.FromRgb(0, 252, 252); break;
                case 61: returnColor = Color.FromRgb(248, 216, 248); break;
                case 62: returnColor = Color.FromRgb(0, 0, 0); break;
                case 63: returnColor = Color.FromRgb(0, 0, 0); break;

                default:
                    break;
            }

            return returnColor;
        }


        static public Canvas GenotypeToPhenotypeSimple(List<double> solution)
        {
            // Make a new canvas of the same size as the target bitmap.
            Canvas genCanvas = new Canvas();
            genCanvas.Width = targetBitmap.Width;
            genCanvas.Height = targetBitmap.Height;


            // Here we loop through all the doubles in the solution 8 at a time.
            // Each time through the loop creates another ellipse.
            // The number of ellipses is controlled by the size of the solutions as set near line 
            for (int i = 0; i <= solution.Count - 8; i += 8)
            {
                // In this case we are using 8 doubles for each ellipse.
                // The position of the ellipse is at x,y.
                // The Height and Width is h and w.
                // The color is determined by the a,r,g and b
                double x = solution[i + 0];
                double y = solution[i + 1];
                double h = solution[i + 2];
                double w = solution[i + 3];
                double r = solution[i + 4];
                double g = solution[i + 5];
                double b = solution[i + 6];
                double a = solution[i + 7];


                // Normalize the values for position ,height and width.
                //x = (genCanvas.Width * 2 * x) - genCanvas.Width;
                //y = (genCanvas.Height * 2 * y) - genCanvas.Height;
                //h = clamp((genCanvas.Height * 0.5 * h), 0.0, genCanvas.Height);
                //w = clamp((genCanvas.Height * 0.5 * w), 0.0, genCanvas.Height); //I used genCanvas.Height instead of genCanvas.Width. Can anyone figure out why?

                x = (genCanvas.Width * 1.2 * x) - (genCanvas.Width * 0.2);
                y = (genCanvas.Height * 1.2 * y) - (genCanvas.Height * 0.2);
                h = clamp((genCanvas.Height * 0.2 * h), genCanvas.Height * 0.01, genCanvas.Height * 0.2);
                w = clamp((genCanvas.Height * 0.2 * w), genCanvas.Height * 0.01, genCanvas.Height * 0.2); //I used genCanvas.Height instead of genCanvas.Width. Can anyone figure out why?


                // Normalize and clamp values for colors.
                byte rb = Convert.ToByte(clamp(r * 256.0, 0, 255));
                byte gb = Convert.ToByte(clamp(g * 256.0, 0, 255));
                byte bb = Convert.ToByte(clamp(b * 256.0, 0, 255));
                byte ab = Convert.ToByte(clamp(a * 256.0, 0, 255));


                // Create an ellipse.
                Ellipse ellipse = new Ellipse();

                // This allows positioning the ellipse without the need for TranslationTransforms
                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);

                // Set the size of the ellipse and the color.
                ellipse.Height = h;
                ellipse.Width = w;
                ellipse.Fill = new SolidColorBrush(Color.FromArgb(ab, rb, gb, bb));

                // Add it to the canvas.
                genCanvas.Children.Add(ellipse);
            }

            return genCanvas;
        }



        public static void ConvertFEtoRTB(FrameworkElement visual, ref RenderTargetBitmap genBitmap)
        {
            double scaleFactor = 1.0;
            if (genBitmap == null)
            {
                genBitmap = new RenderTargetBitmap(
                    128,
                    120,
                    96,
                    96,
                    PixelFormats.Pbgra32);
            }
            genBitmap.Clear();
            Size size = new Size(128 * scaleFactor, 120 * scaleFactor);

            visual.LayoutTransform = new ScaleTransform(scaleFactor, scaleFactor);

            visual.Measure(size);
            visual.Arrange(new Rect(size));

            genBitmap.Render(visual);
        }

        //static void ConvertFEtoRTB(FrameworkElement visual, ref RenderTargetBitmap genBitmap)
        //{
        //    double scaleFactor = 1.0;
        //    if (genBitmap == null)
        //    {
        //        genBitmap = new RenderTargetBitmap(
        //            (int)(visual.Width * scaleFactor),
        //            (int)(visual.Height * scaleFactor),
        //            96,
        //            96,
        //            PixelFormats.Pbgra32);
        //    }
        //    genBitmap.Clear();
        //    Size size = new Size(visual.Width * scaleFactor, visual.Height * scaleFactor);

        //    visual.LayoutTransform = new ScaleTransform(scaleFactor, scaleFactor);

        //    visual.Measure(size);
        //    visual.Arrange(new Rect(size));

        //    genBitmap.Render(visual);
        //}

        //static RenderTargetBitmap ConvertFEtoRTB(FrameworkElement visual)
        //{
        //    double scaleFactor = 1.0;
        //    RenderTargetBitmap bitmap = new RenderTargetBitmap(
        //        (int)(visual.ActualWidth * scaleFactor),
        //        (int)(visual.ActualHeight * scaleFactor),
        //        96,
        //        96,
        //        PixelFormats.Pbgra32);

        //    Size size = new Size(visual.ActualWidth * scaleFactor, visual.ActualHeight * scaleFactor);

        //    //visual.RenderTransform = new ScaleTransform(2.0, 2.0);
        //    visual.LayoutTransform = new ScaleTransform(scaleFactor, scaleFactor);

        //    visual.Measure(size);
        //    visual.Arrange(new Rect(size));

        //    bitmap.Render(visual);
        //    return bitmap;
        //}
    }
}
