namespace VanDerWaals
{
    internal abstract class GUIEvent
    {
    }

    internal sealed class GUIMouseEvent : GUIEvent
    {
        private static GUIMouseEvent PreviousFrameEvents = new GUIMouseEvent(MouseButtons.None, KeyState.Up, ScreenPosition.Zero);

        public readonly MouseButtons MouseButton;
        public readonly KeyState MouseButtonState;
        public readonly ScreenPosition CursorPosition;

        public bool MouseDown => ((MouseButtonState == KeyState.Down) || (MouseButtonState == KeyState.Pressed));

        public GUIMouseEvent() : base()
        {
            MouseButton = Inputs.GetMouseButton();

            if(MouseButton == MouseButtons.None && PreviousFrameEvents.MouseButtonState == KeyState.Down)
            {
                MouseButton = PreviousFrameEvents.MouseButton;
            }

            MouseButtonState = Inputs.GetMouseButtonState(MouseButton);
            CursorPosition = Cursor.Position;

            PreviousFrameEvents = this;
        }

        private GUIMouseEvent(MouseButtons mousebutton, KeyState mousebuttonstate, ScreenPosition cursorposition)
        {
            MouseButton = mousebutton;
            MouseButtonState = mousebuttonstate;
            CursorPosition = cursorposition;
        }

        public override string ToString()
        {
            return $"MouseEvents (MouseButton:{MouseButton}, MouseButtonState:{MouseButtonState}, CursorPosition:{CursorPosition})";
        }
    }
}
