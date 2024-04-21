

namespace GamingOS.Utils
{
    public struct Location
    {
        public Vector Position, Size;
        public int ZLocation;
        public Location()
        {
            Position = new Vector();
            Size = new Vector();
            ZLocation = 0;
        }

        public bool PointIsInside(Vector v)
        {
            return v.X >= Position.X && v.X <= Size.X && v.Y >= Position.Y && v.Y <= Size.Y;
        }

        public bool LocationIsOverlap(Location loc)
        {
            Vector v = loc.Position + loc.Size;
            return PointIsInside(loc.Position) || PointIsInside(v);
        }
    }
}
