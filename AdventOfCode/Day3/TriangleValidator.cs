using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class TriangleValidator
    {
        public bool IsValid(params int[] sides)
        {
            if (sides.Count() != 3)
                throw new Exception("Nope, not a triangle");

            var orderedSides = sides.OrderByDescending(s => s);
            var longestSide = orderedSides.First();
            var otherSides = orderedSides.Skip(1);

            return otherSides.Sum() > longestSide;
        }

        public int[][] TransformTrianglesFromColumns(params int[][] triangles)
        {
            var transformedTriangles = new List<int[]>();

            for (var row = 0; row < triangles.Length; row += 3)
            {
                for (var column = 0; column < 3; column++)
                {
                    transformedTriangles.Add(new[] { triangles[row][column], triangles[row + 1][column], triangles[row + 2][column] });
                }
            }

            return transformedTriangles.ToArray();
        }
    }
}
