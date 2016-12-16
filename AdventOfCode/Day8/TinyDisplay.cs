using System;

namespace AdventOfCode.Day8
{
    public class TinyDisplay
    {
        private readonly int height;
        private readonly int width;

        public TinyDisplay(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public bool[][] LightDisplay(params string[] commands)
        {
            var display = InitializeDisplay();

            foreach (var commandText in commands)
            {
                var command = GetCommand(commandText);
                display = command.Execute(display);
            }

            return display;
        }

        private ICommand GetCommand(string command)
        {
            if (command.StartsWith("rect "))
                return new RectCommand(command);

            if (command.StartsWith("rotate column "))
                return new RotateColumnCommand(command);

            if (command.StartsWith("rotate row "))
                return new RotateRowCommand(command);

            throw new ArgumentException();
        }

        private bool[][] InitializeDisplay()
        {
            var display = new bool[height][];
            for (var i = 0; i < height; i++)
                display[i] = new bool[width];

            return display;
        }
    }
}
