using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using SkiaSharp;

namespace ImageButtonUpdateIssue.Views
{
    public class CustomImageButton : ImageButton
    {
        private static Random rand = new Random();

        private static ImageSource[] imageData = new ImageSource[4];

        private int clickCount;
        public CustomImageButton()
        {
            BackgroundColor = Colors.Transparent;
        }

        public void UpdateImage()
        {
            Source = GetImage(clickCount++ % imageData.Length);
        }

        private ImageSource GetImage(int imageIndex)
        {
            if (imageData[imageIndex] != null)
            {
                return imageData[imageIndex];
            }
            SKColor color1 = SKColor.FromHsv(rand.Next(255), 255f, 255f);
            SKColor color2 = SKColor.FromHsv(rand.Next(255), 255f, 255f);
            using SKBitmap newBitmap = new SKBitmap(64, 64);
            int width = newBitmap.Width;
            int height = newBitmap.Height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var color = i / 8 % 2 == j / 8 % 2 ? color1 : color2;
                    newBitmap.SetPixel(i, j, color);
                }
            }
            using (MemoryStream ms = BitmapToStream(newBitmap))
            {
                byte[] byteArray = ms.ToArray();
                var imageSource = ImageSource.FromStream(() => new MemoryStream(byteArray));
                imageData[imageIndex] = imageSource;
                return imageSource;
            }
        }

        private static MemoryStream BitmapToStream(SKBitmap skBitmap)
        {
            var ms = new MemoryStream();
            skBitmap.Encode(ms, SKEncodedImageFormat.Png, 100);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}
