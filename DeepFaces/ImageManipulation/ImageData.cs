using System.Drawing;

namespace ImageManipulation
{
    public enum VectorDirection
    {
        UpLeft, 
        Up,
        UpRight, 
        Left, 
        Center,
        Right,
        DownLeft,
        Down,
        DownRight
    };

    public class ImageData
    {
        private Bitmap image;

        public Bitmap Image
        {
            get { return image; }
            private set { image = value; }
        }

        private VectorDirection[][] vectorredImage;

        public VectorDirection[][] VectorredImage
        {
            get { return vectorredImage; }
            private set { vectorredImage = value; }
        }

        public ImageData()
        {

        }
        
    }
}
