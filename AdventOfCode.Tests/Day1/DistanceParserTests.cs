using AdventOfCode.Day1;
using NUnit.Framework;
using System;
using System.Drawing;

namespace AdventOfCode.Tests.Day1
{
    [TestFixture]
    public class DistanceParserTests
    {
        private DistanceParser distanceParser;

        [SetUp]
        public void Setup()
        {
            distanceParser = new DistanceParser();
        }

        [TestCase("R2, L3", 5)]
        [TestCase("R2, R2, R2", 2)]
        [TestCase("R5, L5, R5, R3", 12)]
        public void VerifyFinalCoordinate(string input, int totalBlocks)
        {
            var coordinate = distanceParser.GetFinalCoordinate(input);
            var distance = GetTotalBlocks(coordinate);

            Assert.That(distance, Is.EqualTo(totalBlocks));
        }

        private int GetTotalBlocks(Point point)
        {
            return Math.Abs(point.X) + Math.Abs(point.Y);
        }

        [Test]
        public void GetFinalCoordinates()
        {
            var input = "L2, L3, L3, L4, R1, R2, L3, R3, R3, L1, L3, R2, R3, L3, R4, R3, R3, L1, L4, R4, L2, R5, R1, L5, R1, R3, L5, R2, L2, R2, R1, L1, L3, L3, R4, R5, R4, L1, L189, L2, R2, L5, R5, R45, L3, R4, R77, L1, R1, R194, R2, L5, L3, L2, L1, R5, L3, L3, L5, L5, L5, R2, L1, L2, L3, R2, R5, R4, L2, R3, R5, L2, L2, R3, L3, L2, L1, L3, R5, R4, R3, R2, L1, R2, L5, R4, L5, L4, R4, L2, R5, L3, L2, R4, L1, L2, R2, R3, L2, L5, R1, R1, R3, R4, R1, R2, R4, R5, L3, L5, L3, L3, R5, R4, R1, L3, R1, L3, R3, R3, R3, L1, R3, R4, L5, L3, L1, L5, L4, R4, R1, L4, R3, R3, R5, R4, R3, R3, L1, L2, R1, L4, L4, L3, L4, L3, L5, R2, R4, L2";

            var coordinate = distanceParser.GetFinalCoordinate(input);
            var distance = GetTotalBlocks(coordinate);

            Assert.Pass($"Distance is {distance} blocks");
        }

        [TestCase("R8, R4, R4, R8", 4)]
        public void VerifyDistanceToSecondVisit(string input, int totalBlocks)
        {
            var coordinate = distanceParser.GetFirstPlaceVisitedTwice(input);
            var distance = GetTotalBlocks(coordinate);
            Assert.That(distance, Is.EqualTo(totalBlocks));
        }

        [Test]
        public void VerifyDistanceToSecondVisit()
        {
            var input = "L2, L3, L3, L4, R1, R2, L3, R3, R3, L1, L3, R2, R3, L3, R4, R3, R3, L1, L4, R4, L2, R5, R1, L5, R1, R3, L5, R2, L2, R2, R1, L1, L3, L3, R4, R5, R4, L1, L189, L2, R2, L5, R5, R45, L3, R4, R77, L1, R1, R194, R2, L5, L3, L2, L1, R5, L3, L3, L5, L5, L5, R2, L1, L2, L3, R2, R5, R4, L2, R3, R5, L2, L2, R3, L3, L2, L1, L3, R5, R4, R3, R2, L1, R2, L5, R4, L5, L4, R4, L2, R5, L3, L2, R4, L1, L2, R2, R3, L2, L5, R1, R1, R3, R4, R1, R2, R4, R5, L3, L5, L3, L3, R5, R4, R1, L3, R1, L3, R3, R3, R3, L1, R3, R4, L5, L3, L1, L5, L4, R4, R1, L4, R3, R3, R5, R4, R3, R3, L1, L2, R1, L4, L4, L3, L4, L3, L5, R2, R4, L2";

            var coordinate = distanceParser.GetFirstPlaceVisitedTwice(input);
            var distance = GetTotalBlocks(coordinate);

            Assert.Pass($"Distance is {distance} blocks");
        }
    }
}
