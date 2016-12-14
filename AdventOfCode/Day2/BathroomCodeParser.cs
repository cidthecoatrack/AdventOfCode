using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class BathroomCodeParser
    {
        public string ParseBathroomCode(string input)
        {
            var keypad = new[]
            {
                new[] { "", "", "", "", "" },
                new[] { "", "1", "2", "3", "" },
                new[] { "", "4", "5", "6", "" },
                new[] { "", "7", "8", "9", "" },
                new[] { "", "", "", "", "" },
            };

            var start = new Point(2, 2);
            var code = GetCode(keypad, start, input);

            return code;
        }

        private string GetCode(string[][] keypad, Point startingPosition, string input)
        {
            var code = string.Empty;
            var position = new Point(startingPosition.X, startingPosition.Y);
            var instructions = input.Split('\n', '\r').Where(i => !string.IsNullOrWhiteSpace(i));

            foreach (var instruction in instructions)
            {
                foreach (var direction in instruction)
                    position = GetNewPosition(position, direction, keypad);

                code += keypad[position.Y][position.X];
            }

            return code;
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

            var start = new Point(1, 3);
            var code = GetCode(keypad, start, input);

            return code;
        }

        private Point GetNewPosition(Point position, char direction, string[][] keypad)
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
