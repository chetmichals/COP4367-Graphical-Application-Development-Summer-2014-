using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace ChildsToy_COP4367
{
    public partial class Form1 : Form
    {
        public static Random random = new Random(); //Random Number Generator

        Bitmap variableImage = ChildsToy_COP4367.Properties.Resources.image_BeachBall;
        Bitmap variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_BeachBall;

        Bitmap buttonBlack = ChildsToy_COP4367.Properties.Resources.led_square_black;
        Bitmap buttonYellow = ChildsToy_COP4367.Properties.Resources.led_square_yellow;

        Point mousePointLocation = new Point(100, 100);
        Point randomPoint1 = new Point(200, 0);
        Point randomPoint2 = new Point(0, 200);
        Point[] randomShape = {new Point(100,100), new Point(200, 0), new Point(0, 200)};

        Font font1 = new Font(FontFamily.Families[0], 100.0f);

        String displayString = "There are 0 Lights Lit!";

        Boolean[] lightValues = {false,false,false,false,false,false,false,false,false,false};

        SoundPlayer clickSound;
        SoundPlayer variableSound;
        SoundPlayer chargeSound;


        Color theBackColor;

        int rotateAngle = 10;

        
        
        public Form1()
        {
            InitializeComponent();
            theBackColor = BackColor;
            clickSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_Click);
            variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_Chime);
            chargeSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_charge);
            Invalidate();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle windowSize = Screen.PrimaryScreen.Bounds;
            float fontSize = (windowSize.Height / 12);
            Cursor.Hide();
            font1 = new Font(FontFamily.Families[0], fontSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            variableImage = RotateImage(variableImage, rotateAngle);
            Invalidate();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Rectangle windowSize = Screen.PrimaryScreen.Bounds;
            float textY = (windowSize.Height / 12 * 10);
            float textX = (windowSize.Width / 12 * 2);


            DrawLights(e);
            e.Graphics.DrawImage(variableImage, randomShape);
            e.Graphics.DrawString(displayString, font1, Brushes.Black, textX, textY);
            
        }

        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePointLocation = e.Location;
            randomShape[0] = mousePointLocation;
            randomShape[1] = new Point (randomPoint1.X + mousePointLocation.X, randomPoint1.Y + mousePointLocation.Y);
            randomShape[2] = new Point(randomPoint2.X + mousePointLocation.X, randomPoint2.Y + mousePointLocation.Y);
            Invalidate();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            randomPoint1 = new Point(150 + random.Next(450), 0);
            randomPoint2 = new Point(0, 150 + random.Next(450));
            variableImage = variableImageOrignal;
            variableSound.Play();
        }


        //A bunch of code from "http://stackoverflow.com/questions/10440370/rotating-a-picture-continuously-on-a-windows-form" to make the ball rotate
        public static Bitmap RotateImage(Image image, float angle)
        {
            // center of the image
            float rotateAtX = image.Width / 2;
            float rotateAtY = image.Height / 2;
            bool bNoClip = false;
            return RotateImage(image, rotateAtX, rotateAtY, angle, bNoClip);
        }

        public static Bitmap RotateImage(Image image, float angle, bool bNoClip)
        {
            // center of the image
            float rotateAtX = image.Width / 2;
            float rotateAtY = image.Height / 2;
            return RotateImage(image, rotateAtX, rotateAtY, angle, bNoClip);
        }
                
        public static Bitmap RotateImage(Image image, float rotateAtX, float rotateAtY, float angle, bool bNoClip)
        {
            int W, H, X, Y;
            if (bNoClip)
            {
                double dW = (double)image.Width;
                double dH = (double)image.Height;

                double degrees = Math.Abs(angle);
                if (degrees <= 90)
                {
                    double radians = 0.0174532925 * degrees;
                    double dSin = Math.Sin(radians);
                    double dCos = Math.Cos(radians);
                    W = (int)(dH * dSin + dW * dCos);
                    H = (int)(dW * dSin + dH * dCos);
                    X = (W - image.Width) / 2;
                    Y = (H - image.Height) / 2;
                }
                else
                {
                    degrees -= 90;
                    double radians = 0.0174532925 * degrees;
                    double dSin = Math.Sin(radians);
                    double dCos = Math.Cos(radians);
                    W = (int)(dW * dSin + dH * dCos);
                    H = (int)(dH * dSin + dW * dCos);
                    X = (W - image.Width) / 2;
                    Y = (H - image.Height) / 2;
                }
            }
            else
            {
                W = image.Width;
                H = image.Height;
                X = 0;
                Y = 0;
            }

            //create a new empty bitmap to hold rotated image
            Bitmap bmpRet = new Bitmap(W, H);
            bmpRet.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(bmpRet);

            //Put the rotation point in the "center" of the image
            g.TranslateTransform(rotateAtX + X, rotateAtY + Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-rotateAtX - X, -rotateAtY - Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0 + X, 0 + Y));

            return bmpRet;
        }
        //End code for rotation

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool tempBool = lightValues[0];

            clickSound.Play();

            switch (e.KeyCode.ToString())
            {
                case "D1":
                case "NumPad1":
                    lightValues[0] = !lightValues[0];
                    break;
                case "D2":
                case "NumPad2":
                    lightValues[1] = !lightValues[1];
                    break;
                case "D3":
                case "NumPad3":
                    lightValues[2] = !lightValues[2];
                    break;
                case "D4":
                case "NumPad4":
                    lightValues[3] = !lightValues[3];
                    break;
                case "D5":
                case "NumPad5":
                    lightValues[4] = !lightValues[4];
                    break;
                case "D6":
                case "NumPad6":
                    lightValues[5] = !lightValues[5];
                    break;
                case "D7":
                case "NumPad7":
                    lightValues[6] = !lightValues[6];
                    break;
                case "D8":
                case "NumPad8":
                    lightValues[7] = !lightValues[7];
                    break;
                case "D9":
                case "NumPad9":
                    lightValues[8] = !lightValues[8];
                    break;
                case "D0":
                case "NumPad0":
                    lightValues[9] = !lightValues[9];
                    break;
                case "Space":
                case "Enter":
                case "Return":
                    for (int i = 0; i < 10; i++)
                    {
                        if (random.Next(0, 2) == 1)
                        {
                            lightValues[i] = true;
                        }
                        else
                        {
                            lightValues[i] = false;
                        }
                        chargeSound.Play();
                    }
                    break;

                //Changes R Values
                case "Q":
                case "W":
                case "E":
                case "R":
                case "T":
                case "Y":
                case "U":
                case "I":
                case "O":
                case "P":
                    ChangeRed(e);
                    break;

                //Changes G values
                case "A":
                case "S":
                case "D":
                case "F":
                case "G":
                case "H":
                case "J":
                case "K":
                case "L":
                case "OemSemicolon":
                case "Oem1":
                    ChangeGreen(e);
                    break;

                //Changes B Values
                case "Z":
                case "X":
                case "C":
                case "V":
                case "B":
                case "N":
                case "M":
                case "Oemcomma":
                case "OemPeriod":
                case "OemQuestion":
                    ChangeBlue(e);
                    break;

                case "Oemtilde":
                case "Subtract":
                    tempBool = lightValues[0];
                    for (int i = 0; i < 9; i++)
                    {
                        lightValues[i] = lightValues[i + 1];
                    }
                    lightValues[9] = tempBool;
                    break;
                case "OemMinus":
                case "Add":
                    tempBool = lightValues[9];
                    for (int i = 9; i > 0; i--)
                    {
                        lightValues[i] = lightValues[i - 1];
                    }
                    lightValues[0] = tempBool;
                    break;
                case "Multiply":
                case "Divide":
                    for (int i = 0; i < 10; i++)
                    {
                        lightValues[i] = !lightValues[i];
                    }
                    break;
                case "F1":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_BeachBall;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_BeachBall;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_Chime);
                    variableSound.Play();
                    break;
                case "F2":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_Coin;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_Coin;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_Coin);
                    variableSound.Play();
                    break;
                case "F3":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_star;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_star;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_Star);
                    variableSound.Play();
                    break;
                case "F4":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_phone;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_phone;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_Phone);
                    variableSound.Play();
                    break;
                case "F5":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_bubble;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_bubble;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_bubble);
                    variableSound.Play();
                    break;
                case "F6":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_baseball;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_baseball;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_baseball);
                    variableSound.Play();
                    break;
                case "F7":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_horn;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_horn;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_horn);
                    variableSound.Play();
                    break;
                case "F8":
                    variableImage = ChildsToy_COP4367.Properties.Resources.image_cog;
                    variableImageOrignal = ChildsToy_COP4367.Properties.Resources.image_cog;
                    variableSound = new SoundPlayer(ChildsToy_COP4367.Properties.Resources.sound_cog);
                    variableSound.Play();
                    break;
                case "F9":
                    break;
                case "F10":
                    break;
                case "F11":
                    break;
                case "F12":
                    break;

            }
            //A bit wasteful, but a bit cleaner
            if (GetLights() == 1)
            {
                displayString = "There is 1 Light Lit!";
            }
            else
            {
                displayString = "There are " + GetLights().ToString() + " Lights Lit!";
            }
            //displayString = e.KeyCode.ToString();
        }

        public void DrawLights(PaintEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Rectangle windowSize = Screen.PrimaryScreen.Bounds;
                int imageDrawX = (int)((windowSize.Width * .1) + (i * .08 * windowSize.Width));
                int imageDrawY = (int)(windowSize.Height / 10);
                Rectangle lightDrawRect = new Rectangle(imageDrawX, imageDrawY, 50, 50);

                if (lightValues[i] == true)
                {
                    e.Graphics.DrawImage(buttonYellow, lightDrawRect);
                }
                else
                {
                    e.Graphics.DrawImage(buttonBlack, lightDrawRect);
                }
            }
        }

        public int GetLights()
        {
            int lightCount = 0;
            for (int i = 0; i < 10; i++)
            {
                if (lightValues[i] == true) lightCount++;
            }
            return lightCount;
        }

        public int GetLightsBinary()
        {

            int lightCount = 0;
            for (int i = 9; i >= 0; i--)
            {
                if (lightValues[i] == true)
                {
                    lightCount+=(int)Math.Pow(2,(9-i));
                }
            }
            return lightCount;
        }

        public void ChangeRed(KeyEventArgs e)
        {
            int redChange = 0;
            switch (e.KeyCode.ToString())
            {
                case "Q":
                    redChange = 25;
                    break;
                case "W":
                    redChange = 50;
                    break;
                case "E":
                    redChange = 75;
                    break;
                case "R":
                    redChange = 100;
                    break;
                case "T": 
                    redChange = 125;
                    break;
                case "Y":
                    redChange = 150;
                    break;
                case "U":
                    redChange = 175;
                    break;
                case "I":
                    redChange = 200;
                    break;
                case "O":
                    redChange = 225;
                    break;
                case "P":
                    redChange = 250;
                    break;
            }
            theBackColor = Color.FromArgb(redChange, theBackColor.G, theBackColor.B);
        }
        public void ChangeGreen(KeyEventArgs e)
        {
            int greenChange = 0;
            switch (e.KeyCode.ToString())
            {
                case "A":
                    greenChange = 25;
                    break;
                case "S":
                    greenChange = 50;
                    break;
                case "D":
                    greenChange = 75;
                    break;
                case "F":
                    greenChange = 100;
                    break;
                case "G":
                    greenChange = 125;
                    break;
                case "H":
                    greenChange = 150;
                    break;
                case "J":
                    greenChange = 175;
                    break;
                case "K":
                    greenChange = 200;
                    break;
                case "L":
                    greenChange = 225;
                    break;
                case "OemSemicolon":
                case "Oem1":
                    greenChange = 250;
                    break;
            }
            theBackColor = Color.FromArgb(theBackColor.R, greenChange, theBackColor.B);
        }
        public void ChangeBlue(KeyEventArgs e)
        {
            int blueChange = 0;
            switch (e.KeyCode.ToString())
            {
                case "Z":
                    blueChange = 25;
                    break;
                case "X":
                    blueChange = 50;
                    break;
                case "C":
                    blueChange = 75;
                    break;
                case "V":
                    blueChange = 100;
                    break;
                case "B":
                    blueChange = 120;
                    break;
                case "N":
                    blueChange = 150;
                    break;
                case "M":
                    blueChange = 175;
                    break;
                case "Oemcomma":
                    blueChange = 200;
                    break;
                case "OemPeriod":
                    blueChange = 225;
                    break;
                case "OemQuestion":
                    blueChange = 250;
                    break;
            }
            theBackColor = Color.FromArgb(theBackColor.R, theBackColor.G, blueChange);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            BackColor = theBackColor;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    rotateAngle = -10;
                    break;
                case MouseButtons.Right:
                    rotateAngle = 10;
                    break;
                default:
                    rotateAngle = 0;
                    break;

            }
        }
    }
}
