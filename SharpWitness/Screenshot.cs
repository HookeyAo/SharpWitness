using Alx.Web;
using System.Drawing;

namespace SharpWitness
{
    public class Screenshot
    {
        public static Image Capture(string url)
        {
            var device = Devices.TabletLandscape;
            return Alx.Web.Screenshot.Take(url, device);
        }
    }
}
