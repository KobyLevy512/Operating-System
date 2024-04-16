using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;

namespace GamingOS.Resources
{
    public static class ResourceManager
    {
        [ManifestResourceStream(ResourceName = "GamingOS.Resources.Cursor.bmp")]
        public static byte[] Cursor;

        public static Bitmap CursorBitmap = new Bitmap(Cursor);
    }
}
