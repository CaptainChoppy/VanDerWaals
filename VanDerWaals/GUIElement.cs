using Raylib_cs;

namespace VanDerWaals
{
    internal abstract class GUIElement
    {
        public Rectangle Rectangle;

        public Color ColourTint;

        public GUIElement(Rectangle rect, Color colour)
        {
            GUI.AddElement(this);

            ColourTint = colour;
            Rectangle = rect;
        }

        public virtual void Draw()
        {
            Renderer.DrawRectangle(Rectangle, ColourTint);
        }

        public virtual void Update() { }

        public virtual void MouseDown(GUIMouseEvent mouseevent) { }
        public virtual void MouseHover(GUIMouseEvent mouseevent) { }
        public virtual void MouseEnter(GUIMouseEvent mouseevent) { }
        public virtual void MouseExit(GUIMouseEvent mouseevent) { }
        public virtual void MousePress(GUIMouseEvent mouseevent) { }
        public virtual void MouseRelease(GUIMouseEvent mouseevent) { }
    
        public void Destroy()
        {
            GUI.RemoveElement(this);
        }
    
        public static bool IsPositionInsideRectange(ScreenPosition position, Rectangle rect)
        {
            return position.X > rect.X && position.Y > rect.Y && position.X <= rect.X + rect.Size.X && position.Y <= rect.Y + rect.Size.Y;
        }
    }

    internal class GUIText : GUIElement
    {
        public string Text;
        public FontSlot Font;

        public float FontSize;

        public GUIText(Rectangle rect, Color colour, FontSlot font, string text, float fontsize) : base(rect, colour)
        {
            Text = text;
            Font = font;
            FontSize = fontsize;
        }

        public override void Draw()
        {
            Renderer.DrawText(Font, Text, Rectangle.Position, FontSize, ColourTint);
        }
    }
}
