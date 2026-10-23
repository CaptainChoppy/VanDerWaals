using Raylib_cs;
using System.Diagnostics;

namespace VanDerWaals
{
    internal class TestGUI : GUIElement
    {
        public static string DebugTextMouseState = "";
        public static string DebugTextButtonState = "";

        public TestGUI(Rectangle rect, Color colour) : base(rect, colour)
        {
            ColourTint = colour;
        }

        public override void MouseDown()
        {
            DebugTextButtonState = "Down";
        }

        public override void MouseRelease()
        {
            DebugTextButtonState = "Release";
        }

        public override void MousePress()
        {
            DebugTextButtonState = "Press";
        }

        public override void MouseEnter()
        {
            DebugTextMouseState = "Enter";
        }

        public override void MouseHover()
        {
            DebugTextMouseState = "Hover";
        }

        public override void MouseExit()
        {
            DebugTextMouseState = "Exit";
        }

        public override void MouseOut()
        {
            DebugTextMouseState = "Out";
        }
    }
}
