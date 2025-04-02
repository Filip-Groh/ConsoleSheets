using System.Text;

namespace Testing {
    internal class Program {
        static void Main(string[] args) {
            Console.SetBufferSize(120, 30);
            Console.SetWindowSize(120, 30);

            string selected = "a";

            MemoryStream aStream = new MemoryStream();
            StreamWriter aWriter = new StreamWriter(aStream, Encoding.UTF8);
            StreamReader aReader = new StreamReader(aStream, Encoding.UTF8);

            MemoryStream bStream = new MemoryStream();
            StreamWriter bWriter = new StreamWriter(bStream, Encoding.UTF8);
            StreamReader bReader = new StreamReader(bStream, Encoding.UTF8);

            aStream.Position = 0;
            aWriter.WriteLine("Hello from A!");
            aWriter.Flush();
            aStream.Position = 0;

            bStream.Position = 0;
            bWriter.WriteLine("Hello from B!");
            bWriter.Flush();
            bStream.Position = 0;

            aStream.Position = 3;
            aStream.CopyTo(Console.OpenStandardOutput());
            Console.OpenStandardOutput().Flush();
            Console.SetCursorPosition(0, 0);
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key) {
                    case ConsoleKey.H: {
                        MoveHorizontal(-1);
                        break;
                    }
                    case ConsoleKey.J: {
                        MoveVertical(1);
                        break;
                    }
                    case ConsoleKey.K: {
                        MoveVertical(-1);
                        break;
                    }
                    case ConsoleKey.L: {
                        MoveHorizontal(1);
                        break;
                    }
                    case ConsoleKey.Spacebar: {
                        if (selected == "a") {
                            bStream.Position = 3;
                            bStream.CopyTo(Console.OpenStandardOutput());
                            Console.OpenStandardOutput().Flush();
                            Console.SetCursorPosition(0, 0);
                            selected = "b";
                        } else {
                            aStream.Position = 3;
                            aStream.CopyTo(Console.OpenStandardOutput());
                            Console.OpenStandardOutput().Flush();
                            Console.SetCursorPosition(0, 0);
                            selected = "a";
                        }
                        break;
                    }
                }
            }
        }

        static void MoveHorizontal(int amount) {
            int currentX = Console.WindowLeft;
            int newX = currentX + amount;
            int minimum = 0;
            int maximum = Console.BufferWidth - Console.WindowWidth;
            int clamped = Math.Clamp(newX, minimum, maximum);
            Console.WindowLeft = clamped;
        }

        static void MoveVertical(int amount) {
            int currentY = Console.WindowTop;
            int newY = currentY + amount;
            int minimum = 0;
            int maximum = Console.BufferHeight - Console.WindowHeight;
            int clamped = Math.Clamp(newY, minimum, maximum);
            Console.WindowTop = clamped;
        }
    }
}
