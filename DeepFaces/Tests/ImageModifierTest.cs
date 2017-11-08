using System;
using System.Collections.Generic;
using System.Drawing;
using ImageManipulation;
using System.Text;
using Xunit;

namespace Tests
{
    public class ImageModifierTest
    {
        private Bitmap testImage;

        [Fact]
        public void Pixel2Grayscale()
        {
            Random r = new Random();
            var colorToTest = Color.FromArgb(r.Next());
            var grayShade = (colorToTest.R + colorToTest.G + colorToTest.B) / 3;
            Assert.Equal(Color.FromArgb(grayShade, grayShade, grayShade), ImageModifier.Pixel2Grayscale(colorToTest));
        }

        [Fact]
        public void Image2GreyTest()
        {
            Random r = new Random();
            testImage = new Bitmap(2, 2);
            Bitmap resultImage = testImage;
            for (int x = 0; x < 2; x++)
                for (int y = 0; y < 2; y++)
                    testImage.SetPixel(x, y, Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
            for (int x = 0; x < 2; x++)
                for (int y = 0; y < 2; y++)
                    resultImage.SetPixel(x, y, ImageModifier.Pixel2Grayscale(testImage.GetPixel(x, y)));

            Assert.Equal(resultImage, ImageModifier.Image2Grayscale(testImage));
        }

    }
}
