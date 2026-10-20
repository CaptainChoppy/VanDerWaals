using Raylib_cs;

namespace VanDerWaals
{
    internal sealed class FontSlot : IDisposable
    {
        private readonly Font SourceFont;

        public FontSlot(string sourcepath)
        {
            SourceFont = Raylib.LoadFont(sourcepath);
        }

        public Font GetFont()
        {
            return SourceFont;
        }

        public void Dispose()
        {
            Raylib.UnloadFont(SourceFont);

            GC.SuppressFinalize(this);
        }
    }
}
