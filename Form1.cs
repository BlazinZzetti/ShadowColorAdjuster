using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ShadowColorAdjuster
{
    public partial class Form1 : Form
    {
        private Image baseImage1;
        private Image baseImage2;
        private Image baseImage3;
        private Image baseImage4;
        private Image baseImage5;
        
        private Image colorMask1;
        private Image colorMask2;
        private Image colorMask3;
        private Image colorMask4;
        private Image colorMask5;
        private Image colorMask6;

        private const string Image1Name = "tex1_128x128_6f6dc295fc576674_6.png";//Playable Shadow Main
        private const string Image2Name = "tex1_128x128_23470849ed473c96_9bcd3e8f93232964_8.png";//Playable Shadow Eye
        private const string Image3Name = "tex1_128x128_0a670a23d69f0145_d1f065a85855fcc6_8.png";//Event Shadow Main
        private const string Image4Name = "tex1_64x64_ad55d92089adb44b_a7fa923a179a8dd1_8.png";//Event Shadow Accent
        private const string Image5Name = "tex1_128x128_ec9f785c3a033e72_ea84be987812412f_8.png";//Playable Super Shadow Main
        private const string Image6Name = "tex1_128x128_d690c7dc04b985c8_879d6817d5e22595_9.png";//Event Super Shadow Main
        
        
        public Form1()
        {
            InitializeComponent();
            LoadPreviews();
            InitColorControls();
        }

        private void LoadPreviews()
        {
            baseImage1 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorBase1.png");
            baseImage2 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorBase2.png");
            baseImage3 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorBase3.png");
            baseImage4 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorBase4.png");
            baseImage5 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorBase5.png");
            colorMask1 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask1.png");
            colorMask2 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask2.png");
            colorMask3 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask3.png");
            colorMask4 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask4.png");
            colorMask5 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask5.png");
            colorMask6 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask6.png");
            
            PreviewPicture.Image = new Bitmap(baseImage1);
            PreviewPicture2.Image = new Bitmap(baseImage2);
            PreviewPicture3.Image = new Bitmap(baseImage3);
            PreviewPicture4.Image = new Bitmap(baseImage4);
            PreviewPicture5.Image = new Bitmap(baseImage1);
            PreviewPicture6.Image = new Bitmap(baseImage5);
        }

        private void InitColorControls()
        {
            ApplyColorToPreviews();
        }

        private void ApplyColorToPreviews()
        {
            Image newImage = ApplyColorWithMask(true,  baseImage1, colorMask1, AccentColorPreview.BackColor);
            newImage = ApplyColorWithMask(false,  newImage, colorMask3, MainColorPreview.BackColor);

            Image newImage2 = ApplyColorWithMask(true,  baseImage2, colorMask2, AccentColorPreview.BackColor);
            
            Image newImage3 = ApplyColorWithMask(false,  baseImage3, colorMask4, MainColorPreview.BackColor);
            newImage3 = ApplyColorWithMask(true,  newImage3, colorMask5, AccentColorPreview.BackColor);
            
            Image newImage4 = ApplyColorWithMask(true,  baseImage4, null, AccentColorPreview.BackColor);
            
            Image newImage5 = ApplyColorWithMask(true,  baseImage1, colorMask1, AccentColorPreview.BackColor);
            newImage5 = ApplyColorWithMask(false,  newImage5, colorMask3, Color.Black);
            
            Image newImage6 = ApplyColorWithMask(true,  baseImage5, colorMask6, AccentColorPreview.BackColor);

            PreviewPicture.Image = newImage;
            PreviewPicture2.Image = newImage2;
            PreviewPicture3.Image = newImage3;
            PreviewPicture4.Image = newImage4;
            PreviewPicture5.Image = newImage5;
            PreviewPicture6.Image = newImage6;
            
            PreviewPicture.Refresh();
            PreviewPicture2.Refresh();
            PreviewPicture3.Refresh();
            PreviewPicture4.Refresh();
            PreviewPicture5.Refresh();
            PreviewPicture6.Refresh();
            
            MainColorPreview.Refresh();
            AccentColorPreview.Refresh();
        }

        private Image ApplyColorWithMask(bool tint, Image baseImage, Image mask, Color color)
        {
            Bitmap baseImageBitmap = new Bitmap(baseImage);

            Bitmap colorMaskBitmap = null;
            
            if (mask != null)
            {
                colorMaskBitmap = (Bitmap)mask;
            }

            var imgX = baseImage.Width;
            var imgY = baseImage.Height;
            
            for (int x = 0; x < imgX; x++)
            {
                for (int y = 0; y < imgY; y++)
                {
                    var shouldColor = true;
                    if (colorMaskBitmap != null)
                    {
                        var maskPixelColor = colorMaskBitmap.GetPixel(x, y);
                        shouldColor = maskPixelColor.Equals(Color.FromArgb(255,255,255,255));
                    }
                   
                    if (shouldColor)
                    {
                        float colorStrength = 1;
                    
                        if (tint)
                        {
                            colorStrength = ((Bitmap)baseImage).GetPixel(x, y).R / 255.0f;
                        }
                    
                        baseImageBitmap.SetPixel(x, y, Color.FromArgb(255, 
                                (int)(color.R * colorStrength),
                                (int)(color.G * colorStrength),
                                (int)(color.B * colorStrength)));
                    }
                }
            }

            return baseImageBitmap;
        }

        private void UpdatePreviewColor(PictureBox colorPreview, float[] floatRGB)
        {
            UpdatePreviewColor(colorPreview, (int)(floatRGB[0] * 255), (int)(floatRGB[1] * 255), (int)(floatRGB[2] * 255));
        }
        
        private void UpdatePreviewColor(PictureBox colorPreview, int red, int green, int blue)
        {
            colorPreview.BackColor = Color.FromArgb(255, red, green, blue);
        }

        #region Color Manipulation Methods

        //RapidTables.com functions transcribed to C#.

        private float[] RGBToHSL(Color rgbColor)
        {
            float H;
            float S;
            float L;
            
            float r = (float)Math.Round(rgbColor.R / 255.0f, 2, MidpointRounding.AwayFromZero);
            float g = (float)Math.Round(rgbColor.G / 255.0f, 2, MidpointRounding.AwayFromZero);
            float b = (float)Math.Round(rgbColor.B / 255.0f, 2, MidpointRounding.AwayFromZero);

            float min = Math.Min(Math.Min(r, g), b);
            float max = Math.Max(Math.Max(r, g), b);
            float delta = max - min;

            L = (max + min) / 2;

            if (delta == 0)
            {
                H = 0;
                S = 0.0f;
            }
            else
            {
                S = delta / (1 - Math.Abs(2 * L - 1));

                float hue;

                if (r == max)
                {
                    hue = (((g - b) / delta) % 6) / 6;
                }
                else if (g == max)
                {
                    hue = (((b - r) / delta) + 2) / 6;
                }
                else
                {
                    hue = (((r - g) / delta) + 4) / 6;
                }

                if (hue < 0)
                    hue += 1;
                if (hue > 1)
                    hue -= 1;

                H = hue * 360;
                H = (float)Math.Round(H, MidpointRounding.AwayFromZero);
            }

            S *= 100;
            if (S > 100)
                S = 100;
            L *= 100;
            if (L > 100)
                L = 100;

            return new float[] {H, S, L};
        }
        
        public static float[] HSLToRGB(float H, float s, float l)
        {
            float r = 0;
            float g = 0;
            float b = 0;

            float S = s / 100f;
            float L = l / 100f;

            if (H < 0 || H >= 360)
            {
                throw new Exception("Hue out of range");
            }
            
            if (S < 0 || S > 1)
            {
                throw new Exception("Saturation out of range");
            }
            
            if (L < 0 || L > 1)
            {
                throw new Exception("Lightness out of range");
            }

            var C = (1 - Math.Abs((2 * L - 1))) * S;
            var X = C * (1 - Math.Abs(((H / 60) % 2) - 1));
            var m = L - (C / 2);

            if (H < 60)
            {
                r = (C + m);
                g = (X + m);
                b = (0 + m);
            }
            else if(H < 120)
            {
                r = (X + m);
                g = (C + m);
                b = (0 + m);
            }
            else if(H < 180)
            {
                r = (0 + m);
                g = (C + m); 
                b = (X + m);
            }
            else if(H < 240)
            {
                r = (0 + m);
                g = (X + m);
                b = (C + m);
            }
            else if(H < 300)
            {
                r = (X + m);
                g = (0 + m);
                b = (C + m);
            }
            else if(H < 360)
            {
                r = (C + m);
                g = (0 + m);
                b = (X + m);
            }

            return new[]{r, g, b};
        }

        #endregion

        private void SaveImage_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                ((Bitmap)PreviewPicture.Image).Save(fbd.SelectedPath + @"\" + Image1Name, ImageFormat.Png);
                ((Bitmap)PreviewPicture2.Image).Save(fbd.SelectedPath + @"\" + Image2Name, ImageFormat.Png);
                ((Bitmap)PreviewPicture3.Image).Save(fbd.SelectedPath + @"\" + Image3Name, ImageFormat.Png);
                ((Bitmap)PreviewPicture4.Image).Save(fbd.SelectedPath + @"\" + Image4Name, ImageFormat.Png);
                ((Bitmap)PreviewPicture5.Image).Save(fbd.SelectedPath + @"\" + Image5Name, ImageFormat.Png);
                ((Bitmap)PreviewPicture6.Image).Save(fbd.SelectedPath + @"\" + Image6Name, ImageFormat.Png);
            }
        }

        private void MainColorEditor_ColorChanged(object sender, EventArgs e)
        {
            UpdatePreviewColor(MainColorPreview, MainColorEditor.Color.R, MainColorEditor.Color.G, MainColorEditor.Color.B);
            ApplyColorToPreviews();
        }

        private void AccentColorEditor_ColorChanged(object sender, EventArgs e)
        {
            UpdatePreviewColor(AccentColorPreview, AccentColorEditor.Color.R, AccentColorEditor.Color.G, AccentColorEditor.Color.B);
            ApplyColorToPreviews();
        }
    }
}