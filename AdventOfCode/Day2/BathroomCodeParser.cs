using System;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class BathroomCodeParser
    {
        public int ParseBathroomCode(string input)
        {
            var keypad = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
            };

            var code = string.Empty;
            var position = new Point(1, 1);
            var instructions = input.Split('\n', '\r');

            foreach (var instruction in instructions)
            {
                foreach (var direction in instruction)
                {
                    switch (direction)
                    {
                        case 'U': position.Y = Math.Max(position.Y - 1, 0); break;
                        case 'L': position.X = Math.Max(position.X - 1, 0); break;
                        case 'D': position.Y = Math.Min(position.Y + 1, 2); break;
                        case 'R': position.X = Math.Min(position.X + 1, 2); break;
                        default: throw new Exception("dum dum messed up");
                    }
                }

                if (instruction.Any())
                    code += keypad[position.Y][position.X].ToString();
            }

            return Convert.ToInt32(code);
        }

        public string ParseFancyBathroomCode(string input)
        {
            var keypad = new[]
            {
                new[] { "", "", "", "", "", "", "" },
                new[] { "", "", "", "1", "", "", "" },
                new[] { "", "", "2", "3", "4", "", "" },
                new[] { "", "5", "6", "7", "8", "9", "" },
                new[] { "", "", "A", "B", "C", "", "" },
                new[] { "", "", "", "D", "", "", "" },
                new[] { "", "", "", "", "", "", "" },
            };

            var code = string.Empty;
            var position = new Point(1, 3);
            var instructions = input.Split('\n', '\r');

            foreach (var instruction in instructions)
            {
                foreach (var direction in instruction)
                {
                    position = GetNewFancyPosition(position, direction, keypad);
                }

                if (instruction.Any())
                    code += keypad[position.Y][position.X];
            }

            return code;
        }

        private Point GetNewFancyPosition(Point position, char direction, string[][] keypad)
        {
            var newPoint = new Point(position.X, position.Y);

            switch (direction)
            {
                case 'U': newPoint.Y -= 1; break;
                case 'L': newPoint.X -= 1; break;
                case 'D': newPoint.Y += 1; break;
                case 'R': newPoint.X += 1; break;
                default: return position;
            }

            if (string.IsNullOrEmpty(keypad[newPoint.Y][newPoint.X]))
                return position;

            return newPoint;
        }
    }
}
