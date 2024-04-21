

using Cosmos.System.Graphics;

namespace GamingOS.Utils
{
    public class BitmapGraphics
    {
        Bitmap buffer;

        public BitmapGraphics(Bitmap buffer)
        {
            this.buffer = buffer;
        }

        public uint GetPixel(uint x, uint y)
        {
            uint index = y * buffer.Width + x;
            if (index < 0 || index >= buffer.Height) return 0;
            return (uint)buffer.rawData[index];
        }
        public void SetPixel(uint color, uint x, uint y)
        {
            uint index = y * buffer.Width + x;
            if (index < 0 || index >= buffer.Height) return;
            buffer.rawData[index] = (int)color;
        }
        public void DrawRectangle(uint color, Location loc)
        {
            int untilX = loc.Position.X + loc.Size.X;
            int untilY = loc.Position.Y + loc.Size.Y;
            for(uint i = (uint)loc.Position.X; i < untilX; i++)
            {
                SetPixel(color, i, (uint)loc.Position.Y);
                SetPixel(color, i, (uint)untilY);
            }
            for (uint i = (uint)loc.Position.Y; i < untilY; i++)
            {
                SetPixel(color, (uint)loc.Position.X, i);
                SetPixel(color, (uint)untilX, i);
            }
        }
    }
}
