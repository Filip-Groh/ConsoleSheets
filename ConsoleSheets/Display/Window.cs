namespace ConsoleSheets {
    internal class Window {
        public bool IsActive;
        public int BufferWidth;
        public int BufferHeight;
        public int BufferOffsetX;
        public int BufferOffsetY;

        public DisplayBuffer Buffer;

        public Window(bool isActive, int bufferWidth = 120, int bufferHeight = 30, int bufferOffsetX = 0, int bufferOffsetY = 0) {
            Buffer = new DisplayBuffer();
            IsActive = isActive;
            BufferWidth = bufferWidth;
            BufferHeight = bufferHeight;
            BufferOffsetX = bufferOffsetX;
            BufferOffsetY = bufferOffsetY;
        }

        public void MoveHorizontal(int amount) {
            if (!IsActive)
                return;

            int currentX = Console.WindowLeft;
            int newX = currentX + amount;
            int minimum = 0;
            int maximum = Console.BufferWidth - Console.WindowWidth;
            int clamped = Math.Clamp(newX, minimum, maximum);
            Console.WindowLeft = clamped;
        }

        public void MoveVertical(int amount) {
            if (!IsActive)
                return;

            int currentY = Console.WindowTop;
            int newY = currentY + amount;
            int minimum = 0;
            int maximum = Console.BufferHeight - Console.WindowHeight;
            int clamped = Math.Clamp(newY, minimum, maximum);
            Console.WindowTop = clamped;
        }
    }
}
