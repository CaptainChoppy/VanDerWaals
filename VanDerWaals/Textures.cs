namespace VanDerWaals
{
    internal static class Textures
    {
        public static Texture Test = Resources.LoadTexture("test");

        public static void UnloadAllTextures()
        {
            Test.Dispose();
        }
    }
}
