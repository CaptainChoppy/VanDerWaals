using Raylib_cs;

namespace VanDerWaals
{
    internal static class Resources
    {
        public const string TextureFileExtention = ".png";
        public const string SoundFileExtention = ".wav";
        public const string FontFileExtention = ".ttf";
        public const string TextFileExtention = ".txt";

        public static readonly string WorkingDirectory;
        public static string LogsDirectory => Path.Combine(WorkingDirectory, "logs\\");
        public static string ResourcesDirectory => Path.Combine(WorkingDirectory, "resources\\");

        public static string TextruresDirectory => Path.Combine(ResourcesDirectory, "textures\\");
        public static string GetTexturePath(string texturename)
        {
            return Path.Combine(TextruresDirectory, texturename + TextureFileExtention);
        }

        public static string SoundsDirectory => Path.Combine(ResourcesDirectory, "sounds\\");
        public static string GetSoundPath(string soundname)
        {
            return Path.Combine(SoundsDirectory, soundname + SoundFileExtention);
        }

        public static string FontsDirectory => Path.Combine(ResourcesDirectory, "fonts\\");
        public static string GetFontPath(string fontnames)
        {
            return Path.Combine(FontsDirectory, fontnames + FontFileExtention);
        }

        static Resources()
        {
            WorkingDirectory = Raylib.GetWorkingDirectoryAsString();
        }

        public static Texture LoadTexture(string name)
        {
            return new Texture(GetTexturePath(name));
        }

        public static FontSlot LoadFont(string name)
        {
            return new FontSlot(GetFontPath(name));
        }
    }
}
