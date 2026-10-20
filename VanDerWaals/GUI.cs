
namespace VanDerWaals
{
    internal static class GUI
    {
        public static List<GUIElementTracker> GUIElements = new List<GUIElementTracker>();

        public static GUIMouseEvent CurrentMouseEvents = new GUIMouseEvent();

        public static void Update()
        {
            CurrentMouseEvents = new GUIMouseEvent();

            foreach (GUIElementTracker element in GUIElements)
            {
                element.Element.Update();

                bool mouseinsiderect = GUIElement.IsPositionInsideRectange(CurrentMouseEvents.CursorPosition, element.Element.Rectangle);

                if(mouseinsiderect == false)
                {
                    continue;
                }

                switch (CurrentMouseEvents.MouseButtonState)
                {
                    case KeyState.Down:
                        element.Element.MouseDown(CurrentMouseEvents);
                        break;
                    case KeyState.Up:
                        element.Element.MouseHover(CurrentMouseEvents);
                        break;
                    case KeyState.Pressed:
                        element.Element.MousePress(CurrentMouseEvents);
                        break;
                    case KeyState.Released:
                        element.Element.MouseRelease(CurrentMouseEvents);
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

        public GUIElementState State;

        public GUIElementTracker(GUIElement element)
        {
            Element = element;
        }
    }

    internal enum GUIElementState
    {
        Enter = 0,
        Hover,
        Exit
    }
}
