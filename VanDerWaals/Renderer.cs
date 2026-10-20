using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Renderer
    {
        public const int DefaultScreenWidth = 800;
        public const int DefaultScreenHeight = 600;

        public static void CreateWindow()
        {
            Raylib.SetConfigFlags(ConfigFlags.AlwaysRunWindow | ConfigFlags.ResizableWindow);
            Raylib.SetTargetFPS(45);
            Raylib.InitWindow(DefaultScreenWidth, DefaultScreenHeight, "VanDerWaals");
        }

        public static void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public static void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(new Color(0xB6, 0xA2, 0xFF));

            ObjectRegistry.DrawObjects();

            GUI.Draw();

            Raylib.EndDrawing();
        }

        public static void DrawGameObject(GameObject gameobject)
        {
            DrawTexture(Textures.Test, gameobject.Position, gameobject.Size);
        }

        public static void DrawTexture(Texture texture, WorldPosition position, Vector2 size)
        {
            ScreenPosition screenposition = (ScreenPosition)(position + WorldPosition.Up * size.Y);

            Rectangle texturerectangle = new Rectangle(Vector2.Zero, texture.Size);

            Rectangle screenrectangle = new Rectangle((Vector2)(screenposition), size / Viewport.Scale);

            Raylib.DrawTexturePro(texture.GetTexture(), texturerectangle, screenrectangle, Vector2.Zero, 0, Color.White);
        }

        public static void DrawText(FontSlot font, string text, Vector2 position, float fontsize, Color colour)
        {
            Raylib.DrawTextPro(font.GetFont(), text, position, Vector2.Zero, 0, fontsize, 0, colour);
        }

        public static void DrawRectangle(Rectangle rect, Color colour)
        {
            Raylib.DrawRectanglePro(rect, Vector2.Zero, 0, colour);
        }
    }
}
