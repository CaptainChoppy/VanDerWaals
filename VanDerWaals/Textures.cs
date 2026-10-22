namespace VanDerWaals
{
    internal static class Textures
    {
        public static Texture Default = Resources.LoadTexture("default");

        public static void UnloadAllTextures()
        {
            Default.Dispose();
        }
    }
}
