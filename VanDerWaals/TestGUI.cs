using Raylib_cs;

namespace VanDerWaals
{
    internal class TestGUI : GUIElement
    {
        public TestGUI(Rectangle rect, Color colour) : base(rect, colour)
        {
            ColourTint = colour;
        }

        public override void MouseDown(GUIMouseEvent mouseevent)
        {
            ColourTint = new Color(0x00, 0x00, 0xFF);
        }

        public override void MouseHover(GUIMouseEvent mouseevent)
        {
            ColourTint = new Color(0xFF, 0x00, 0xFF);
        }

        public override void MousePress(GUIMouseEvent mouseevent)
        {
            ColourTint = new Color(0x00, 0xFF, 0x00);
            Debug.InfoLog("TEEHEE");
        }

        public override void MouseRelease(GUIMouseEvent mouseevent)
        {
            ColourTint = new Color(0xFF, 0x00, 0x00);
            Debug.InfoLog("TEEHEE2");
        }
    }
}
