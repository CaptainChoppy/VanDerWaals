using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Cursor
    {
        public static ScreenPosition Position
        {
            get
            {
                return (ScreenPosition)(Raylib.GetMousePosition());
            }
        }

        public static Vector2 PositionPercentage
        {
            get
            {
                return new Vector2(Position.X / Screen.Width, Position.Y / Screen.Height);
            }
        }
    }
}
