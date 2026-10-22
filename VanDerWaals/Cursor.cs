using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Cursor
    {
        public static Vector2 TruePosition
        {
            get
            {
                return Raylib.GetMousePosition();
            }
        }

        public static ScreenPosition Position
        {
            get
            {
                return new ScreenPosition(TruePosition.X / Screen.Scale, TruePosition.Y / Screen.Scale);
            }
        }

        public static Vector2 PositionPercentage
        {
            get
            {
                return new Vector2(Position.X / Screen.ReferenceScreenWidth, Position.Y / Screen.ReferenceScreenHeight);
            }
        }
    }
}
