using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day1
{
    public class DistanceParser
    {
        private enum DIRECTION { NORTH, EAST, SOUTH, WEST };

        public Point GetFinalCoordinate(string input)
        {
            var point = new Point(0, 0);
            var inputs = input.Split(',').Select(d => d.Trim());
            var direction = DIRECTION.NORTH;

            foreach (var instruction in inputs)
            {
                var turn = instruction[0];
                var rawDistance = instruction.Substring(1, instruction.Length - 1);
                var distance = Convert.ToInt32(rawDistance);

                if (turn == 'R')
                    direction = TurnRight(direction);
                else if (turn == 'L')
                    direction = TurnLeft(direction);

                point = GoDistance(point, direction, distance);
            }

            return point;
        }

        public Point GetFirstPlaceVisitedTwice(string input)
        {
            var point = new Point(0, 0);
            var inputs = input.Split(',').Select(d => d.Trim());
            var direction = DIRECTION.NORTH;

            var visited = new List<Point>();
            visited.Add(point);

            foreach (var instruction in inputs)
            {
                var turn = instruction[0];
                var rawDistance = instruction.Substring(1, instruction.Length - 1);
                var distance = Convert.ToInt32(rawDistance);

                if (turn == 'R')
                    direction = TurnRight(direction);
                else if (turn == 'L')
                    direction = TurnLeft(direction);

                while (distance-- > 0)
                {
                    point = Go(point, direction);

                    if (visited.Any(p => p.X == point.X && p.Y == point.Y))
                        return point;
                    else
                        visited.Add(point);
                }
            }

            throw new Exception("You done messed up!");
        }

        private Point Go(Point point, DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.NORTH: return new Point(point.X, point.Y + 1);
                case DIRECTION.EAST: return new Point(point.X + 1, point.Y);
                case DIRECTION.SOUTH: return new Point(point.X, point.Y - 1);
                case DIRECTION.WEST: return new Point(point.X - 1, point.Y);
            }

            throw new Exception("You done messed up!");
        }

        private Point GoDistance(Point point, DIRECTION direction, int distance)
        {
            while (distance-- > 0)
                point = Go(point, direction);

            return point;
        }

        private DIRECTION TurnLeft(DIRECTION direction)
        {
            var numericDirection = Convert.ToInt32(direction);
            numericDirection = (numericDirection + 3) % 4;

            return (DIRECTION)numericDirection;
        }

        private DIRECTION TurnRight(DIRECTION direction)
        {
            var numericDirection = Convert.ToInt32(direction);
            numericDirection = (numericDirection + 1) % 4;

            return (DIRECTION)numericDirection;
        }
    }
}
