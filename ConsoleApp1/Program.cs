using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Image playbutton;
            try
            {
                playbutton = Image.FromFile("C:\\images\\b.png");
            }
            catch (Exception ex)
            {
                return;
            }

            Image frame;
            try
            {
                frame = Image.FromFile("C:\\images\\log.jpg");
            }
            catch (Exception ex)
            {
                return;
            }
            int width = 2000, height = 1000;
            using (frame)
            {
                using (var bitmap = new Bitmap(width, height))
                {
                    using (var canvas = Graphics.FromImage(bitmap))
                    {
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.DrawImage(frame,
                                         new Rectangle(0,
                                                       0,
                                                       width,
                                                       height),
                                         new Rectangle(0,
                                                       0,
                                                       frame.Width,
                                                       frame.Height),
                                         GraphicsUnit.Pixel);
                        canvas.DrawImage(playbutton,
                                         (bitmap.Width / 2) - (playbutton.Width / 2) + 200,
                                         (bitmap.Height / 2) - (playbutton.Height / 2) + 100);
                        canvas.Save();
                    }
                    try
                    {
                        bitmap.Save("C:\\images\\logo2.jpg",
                                    System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}
