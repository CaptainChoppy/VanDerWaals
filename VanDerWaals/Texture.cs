using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal sealed class Texture : IDisposable
    {
        private readonly Texture2D SourceTexture;

        public readonly uint Width;
        public readonly uint Height;

        public readonly Vector2 Size;

        public Texture(string sourcepath)
        {
            SourceTexture = Raylib.LoadTexture(sourcepath);

            Width = (uint)(SourceTexture.Width);
            Height = (uint)(SourceTexture.Height); 
            Size = new Vector2(Width, Height);
        }

        public Texture2D GetTexture()
        {
            return SourceTexture;
        }

        public void Dispose()
        {
            Raylib.UnloadTexture(SourceTexture);

            GC.SuppressFinalize(this);
        }
    }
}
