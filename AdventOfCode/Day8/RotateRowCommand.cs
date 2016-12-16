using System;

namespace AdventOfCode.Day8
{
    public class RotateRowCommand : ICommand
    {
        private readonly int row;
        private readonly int amount;

        public RotateRowCommand(string command)
        {
            if (!command.StartsWith("rotate row "))
                throw new ArgumentException();

            var sections = command.Split('=');
            sections = sections[1].Split(' ');
            row = Convert.ToInt32(sections[0]);
            amount = Convert.ToInt32(sections[2]);
        }

        public bool[][] Execute(bool[][] currentDisplay)
        {
            var newRow = new bool[currentDisplay[0].Length];

            for (var column = 0; column < currentDisplay[0].Length; column++)
            {
                var newRowIndex = (column + amount) % newRow.Length;
                newRow[newRowIndex] = currentDisplay[row][column];
            }

            currentDisplay[row] = newRow;

            return currentDisplay;
        }
    }
}
