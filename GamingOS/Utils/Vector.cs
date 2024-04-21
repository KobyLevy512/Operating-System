
namespace GamingOS.Utils
{
    public struct Vector
    {
        public int X, Y;

        public Vector()
        {
            X = 0;
            Y = 0;
        }
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector() { X = a.X + b.X, Y = a.Y + b.Y };
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector() { X = a.X - b.X, Y = a.Y - b.Y };
        }
        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector() { X = a.X * b.X, Y = a.Y * b.Y };
        }
        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector() { X = a.X / b.X, Y = a.Y / b.Y };
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector)
            {
                return (Vector)obj == this;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ((short)X).GetHashCode() | (Y << 16).GetHashCode();
        }
    }
}
