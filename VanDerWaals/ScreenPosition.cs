using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal struct ScreenPosition
    {
        public float X;
        public float Y;

        public ScreenPosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        public ScreenPosition(Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public static ScreenPosition Zero  { get { return new ScreenPosition( 0.0f,  0.0f); } }
        public static ScreenPosition One   { get { return new ScreenPosition( 1.0f,  1.0f); } }

        public static ScreenPosition Right { get { return new ScreenPosition( 1.0f,  0.0f); } }
        public static ScreenPosition Left  { get { return new ScreenPosition(-1.0f,  0.0f); } }
        public static ScreenPosition Up    { get { return new ScreenPosition( 0.0f,  1.0f); } }
        public static ScreenPosition Down  { get { return new ScreenPosition( 0.0f, -1.0f); } }

        public static ScreenPosition operator +(ScreenPosition left, ScreenPosition right)
        {
            return new ScreenPosition(left.X + right.X, left.Y + right.Y);
        }
        public static ScreenPosition operator -(ScreenPosition left, ScreenPosition right)
        {
            return new ScreenPosition(left.X - right.X, left.Y - right.Y);
        }
        public static ScreenPosition operator *(ScreenPosition left, ScreenPosition right)
        {
            return new ScreenPosition(left.X * right.X, left.Y * right.Y);
        }
        public static ScreenPosition operator /(ScreenPosition left, ScreenPosition right)
        {
            return new ScreenPosition(left.X / right.X, left.Y / right.Y);
        }

        public static ScreenPosition operator *(ScreenPosition position, float magnitude)
        {
            return new ScreenPosition(position.X * magnitude, position.Y * magnitude);
        }
        public static ScreenPosition operator /(ScreenPosition position, float magnitude)
        {
            return new ScreenPosition(position.X / magnitude, position.Y / magnitude);
        }

        public static explicit operator Vector2(ScreenPosition position)
        {
            return new Vector2(position.X, position.Y);
        }

        public static explicit operator ScreenPosition(Vector2 position)
        {
            return new ScreenPosition(position.X, position.Y);
        }

        public static explicit operator WorldPosition(ScreenPosition position)
        {
            float x =  ((position.X * Viewport.Scale) + Viewport.Position.X - (Screen.ReferenceScreenWidth  / 2.0f));
            float y = -((position.Y * Viewport.Scale) + Viewport.Position.Y - (Screen.ReferenceScreenHeight / 2.0f));

            return new WorldPosition(x, y);
        }

        public override string ToString()
        {
            return $"screen({X}, {Y})";
        }
    }
}
