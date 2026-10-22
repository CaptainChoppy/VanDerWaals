using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Screen
    {
        public const int ReferenceScreenWidth = 800;
        public const int ReferenceScreenHeight = 600;

        public static uint Width
        { 
            get
            {
                return (uint)(ReferenceScreenWidth * Scale);
            }
        }

        public static uint Height 
        { 
            get
            {
                return (uint)(ReferenceScreenHeight * Scale);
            }
        }

        public static float Scale
        {
            get;
            set
            {
                Raylib.SetWindowSize((int)(ReferenceScreenWidth * value), (int)(ReferenceScreenHeight * value));

                field = value;
            }
        } = 1.0f;

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
