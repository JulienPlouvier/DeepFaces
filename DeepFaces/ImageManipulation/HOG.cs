using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class HOG
    {
        private static int[][] _GradientFilter = { new int[] { 0, -1, 0 }, new int[] { -1, 0, 1 }, new int[] { 0, 1, 0 } };

        private ImageData image;

        public ImageData Image
        {
            get { return image; }
            private set { image = value; }
        }

        public HOG(Bitmap imageToAnalyse)
        {
            Image = new ImageData();
            //TransformImageIntoGradientMap();
        }

        public int ApplyGradientFilter(int[][] cell)
        {
            int result = 0;

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    result += _GradientFilter[x][y] * cell[x][y];

            return result;
        }

        public int[][] TransformImageIntoGradientMap(int[][] GrayscaleShadesPixels)
        {
            int Width = GrayscaleShadesPixels.Count();
            if (Width <= 2)
                throw new ArgumentException("Image array is not wide enough");
            int Height = GrayscaleShadesPixels[0].Count();
            if (Height <= 2)
                throw new ArgumentException("Image array is not high enough");

            int[][] result = new int[Width - 2][]; //Widht & Height -2 in result because we don't consider the border pixel line of the original image
            for (int i = 0; i < Width - 2; i++)
                result[i] = new int[Height - 2];

            for (int x = 1; x < Width - 1; x++)
                for (int y = 1; y < Height - 1; y++)
                    result[x - 1][y - 1] = ApplyGradientFilter(ArrayTo3x3Cell(GrayscaleShadesPixels, x, y));

            return result;
        }

        public int[][] ArrayTo3x3Cell(int[][] originArray, int centerX, int centerY)
        {
            int[][] result = new int[3][];
            for (int i = 0; i < 3; i++)
                result[i] = new int[3];

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    result[x][y] = originArray[centerX - 1 + x][centerY - 1 + y];

            return result;
        }
    }
}
