using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SharpWitness
{
    public class ImageConverter
    {
        public static byte[] ToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image FromByteArray(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image image = Image.FromStream(ms);
            return image;
        }
    }
}
