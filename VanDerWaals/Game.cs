using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Game
    {
        public static bool Running { get; private set; } = true;

        public static Random RNG = new Random(99);

        public static GUIText DebugText;

        static Game()
        {
            Raylib.SetTraceLogLevel(TraceLogLevel.Warning);

            Renderer.CreateWindow();

            TestGUI test = new TestGUI(new Rectangle(Vector2.One * 10, 50, 100), new Color(0xFF, 0x00, 0xFF, 0xFF));
            DebugText = new GUIText(new Rectangle(Vector2.Zero, Vector2.Zero), new Color(0xFF, 0x00, 0x00), Fonts.Test, "hello", 25.0f);
            
            while (Running == true)
            {
                Update();
            }

            Renderer.CloseWindow();
        }

        public static void Start() { }

        public static void Update()
        {
            DebugText.Text =
                $"Cursor position : {Cursor.Position}\n" +
                $"Viewport Position : {Viewport.Position}\n" +
                $"Viewport Scale : {Viewport.Scale}\n" +
                $"\n" +
                $"\n" +
                $"\n" +
                $"\n" +
                $"\n" +
                $"\n" +
                $"\n" +
                $"\n";


            Inputs.Update();
            ObjectRegistry.Update();
            GUI.Update();

            Renderer.Draw();

            if (Inputs.KeyDown(VKeyCodes.Escape))
            {
                Quit();
            }

            Running = Running && (Raylib.WindowShouldClose() == false);
        }

        public static void Quit()
        {
            Running = false;
            Debug.CreateLogFile();
        }
    }
}
