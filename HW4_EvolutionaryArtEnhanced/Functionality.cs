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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Shapes;
using T_Objects;
using System.ComponentModel;
using System.IO;

namespace WpfTransducer
{
    class Functionality
    {
        int populationSize = 1000;
        public MainWindow mainWindow;
        public TargetWindow targetWindow;
        public TargetWindow genWindow;
        
        GeneticAlgorithm ga;
        ArtEvaluator sombrero = new ArtEvaluator();

        //TransformGroup canvasTransform;

        public Functionality()
        {

        }

        public void setup()
        {
            ga = new GeneticAlgorithm();
            // The population size is set to 10000 individuals of ~16000 doubles each. 
            ga.populate(populationSize, 15500, 0.0, 2.0);

            // The target window displays the target image.
            targetWindow = new TargetWindow();
            targetWindow.Height = 240;
            targetWindow.Width = 256;
            targetWindow.Background = new ImageBrush(ArtEvaluator.targetBitmap);
            targetWindow.Show();

            // The target window displays the genrated image.
            genWindow = new TargetWindow();
            genWindow.Height = 240;
            genWindow.Width = 256;
            genWindow.Title = "GenWindow";
            genWindow.Show();

            //The main window is set to the same size as the target window
            mainWindow.Height = 1;
            mainWindow.Width = 1;

            //Puts genWindow in the upper left corner
            genWindow.Top = 0;
            genWindow.Left = 0;

            //Puts Target Window next to GenWindow
            targetWindow.Top = genWindow.Top;
            targetWindow.Left = genWindow.Left + genWindow.Width;
        }



        public string runGA(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ga.scoreOfLastSolution = sombrero.evaluate((ga.solution));
            }
            return ga.bestScoreSoFar.ToString();
        }


        public string plotGA()
        {
            Canvas canvas = sombrero.GenotypeToPhenotype(ga.bestSolutionSoFar);

            //Rectangle rectangle = new Rectangle();
            //Canvas.SetLeft(rectangle, 0);
            //Canvas.SetTop(rectangle, 0);
            //rectangle.Width = ArtEvaluator.targetBitmap.Width;
            //rectangle.Height = ArtEvaluator.targetBitmap.Height;
            //rectangle.Stroke = Brushes.Black;
            //rectangle.StrokeThickness = 5.0;
            //canvas.Children.Add(rectangle);
            //mainWindow.Content = canvas;

            RenderTargetBitmap rtb=null;
            ArtEvaluator.ConvertFEtoRTB(canvas,ref rtb);
            genWindow.Background = new ImageBrush(rtb);
            return "GA Plotted";
        }


        internal string randBackground()
        {
            string result = "";
            byte r = (byte)G.random.Next(256);
            byte g = (byte)G.random.Next(256);
            byte b = (byte)G.random.Next(256);
            mainWindow.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            result = "Back color changed to RGB(" + r.ToString() + "," + g.ToString() + "," + b.ToString() + ")";
            return result;
        }

        public void LoadFile()
        {
            sombrero.LoadFile();
            targetWindow.Background = new ImageBrush(ArtEvaluator.targetBitmap);

        }

        public void changePopulationSize(int popSize)
        {
            populationSize = popSize;
            ga.populate(populationSize, 15500, 0.0, 2.0);
        }

        public string createArt(int popSize, int genCount)
        {
            string result = "";
            for (int i = 0; i < genCount; i++)
            {
                result = runGA(popSize);
            }
            Canvas canvas = sombrero.GenotypeToPhenotype(ga.bestSolutionSoFar);
            RenderTargetBitmap rtb = null;
            ArtEvaluator.ConvertFEtoRTB(canvas, ref rtb);
            genWindow.Background = new ImageBrush(rtb);
            CreateSaveBitmap(canvas, DateTime.Now.Ticks.ToString()+".png");
            return result;
        }

        private void CreateSaveBitmap(Canvas canvas, string filename)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
             (int)canvas.Width/2, (int)canvas.Height/2,
             96d, 96d, PixelFormats.Pbgra32);
            // needed otherwise the image output is black
            canvas.Measure(new Size((int)canvas.Width, (int)canvas.Height));
            canvas.Arrange(new Rect(new Size((int)canvas.Width, (int)canvas.Height)));

            renderBitmap.Render(canvas);

            //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
    }
}
