using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ShadowColorAdjuster
{
    public partial class Form1 : Form
    {
        private bool controlUpdateInProgress = false;
        
        private Image baseImage1;
        private Image baseImage2;
        private Image baseImage3;
        private Image baseImage4;
        
        private Image colorMask1;
        private Image colorMask2;
        private Image colorMask3;
        private Image colorMask4;
        private Image colorMask5;

        private const string Image1Name = "tex1_128x128_95091b97a182cc89_16cffb4f349bb9eb_8.png";
        private const string Image2Name = "tex1_128x128_23470849ed473c96_9bcd3e8f93232964_8.png";
        private const string Image3Name = "tex1_128x128_0a670a23d69f0145_d1f065a85855fcc6_8.png";
        private const string Image4Name = "tex1_64x64_ad55d92089adb44b_a7fa923a179a8dd1_8.png";
        
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
            colorMask1 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask1.png");
            colorMask2 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask2.png");
            colorMask3 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask3.png");
            colorMask4 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask4.png");
            colorMask5 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"ReferenceImages\ShadowColorMask5.png");
            
            PreviewPicture.Image = new Bitmap(baseImage1);
            PreviewPicture2.Image = new Bitmap(baseImage2);
            PreviewPicture3.Image = new Bitmap(baseImage3);
            PreviewPicture4.Image = new Bitmap(baseImage4);
        }

        private void InitColorControls()
        {
            controlUpdateInProgress = true;

            MainRedNumericUpDown.Value = MainColorPreview.BackColor.R;
            MainGreenNumericUpDown.Value = MainColorPreview.BackColor.G;
            MainBlueNumericUpDown.Value = MainColorPreview.BackColor.B;

            MainRedTrackBar.Value = MainColorPreview.BackColor.R;
            MainGreenTrackBar.Value = MainColorPreview.BackColor.G;
            MainBlueTrackBar.Value = MainColorPreview.BackColor.B;

            var mainHsl = RGBToHSL(MainColorPreview.BackColor);
        
            MainHueTrackBar.Value = (int)mainHsl[0];
            MainHueNumericUpDown.Value = (decimal)mainHsl[0];
            MainSatTrackBar.Value = (int)mainHsl[1];
            MainSatNumericUpDown.Value = (decimal)mainHsl[1];
            MainLightTrackBar.Value = (int)mainHsl[2];
            MainLightNumericUpDown.Value = (decimal)mainHsl[2];
            
            AccentRedNumericUpDown.Value = AccentColorPreview.BackColor.R;
            AccentGreenNumericUpDown.Value = AccentColorPreview.BackColor.G;
            AccentBlueNumericUpDown.Value = AccentColorPreview.BackColor.B;

            AccentRedTrackBar.Value = AccentColorPreview.BackColor.R;
            AccentGreenTrackBar.Value = AccentColorPreview.BackColor.G;
            AccentBlueTrackBar.Value = AccentColorPreview.BackColor.B;

            var hsl = RGBToHSL(AccentColorPreview.BackColor);
        
            AccentHueTrackBar.Value = (int)hsl[0];
            AccentHueNumericUpDown.Value = (decimal)hsl[0];
            AccentSatTrackBar.Value = (int)hsl[1];
            AccentSatNumericUpDown.Value = (decimal)hsl[1];
            AccentLightTrackBar.Value = (int)hsl[2];
            AccentLightNumericUpDown.Value = (decimal)hsl[2];

            controlUpdateInProgress = false;

            ApplyColorToPreviews();
        }
        
        private void UpdateColorControls(bool withRGB, bool withScroll)
        {
            controlUpdateInProgress = true;
            
            if (withRGB)
            {
                if (withScroll)
                {
                    MainRedNumericUpDown.Value = MainColorPreview.BackColor.R;
                    MainGreenNumericUpDown.Value = MainColorPreview.BackColor.G;
                    MainBlueNumericUpDown.Value = MainColorPreview.BackColor.B;
                }
                else
                {
                    MainRedTrackBar.Value = MainColorPreview.BackColor.R;
                    MainGreenTrackBar.Value = MainColorPreview.BackColor.G;
                    MainBlueTrackBar.Value = MainColorPreview.BackColor.B;
                }

                var mainHsl = RGBToHSL(MainColorPreview.BackColor);
            
                MainHueTrackBar.Value = (int)mainHsl[0];
                MainHueNumericUpDown.Value = (decimal)mainHsl[0];
                MainSatTrackBar.Value = (int)mainHsl[1];
                MainSatNumericUpDown.Value = (decimal)mainHsl[1];
                MainLightTrackBar.Value = (int)mainHsl[2];
                MainLightNumericUpDown.Value = (decimal)mainHsl[2];
                
                if (withScroll)
                {
                    AccentRedNumericUpDown.Value = AccentColorPreview.BackColor.R;
                    AccentGreenNumericUpDown.Value = AccentColorPreview.BackColor.G;
                    AccentBlueNumericUpDown.Value = AccentColorPreview.BackColor.B;
                }
                else
                {
                    AccentRedTrackBar.Value = AccentColorPreview.BackColor.R;
                    AccentGreenTrackBar.Value = AccentColorPreview.BackColor.G;
                    AccentBlueTrackBar.Value = AccentColorPreview.BackColor.B;
                }

                var hsl = RGBToHSL(AccentColorPreview.BackColor);
            
                AccentHueTrackBar.Value = (int)hsl[0];
                AccentHueNumericUpDown.Value = (decimal)hsl[0];
                AccentSatTrackBar.Value = (int)hsl[1];
                AccentSatNumericUpDown.Value = (decimal)hsl[1];
                AccentLightTrackBar.Value = (int)hsl[2];
                AccentLightNumericUpDown.Value = (decimal)hsl[2];
            }
            else
            {
                if (withScroll)
                {
                    MainHueNumericUpDown.Value = MainHueTrackBar.Value;
                    MainSatNumericUpDown.Value = MainSatTrackBar.Value;
                    MainLightNumericUpDown.Value = MainLightTrackBar.Value;
                }
                else
                {
                    MainHueTrackBar.Value = (int)MainHueNumericUpDown.Value;
                    MainSatTrackBar.Value = (int)MainSatNumericUpDown.Value;
                    MainLightTrackBar.Value = (int)MainLightNumericUpDown.Value;
                }
                
                MainRedTrackBar.Value = MainColorPreview.BackColor.R;
                MainRedNumericUpDown.Value = MainColorPreview.BackColor.R;
                MainGreenTrackBar.Value = MainColorPreview.BackColor.G;
                MainGreenNumericUpDown.Value = MainColorPreview.BackColor.G;
                MainBlueTrackBar.Value = MainColorPreview.BackColor.B;
                MainBlueNumericUpDown.Value = MainColorPreview.BackColor.B;
                
                if (withScroll)
                {
                    AccentHueNumericUpDown.Value = AccentHueTrackBar.Value;
                    AccentSatNumericUpDown.Value = AccentSatTrackBar.Value;
                    AccentLightNumericUpDown.Value = AccentLightTrackBar.Value;
                }
                else
                {
                    AccentHueTrackBar.Value = (int)AccentHueNumericUpDown.Value;
                    AccentSatTrackBar.Value = (int)AccentSatNumericUpDown.Value;
                    AccentLightTrackBar.Value = (int)AccentLightNumericUpDown.Value;
                }
                
                AccentRedTrackBar.Value = AccentColorPreview.BackColor.R;
                AccentRedNumericUpDown.Value = AccentColorPreview.BackColor.R;
                AccentGreenTrackBar.Value = AccentColorPreview.BackColor.G;
                AccentGreenNumericUpDown.Value = AccentColorPreview.BackColor.G;
                AccentBlueTrackBar.Value = AccentColorPreview.BackColor.B;
                AccentBlueNumericUpDown.Value = AccentColorPreview.BackColor.B;
            }

            controlUpdateInProgress = false;

            ApplyColorToPreviews();
        }

        private void ApplyColorToPreviews()
        {
            ApplyColorWithMask(true, PreviewPicture, baseImage1, colorMask1, AccentColorPreview.BackColor);
            ApplyColorWithMask(false, PreviewPicture, baseImage1, colorMask3, MainColorPreview.BackColor);

            ApplyColorWithMask(true, PreviewPicture2, baseImage2, colorMask2, AccentColorPreview.BackColor);
            
            ApplyColorWithMask(false, PreviewPicture3, baseImage3, colorMask4, MainColorPreview.BackColor);
            ApplyColorWithMask(true, PreviewPicture3, baseImage3, colorMask5, AccentColorPreview.BackColor);
            
            ApplyColorWithMask(true, PreviewPicture4, baseImage4, null, AccentColorPreview.BackColor);
            
            PreviewPicture.Refresh();
            PreviewPicture2.Refresh();
            PreviewPicture3.Refresh();
            PreviewPicture4.Refresh();
            MainColorPreview.Refresh();
            AccentColorPreview.Refresh();
        }

        private void ApplyColorWithMask(bool tint, PictureBox previewPicture, Image baseImage, Image mask, Color color)
        {
            if (previewPicture.Image != null)
            {
                var baseImageBitmap = (Bitmap)baseImage;

                var imgX = baseImage.Width;
                var imgY = baseImage.Height;
                
                for (int x = 0; x < imgX; x++)
                {
                    for (int y = 0; y < imgY; y++)
                    {
                        var shouldColor = true;
                        if (mask != null)
                        {
                            var colorMaskBitmap = (Bitmap)mask;
                            var maskPixelColor = colorMaskBitmap.GetPixel(x, y);
                            shouldColor = maskPixelColor.Equals(Color.FromArgb(255, 255, 255, 255));
                        }
                       
                        if (shouldColor)
                        {
                            float colorStrength = 1;

                            if (tint)
                            {
                                colorStrength = baseImageBitmap.GetPixel(x, y).R / 255.0f;
                            }

                            ((Bitmap)previewPicture.Image).SetPixel(x, y,
                                Color.FromArgb(255, 
                                    (int)(color.R * colorStrength),
                                    (int)(color.G * colorStrength),
                                    (int)(color.B * colorStrength)));
                        }
                    }
                }
            }
        }

        #region ControlValueChanged Methods

        private void UpdatePreviewColor(PictureBox colorPreview, float[] floatRGB)
        {
            UpdatePreviewColor(colorPreview, (int)(floatRGB[0] * 255), (int)(floatRGB[1] * 255), (int)(floatRGB[2] * 255));
        }
        
        private void UpdatePreviewColor(PictureBox colorPreview, int red, int green, int blue)
        {
            colorPreview.BackColor = Color.FromArgb(255, red, green, blue);
        }
        
        #region Accent Color

        private void RedNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, (int)AccentRedNumericUpDown.Value, AccentColorPreview.BackColor.G, AccentColorPreview.BackColor.B);
                UpdateColorControls(true, false);
            }
        }

        private void RedTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, AccentRedTrackBar.Value, AccentColorPreview.BackColor.G, AccentColorPreview.BackColor.B);
                UpdateColorControls(true, true);
            }
        }
        
        private void GreenNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, AccentColorPreview.BackColor.R, (int)AccentGreenNumericUpDown.Value, AccentColorPreview.BackColor.B);
                UpdateColorControls(true, false);
            }
        }

        private void GreenTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, AccentColorPreview.BackColor.R, AccentGreenTrackBar.Value, AccentColorPreview.BackColor.B);
                UpdateColorControls(true, true);
            }
        }
        
        private void BlueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, AccentColorPreview.BackColor.R, AccentColorPreview.BackColor.G, (int)AccentBlueNumericUpDown.Value);
                UpdateColorControls(true, false);
            }
        }

        private void BlueTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, AccentColorPreview.BackColor.R, AccentColorPreview.BackColor.G, AccentBlueTrackBar.Value);
                UpdateColorControls(true, true);
            }
        }
        
        private void HueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, HSLToRGB((int)AccentHueNumericUpDown.Value, (int)AccentSatNumericUpDown.Value, (int)AccentLightNumericUpDown.Value));
                UpdateColorControls(false, false);
            }
        }

        private void HueTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, HSLToRGB((int)AccentHueNumericUpDown.Value, (int)AccentSatNumericUpDown.Value, (int)AccentLightNumericUpDown.Value));
                UpdateColorControls(false, true);
            }
        }

        private void SatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, HSLToRGB((int)AccentHueNumericUpDown.Value, (int)AccentSatNumericUpDown.Value, (int)AccentLightNumericUpDown.Value));
                UpdateColorControls(false, false);
            }
        }
        
        private void SatTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, HSLToRGB((int)AccentHueNumericUpDown.Value, (int)AccentSatNumericUpDown.Value, (int)AccentLightNumericUpDown.Value));
                UpdateColorControls(false, true);
            }
        }

        private void LightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, HSLToRGB((int)AccentHueNumericUpDown.Value, (int)AccentSatNumericUpDown.Value, (int)AccentLightNumericUpDown.Value));
                UpdateColorControls(false, false);
            }
        }
        
        private void LightTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(AccentColorPreview, HSLToRGB((int)AccentHueNumericUpDown.Value, (int)AccentSatNumericUpDown.Value, (int)AccentLightNumericUpDown.Value));
                UpdateColorControls(false, true);
            }
        }

        #endregion
        
        private void MainRedNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, (int)MainRedNumericUpDown.Value, MainColorPreview.BackColor.G, MainColorPreview.BackColor.B);
                UpdateColorControls(true, false);
            }
        }

        private void MainRedTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, MainRedTrackBar.Value, MainColorPreview.BackColor.G, MainColorPreview.BackColor.B);
                UpdateColorControls(true, true);
            }
        }
        
        private void MainGreenNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, MainColorPreview.BackColor.R, (int)MainGreenNumericUpDown.Value, MainColorPreview.BackColor.B);
                UpdateColorControls(true, false);
            }
        }

        private void MainGreenTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, MainColorPreview.BackColor.R, MainGreenTrackBar.Value, MainColorPreview.BackColor.B);
                UpdateColorControls(true, true);
            }
        }
        
        private void MainBlueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, MainColorPreview.BackColor.R, MainColorPreview.BackColor.G, (int)MainBlueNumericUpDown.Value);
                UpdateColorControls(true, false);
            }
        }

        private void MainBlueTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, MainColorPreview.BackColor.R, MainColorPreview.BackColor.G, MainBlueTrackBar.Value);
                UpdateColorControls(true, true);
            }
        }

        private void MainHueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, HSLToRGB((int)MainHueNumericUpDown.Value, (int)MainSatNumericUpDown.Value, (int)MainLightNumericUpDown.Value));
                UpdateColorControls(false, false);
            }
        }

        private void MainHueTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, HSLToRGB((int)MainHueNumericUpDown.Value, (int)MainSatNumericUpDown.Value, (int)MainLightNumericUpDown.Value));
                UpdateColorControls(false, true);
            }
        }

        private void MainSatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, HSLToRGB((int)MainHueNumericUpDown.Value, (int)MainSatNumericUpDown.Value, (int)MainLightNumericUpDown.Value));
                UpdateColorControls(false, false);
            }
        }
        
        private void MainSatTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, HSLToRGB((int)MainHueNumericUpDown.Value, (int)MainSatNumericUpDown.Value, (int)MainLightNumericUpDown.Value));
                UpdateColorControls(false, true);
            }
        }

        private void MainLightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, HSLToRGB((int)MainHueNumericUpDown.Value, (int)MainSatNumericUpDown.Value, (int)MainLightNumericUpDown.Value));
                UpdateColorControls(false, false);
            }
        }
        
        private void MainLightTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!controlUpdateInProgress)
            {
                UpdatePreviewColor(MainColorPreview, HSLToRGB((int)MainHueNumericUpDown.Value, (int)MainSatNumericUpDown.Value, (int)MainLightNumericUpDown.Value));
                UpdateColorControls(false, true);
            }
        }
        
        #endregion

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

            return new float[3] {H, S, L};
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
            }
        }
    }
}