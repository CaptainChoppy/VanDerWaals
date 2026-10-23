using Raylib_cs;
using System.Numerics;

namespace VanDerWaals
{
    internal static class Game
    {
        public static bool Running { get; private set; } = true;

        public static Random RNG = new Random(99);

        public static GUIText DebugText;

        private static string CreateDebugText()
        {
            return
                $"Cursor true position : {Cursor.TruePosition}\n" +
                $"Cursor position : {Cursor.Position}\n" +
                $"Cursor position percentage : {Cursor.PositionPercentage}\n" +
                $"Viewport Position : {Viewport.Position}\n" +
                $"Viewport Scale : {Viewport.Scale}\n" +
                $"Screen Scale : {Screen.Scale}\n" +
                $"Global Frame Time : {Time.GlobalFrameTime}\n" +
                $"Test GUI Button : {TestGUI.DebugTextButtonState}\n" +
                $"Test GUI Mouse  : {TestGUI.DebugTextMouseState}\n" +
                $"\n" +
                $"\n" +
                $"\n" +
                $"\n";
        }

        static Game()
        {
            Raylib.SetTraceLogLevel(TraceLogLevel.Warning);

            Renderer.CreateWindow();

            DebugText = new GUIText(new Rectangle(Vector2.Zero, Vector2.Zero), new Color(0xFF, 0x00, 0x00), Fonts.Test, "hello", 25.0f);

            TestGUI testgui = new TestGUI(new Rectangle(10, 10, 16, 16), Color.Black);
            TestGameObject testgameobject = new TestGameObject();

            while (Running == true)
            {
                Update();
            }

            Renderer.CloseWindow();
        }

        public static void Start() { }

        public static void Update()
        {
            DebugText.Text = CreateDebugText();

            Inputs.Update();
            ObjectRegistry.Update();
            GUI.Update();

            Renderer.Draw();

            if (Inputs.KeyPressed(VKeyCodes.OEMEquals))
            {
                Screen.Scale *= 2;
            }

            if (Inputs.KeyPressed(VKeyCodes.OEMMinus))
            {
                Screen.Scale /= 2;
            }

            if (Inputs.KeyDown(VKeyCodes.Escape))
            {
                Quit();
            }

            Time.Update();

            Running = Running && (Raylib.WindowShouldClose() == false);
        }

        public static void Quit()
        {
            Running = false;
            Fonts.UnloadAllFonts();
            Debug.CreateLogFile();
            Renderer.CloseWindow();
        }
    }
}
