using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ImageManipulation;
using System.Drawing;

namespace Tests
{
    public class HOGTest
    {
        private HOG hog;

        [Fact]
        public void ApplyGradientFilterTest()
        {
            hog = new HOG(null);

            int[][] cellToTest1 = {new int[] {100, 100, 100},
                                  new int[] {100, 100, 100},
                                  new int[] {100, 100, 100} };
            int[][] cellToTest2 = {new int[] {100, 50, 100},
                                  new int[] {50, 100, 100},
                                  new int[] {100, 100, 100} };
            int[][] cellToTest3 = {new int[] {100, 100, 100},
                                  new int[] {100, 100, 50},
                                  new int[] {100, 50, 100} };

            Assert.Equal(0, hog.ApplyGradientFilter(cellToTest1));
            Assert.Equal(100, hog.ApplyGradientFilter(cellToTest2));
            Assert.Equal(-100, hog.ApplyGradientFilter(cellToTest3));

        }

        [Fact]
        public void TransformImageIntoGradientMapTest()
        {
            hog = new HOG(null);

            int[][] cellToTest1 = {new int[] {100, 100, 100},
                                  new int[] {100, 100, 100},
                                  new int[] {100, 100, 100} };
            int[][] cellToTest2 = {new int[] {100, 50, 100},
                                  new int[] {50, 100, 100},
                                  new int[] {100, 100, 100} };
            int[][] cellToTest3 = {new int[] {100, 100, 100},
                                  new int[] {100, 100, 50},
                                  new int[] {100, 50, 100} };

            Assert.Equal(new int[][] { new int[] { 0 } }, hog.TransformImageIntoGradientMap(cellToTest1));
            Assert.Equal(new int[][] { new int[] { 100 } }, hog.TransformImageIntoGradientMap(cellToTest2));
            Assert.Equal(new int[][] { new int[] { -100 } }, hog.TransformImageIntoGradientMap(cellToTest3));
        }

        [Fact]
        public void ArrayTo3x3CellTest()
        {
            hog = new HOG(null);

            int[][] cellToTest1 = {new int[] {1, 2, 3, 4, 5},
                                  new int[] {6, 7, 8, 9, 10},
                                  new int[] {11, 12, 13, 14, 15},
                                  new int[] {16, 17, 18, 19, 20},
                                  new int[] {21, 22, 23, 24, 25}};

            int[][] result11 = { new int[] { 1, 2, 3 }, new int[] { 6, 7, 8 }, new int[] { 11, 12, 13 } };
            int[][] result22 = { new int[] { 7, 8, 9 }, new int[] { 12, 13, 14 }, new int[] { 17, 18, 19 } };
            int[][] result32 = { new int[] { 12, 13, 14 }, new int[] { 17, 18, 19 }, new int[] { 22, 23, 24 } };

            Assert.Equal(result11, hog.ArrayTo3x3Cell(cellToTest1, 1, 1));
            Assert.Equal(result22, hog.ArrayTo3x3Cell(cellToTest1, 2, 2));
            Assert.Equal(result32, hog.ArrayTo3x3Cell(cellToTest1, 3, 2));
        }

        [Fact]
        public void ArrayTo6x6CellTest()
        {
            hog = new HOG(null);

            int[][] cellToTest1 = {new int[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5},
                                  new int[] {6, 7, 8, 9, 10, 6, 7, 8, 9, 10},
                                  new int[] {11, 12, 13, 14, 15, 11, 12, 13, 14, 15},
                                  new int[] {16, 17, 18, 19, 20, 16, 17, 18, 19, 20},
                                  new int[] {21, 22, 23, 24, 25, 21, 22, 23, 24, 25},
                                  new int[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5},
                                  new int[] {6, 7, 8, 9, 10, 6, 7, 8, 9, 10},
                                  new int[] {11, 12, 13, 14, 15, 11, 12, 13, 14, 15},
                                  new int[] {16, 17, 18, 19, 20, 16, 17, 18, 19, 20},
                                  new int[] {21, 22, 23, 24, 25, 21, 22, 23, 24, 25},};

            int[][] result00 = { new int[] { 1, 2, 3, 4, 5, 1 }, new int[] { 6,7,8,9,10,6 }, new int[] { 11,12,13,14,15,11 },
                    new int[] { 16,17,18,19,20,16 }, new int[] { 21,22,23,24,25,21 }, new int[] { 1, 2, 3, 4, 5, 1 } };
            int[][] result40 = { new int[] { 21,22,23,24,25,21 }, new int[] {1,2,3,4,5,1 }, new int[] { 6,7,8,9,10,6 },
                        new int[] { 11,12,13,14,15,11 }, new int[] { 16,17,18,19,20,16 }, new int[] { 21,22,23,24,25,21 } };
            int[][] result44 = { new int[] { 25,21,22,23,24,25 }, new int[] { 5,1,2,3,4,5 }, new int[] { 10,6,7,8,9,10 },
                    new int[] { 15,11,12,13,14,15 }, new int[] { 20,16,17,18,19,20 }, new int[] { 25,21,22,23,24,25 } };

            Assert.Equal(result00, hog.ArrayTo6x6Cell(cellToTest1, 0, 0));
            Assert.Equal(result40, hog.ArrayTo6x6Cell(cellToTest1, 4, 0));
            Assert.Equal(result44, hog.ArrayTo6x6Cell(cellToTest1, 4, 4));
        }
    }
}
