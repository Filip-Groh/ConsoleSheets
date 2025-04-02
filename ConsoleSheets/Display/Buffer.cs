using System.Text;

namespace ConsoleSheets {
    internal class DisplayBuffer {
        MemoryStream Stream;
        StreamWriter StreamWriter;
        StreamReader StreamReader;

        public DisplayBuffer() {
            Stream = new MemoryStream();
            StreamWriter = new StreamWriter(Stream, Encoding.UTF8);
            StreamReader = new StreamReader(Stream, Encoding.UTF8);
        }

        public void CopyToConsole() {
            Stream consoleStream = Console.OpenStandardOutput();
            Stream.Position = 3;
            Stream.CopyTo(consoleStream);
            consoleStream.Flush();
        }

        public void Write(string value) {
            StreamWriter.Write(value);
            StreamWriter.Flush();
        }
    }
}
