using Raylib_cs;

namespace VanDerWaals
{
    internal static class Fonts
    {
        public static FontSlot Test = Resources.LoadFont("comic");

        public static void UnloadAllFonts()
        {
            Test.Dispose();
        }
    }
}
