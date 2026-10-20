using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Screen
    {
        public static uint Width
        { 
            get
            {
                return (uint)(Raylib.GetScreenWidth());
            }
        }

        public static uint Height 
        { 
            get
            {
                return (uint)(Raylib.GetScreenHeight());
            }
        }

        public static Vector2 Dimentions
        {
            get
            {
                return new Vector2(Width, Height);
            }
        }

        public static void SetScreenSize(uint width, uint height)
        {
            Raylib.SetWindowSize((int)(width), (int)(height));
        }
    }
}
