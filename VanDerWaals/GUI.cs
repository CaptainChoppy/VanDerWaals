using System.Numerics;

namespace VanDerWaals
{
    internal static class GUI
    {
        public static List<GUIElementTracker> GUIElements = new List<GUIElementTracker>();

        public static GUIMouseEvent CurrentMouseEvents { get; private set; } = new GUIMouseEvent();

        public static void Update()
        {
            CurrentMouseEvents = new GUIMouseEvent();

            foreach (GUIElementTracker element in GUIElements)
            {
                element.Element.Update();

                Vector2 rectposition = element.Element.Rectangle.Position * Renderer.GUISizeScalar;
                Vector2 sizescale = element.Element.Rectangle.Size * Renderer.GUISizeScalar;

                Raylib_cs.Rectangle scaledrectangle = new Raylib_cs.Rectangle(rectposition, sizescale);

                bool mouseinsiderect = GUIElement.IsPositionInsideRectange(CurrentMouseEvents.CursorPosition, scaledrectangle);

                if(mouseinsiderect == false)
                {
                    element.Element.MouseOut();
                    continue;
                }

                switch (element.CursorState)
                {
                    case GUIElementCursorState.Enter:
                        element.SetCursorState(GUIElementCursorState.Hover);
                        element.Element.MouseEnter();
                        break;
                    case GUIElementCursorState.Hover:
                        element.SetCursorState(GUIElementCursorState.Hover);
                        element.Element.MouseHover();
                        break;
                    case GUIElementCursorState.Exit:
                        element.SetCursorState(GUIElementCursorState.Enter);
                        element.Element.MouseExit();
                        break;
                    case GUIElementCursorState.Out:
                        element.SetCursorState(GUIElementCursorState.Enter);
                        element.Element.MouseOut();
                        break;
                    default:
                        break;
                }

                switch (CurrentMouseEvents.MouseButtonState)
                {
                    case KeyState.Down:
                        element.Element.MouseDown();
                        break;
                    case KeyState.Up:
                        element.Element.MouseHover();
                        break;
                    case KeyState.Pressed:
                            element.Element.MousePress();
                        break;
                    case KeyState.Released:
                        element.Element.MouseRelease();
                        break;
                }
            }
        }

        public static void Draw()
        {
            foreach(GUIElementTracker element in GUIElements)
            {
                element.Element.Draw();
            }
        }

        public static void AddElement(GUIElement element)
        {
            GUIElements.Add(new GUIElementTracker(element));
        }

        public static void RemoveElement(GUIElement element)
        {
            GUIElements.Remove(new GUIElementTracker(element));
        }
    }

    internal record struct GUIElementTracker
    {
        public readonly GUIElement Element;

        public GUIElementCursorState CursorState { get; private set; } = GUIElementCursorState.Out;

        public GUIElementTracker(GUIElement element)
        {
            Element = element;
        }

        public void SetCursorState(GUIElementCursorState state)
        {
            CursorState = state;
        }
    }

    internal enum GUIElementCursorState
    {
        Enter = 0,
        Hover,
        Exit,
        Out
    }
}
