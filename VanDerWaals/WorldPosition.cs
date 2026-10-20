using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal struct WorldPosition
    {
        public float X;
        public float Y;

        public WorldPosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        public WorldPosition(Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public static WorldPosition Zero   { get { return new WorldPosition( 0.0f,  0.0f); } }
        public static WorldPosition One    { get { return new WorldPosition( 1.0f,  1.0f); } }

        public static WorldPosition Right  { get { return new WorldPosition( 1.0f,  0.0f); } }
        public static WorldPosition Left   { get { return new WorldPosition(-1.0f,  0.0f); } }
        public static WorldPosition Up     { get { return new WorldPosition( 0.0f,  1.0f); } }
        public static WorldPosition Down   { get { return new WorldPosition( 0.0f, -1.0f); } }

        public static WorldPosition operator +(WorldPosition left, WorldPosition right)
        {
            return new WorldPosition(left.X + right.X, left.Y + right.Y);
        }
        public static WorldPosition operator -(WorldPosition left, WorldPosition right)
        {
            return new WorldPosition(left.X - right.X, left.Y - right.Y);
        }
        public static WorldPosition operator *(WorldPosition left, WorldPosition right)
        {
            return new WorldPosition(left.X * right.X, left.Y * right.Y);
        }
        public static WorldPosition operator /(WorldPosition left, WorldPosition right)
        {
            return new WorldPosition(left.X / right.X, left.Y / right.Y);
        }

        public static WorldPosition operator *(WorldPosition position, float magnitude)
        {
            return new WorldPosition(position.X * magnitude, position.Y * magnitude);
        }
        public static WorldPosition operator /(WorldPosition position, float magnitude)
        {
            return new WorldPosition(position.X / magnitude, position.Y / magnitude);
        }

        public static explicit operator ScreenPosition(WorldPosition position)
        {
            float x = (Screen.Width  / 2.0f) + ((position.X - Viewport.Position.X) / Viewport.Scale);
            float y = (Screen.Height / 2.0f) - ((position.Y - Viewport.Position.Y) / Viewport.Scale);

            return new ScreenPosition(x, y);
        }

        public override string ToString()
        {
            return $"world({X}, {Y})";
        }
    }
}
