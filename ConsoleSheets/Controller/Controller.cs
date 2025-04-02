namespace ConsoleSheets {
    delegate void KeyMappingFunction();
    public enum Mode {
        Normal,
        Insert
    }

    public static class Controller {
        public static Mode Mode = Mode.Normal;

        static Dictionary<(Mode, string), KeyMappingFunction> Mapping = new Dictionary<(Mode, string), KeyMappingFunction>();

        static Controller() {
            Mapping.Add((Mode.Normal, "i"), () => Mode = Mode.Insert);
            Mapping.Add((Mode.Insert, "<Esc>"), () => Mode = Mode.Normal);

            Mapping.Add((Mode.Normal, "h"), () => Display.ActiveWindow.MoveHorizontal(-1));
            Mapping.Add((Mode.Normal, "j"), () => Display.ActiveWindow.MoveVertical(1));
            Mapping.Add((Mode.Normal, "k"), () => Display.ActiveWindow.MoveVertical(-1));
            Mapping.Add((Mode.Normal, "l"), () => Display.ActiveWindow.MoveHorizontal(1));

            Mapping.Add((Mode.Normal, "<Space>"), () => Display.NextWindow());
        }

        public static void Run() {
            while (true) {
                ReadInput();
                Display.Render();
            }
        }

        static void ReadInput() {
            ConsoleKeyInfo key = Console.ReadKey(true);
            string keyRepresentation = "";
            switch (key.Key) {
                case ConsoleKey.Escape: {
                    keyRepresentation += "<Esc>";
                    break;
                }
                case ConsoleKey.Spacebar: {
                    keyRepresentation += "<Space>";
                    break;
                }
                default: {
                    keyRepresentation += key.KeyChar;
                    break;
                }
            }
            bool validMapping = Mapping.TryGetValue((Mode, keyRepresentation), out KeyMappingFunction? keyMappingFunction);
            if (validMapping && keyMappingFunction is not null) {
                keyMappingFunction.Invoke();
                return;
            }
            if (Mode == Mode.Insert) {
                Display.ActiveWindow.Buffer.Write(key.KeyChar.ToString());
            }
        }
    }
}
