using System;

namespace AdventOfCode.Day8
{
    public class RectCommand : ICommand
    {
        private readonly int width;
        private readonly int height;

        public RectCommand(string command)
        {
            if (!command.StartsWith("rect "))
                throw new ArgumentException();

            var size = command.Split(' ')[1];
            var dimensions = size.Split('x');

            width = Convert.ToInt32(dimensions[0]);
            height = Convert.ToInt32(dimensions[1]);
        }

        public bool[][] Execute(bool[][] currentDisplay)
        {
            for (var row = 0; row < height; row++)
            {
                for (var column = 0; column < width; column++)
                {
                    currentDisplay[row][column] = true;
                }
            }

            return currentDisplay;
        }
    }
}
