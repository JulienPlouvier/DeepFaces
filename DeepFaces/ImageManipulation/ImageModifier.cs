using System.Drawing;

namespace ImageManipulation
{
    public static class ImageModifier
    {
        public static Bitmap Image2Grayscale(Bitmap source)
        {
            int h = source.Height;
            int w = source.Width;

            Bitmap result = source;

            for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                {
                    var GreyedPixel = Pixel2Grayscale(source.GetPixel(x, y));
                    result.SetPixel(x, y, GreyedPixel);
                }

            return result;
        }

        public static Color Pixel2Grayscale(Color original)
        {
            var grayShade = (original.R + original.G + original.B) / 3;
            return Color.FromArgb(grayShade, grayShade, grayShade);
        }
    }
}
