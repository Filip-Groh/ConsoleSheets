namespace ConsoleSheets {
    internal static class Display {
        public static int WindowWidth = 120;
        public static int WindowHeight = 30;

        public static int ActiveWindowIndex { get; private set; }
        public static Window ActiveWindow {
            get {
                return Windows[ActiveWindowIndex];
            }
        }
        public static List<Window> Windows = new List<Window>();

        static Display() {
            Windows.Add(new Window(true));
            SwitchWindow(0);
        }

        public static void SwitchWindow(int indexOfWindow) {
            ActiveWindow.IsActive = false;
            ActiveWindowIndex = indexOfWindow;
            ActiveWindow.IsActive = true;
            Console.Clear();
            Console.SetBufferSize(ActiveWindow.BufferWidth, ActiveWindow.BufferHeight);
        }

        public static void NextWindow() {
            int currentWindowIndex = Display.ActiveWindowIndex;
            int nextWindowIndex = currentWindowIndex + 1;
            int correctedWindowIndex = nextWindowIndex >= Display.Windows.Count ? 0 : nextWindowIndex;
            Display.SwitchWindow(correctedWindowIndex);
        }

        public static void Render() {
            Console.SetWindowSize(120, 30);
            ActiveWindow.Buffer.CopyToConsole();
            Console.SetCursorPosition(0, 0);
        }
    }
}
