namespace VanDerWaals
{
    internal abstract class GUIEvent
    {
    }

    internal sealed class GUIMouseEvent : GUIEvent
    {
        public readonly MouseButtons MouseButton;
        public readonly KeyState MouseButtonState;
        public readonly ScreenPosition CursorPosition;

        public bool MouseDown => ((MouseButtonState == KeyState.Down) || (MouseButtonState == KeyState.Pressed));

        public GUIMouseEvent() : base()
        {
            MouseButton = Inputs.GetMouseButton();
            MouseButtonState = Inputs.GetMouseState(MouseButton);
            CursorPosition = Cursor.TruePosition;
        }

        public override string ToString()
        {
            return $"MouseEvents (MouseButton:{MouseButton}, MouseButtonState:{MouseButtonState}, CursorPosition:{CursorPosition})";
        }
    }
}
