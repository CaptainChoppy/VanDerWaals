using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Renderer
    {
        public const int FrameRate = 40;

        public static float GUISizeScalar => Screen.Scale;
        private static float ObjectScreenSizeScalar => Screen.Scale / Viewport.Scale;

        private const string WindowTitle = "VanDerWaals";

        private static readonly RenderTexture2D RenderTexture = new RenderTexture2D();

        public static void CreateWindow()
        {
            Raylib.SetConfigFlags(ConfigFlags.AlwaysRunWindow);
            
            if(FrameRate != 0)
            {
                Raylib.SetTargetFPS(FrameRate);
            }

            Raylib.InitWindow(Screen.ReferenceScreenWidth, Screen.ReferenceScreenHeight, WindowTitle);
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
            DrawTexture(Textures.Default, gameobject.Position, gameobject.Size);
        }

        public static void DrawTexture(Texture texture, WorldPosition position, Vector2 size)
        {
            ScreenPosition screenposition = (ScreenPosition)(position + WorldPosition.Up * size.Y);

            Rectangle texturerectangle = new Rectangle(Vector2.Zero, texture.Size);

            Rectangle screenrectangle = new Rectangle((Vector2)(screenposition), size * ObjectScreenSizeScalar);

            Raylib.DrawTexturePro(texture.GetTexture(), texturerectangle, screenrectangle, Vector2.Zero, 0, Color.White);
        }

        public static void DrawText(FontSlot font, string text, Vector2 position, float fontsize, Color colour)
        {
            Raylib.DrawTextPro(font.GetFont(), text, position * GUISizeScalar, Vector2.Zero, 0.0f, fontsize * GUISizeScalar, 1.0f * GUISizeScalar, colour);
        }

        public static void DrawRectangle(Rectangle rect, Color colour)
        {
            Rectangle screenrectangle = new Rectangle(rect.Position * GUISizeScalar, rect.Size * GUISizeScalar);

            Raylib.DrawRectanglePro(screenrectangle, Vector2.Zero, 0, colour);
        }
    }
}
