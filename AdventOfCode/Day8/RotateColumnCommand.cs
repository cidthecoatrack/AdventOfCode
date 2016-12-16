using System;

namespace AdventOfCode.Day8
{
    public class RotateColumnCommand : ICommand
    {
        private readonly int column;
        private readonly int amount;

        public RotateColumnCommand(string command)
        {
            if (!command.StartsWith("rotate column "))
                throw new ArgumentException();

            var sections = command.Split('=');
            sections = sections[1].Split(' ');
            column = Convert.ToInt32(sections[0]);
            amount = Convert.ToInt32(sections[2]);
        }

        public bool[][] Execute(bool[][] currentDisplay)
        {
            var newColumn = new bool[currentDisplay.Length];

            for (var i = 0; i < currentDisplay.Length; i++)
            {
                var newColumnIndex = (i + amount) % currentDisplay.Length;
                newColumn[newColumnIndex] = currentDisplay[i][column];
            }

            for (var i = 0; i < currentDisplay.Length; i++)
            {
                currentDisplay[i][column] = newColumn[i];
            }

            return currentDisplay;
        }
    }
}
