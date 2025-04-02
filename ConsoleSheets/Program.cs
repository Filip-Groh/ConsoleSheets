namespace ConsoleSheets {
    internal class Program {
        static void Main(string[] args) {
            Display.Windows.Add(new Window(false, 400, 400, 0, 0));
            Controller.Run();
        }
    }
}
