using AdventOfCode.Day8;
using NUnit.Framework;
using System.Linq;

namespace AdventOfCode.Tests.Day8
{
    [TestFixture]
    public class TinyDisplayTests
    {
        [TestCase(3, 7, 6,
            "rect 3x2",
            "rotate column x=1 by 1",
            "rotate row y=0 by 4",
            "rotate column x=1 by 1")]
        [TestCase(6, 50, 8,
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 3",
            "rect 1x1",
            "rotate row y=0 by 3")]
        [TestCase(6, 50, 8,
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 3",
            "rect 1x1",
            "rotate row y=0 by 3",
            "rotate column x=6 by 1")]
        [TestCase(3, 7, 9,
            "rect 3x2",
            "rotate column x=1 by 1",
            "rotate row y=0 by 4",
            "rotate column x=1 by 1",
            "rect 3x2")]
        [TestCase(3, 7, 11,
            "rect 3x2",
            "rotate column x=1 by 1",
            "rotate row y=0 by 4",
            "rotate column x=1 by 1",
            "rect 3x2",
            "rotate row y=0 by 4",
            "rect 3x2")]
        [TestCase(3, 7, 12,
            "rect 3x2",
            "rotate column x=1 by 1",
            "rotate row y=0 by 4",
            "rotate column x=1 by 1",
            "rect 3x3",
            "rotate row y=1 by 40",
            "rect 2x2")]
        public void LightDisplay(int height, int width, int totalLit, params string[] commands)
        {
            var display = new TinyDisplay(height, width);
            var litDisplay = display.LightDisplay(commands);

            Assert.That(litDisplay.Length, Is.EqualTo(height));

            foreach (var row in litDisplay)
                Assert.That(row.Length, Is.EqualTo(width));

            var total = litDisplay.Sum(r => r.Count(c => c));
            Assert.That(total, Is.EqualTo(totalLit));
        }

        private string[] GetCommands()
        {
            var commands = @"rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 5
rect 4x1
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate row y=0 by 10
rotate column x=5 by 2
rotate column x=0 by 1
rect 9x1
rotate row y=2 by 5
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate row y=2 by 5
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate column x=40 by 1
rotate column x=27 by 1
rotate column x=22 by 1
rotate column x=17 by 1
rotate column x=12 by 1
rotate column x=7 by 1
rotate column x=2 by 1
rotate row y=2 by 5
rotate row y=1 by 3
rotate row y=0 by 5
rect 1x3
rotate row y=2 by 10
rotate row y=1 by 7
rotate row y=0 by 2
rotate column x=3 by 2
rotate column x=2 by 1
rotate column x=0 by 1
rect 4x1
rotate row y=2 by 5
rotate row y=1 by 3
rotate row y=0 by 3
rect 1x3
rotate column x=45 by 1
rotate row y=2 by 7
rotate row y=1 by 10
rotate row y=0 by 2
rotate column x=3 by 1
rotate column x=2 by 2
rotate column x=0 by 1
rect 4x1
rotate row y=2 by 13
rotate row y=0 by 5
rotate column x=3 by 1
rotate column x=0 by 1
rect 4x1
rotate row y=3 by 10
rotate row y=2 by 10
rotate row y=0 by 5
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=0 by 1
rect 4x1
rotate row y=3 by 8
rotate row y=0 by 5
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=0 by 1
rect 4x1
rotate row y=3 by 17
rotate row y=2 by 20
rotate row y=0 by 15
rotate column x=13 by 1
rotate column x=12 by 3
rotate column x=10 by 1
rotate column x=8 by 1
rotate column x=7 by 2
rotate column x=6 by 1
rotate column x=5 by 1
rotate column x=3 by 1
rotate column x=2 by 2
rotate column x=0 by 1
rect 14x1
rotate row y=1 by 47
rotate column x=9 by 1
rotate column x=4 by 1
rotate row y=3 by 3
rotate row y=2 by 10
rotate row y=1 by 8
rotate row y=0 by 5
rotate column x=2 by 2
rotate column x=0 by 2
rect 3x2
rotate row y=3 by 12
rotate row y=2 by 10
rotate row y=0 by 10
rotate column x=8 by 1
rotate column x=7 by 3
rotate column x=5 by 1
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=1 by 1
rotate column x=0 by 1
rect 9x1
rotate row y=0 by 20
rotate column x=46 by 1
rotate row y=4 by 17
rotate row y=3 by 10
rotate row y=2 by 10
rotate row y=1 by 5
rotate column x=8 by 1
rotate column x=7 by 1
rotate column x=6 by 1
rotate column x=5 by 1
rotate column x=3 by 1
rotate column x=2 by 2
rotate column x=1 by 1
rotate column x=0 by 1
rect 9x1
rotate column x=32 by 4
rotate row y=4 by 33
rotate row y=3 by 5
rotate row y=2 by 15
rotate row y=0 by 15
rotate column x=13 by 1
rotate column x=12 by 3
rotate column x=10 by 1
rotate column x=8 by 1
rotate column x=7 by 2
rotate column x=6 by 1
rotate column x=5 by 1
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=1 by 1
rotate column x=0 by 1
rect 14x1
rotate column x=39 by 3
rotate column x=35 by 4
rotate column x=20 by 4
rotate column x=19 by 3
rotate column x=10 by 4
rotate column x=9 by 3
rotate column x=8 by 3
rotate column x=5 by 4
rotate column x=4 by 3
rotate row y=5 by 5
rotate row y=4 by 5
rotate row y=3 by 33
rotate row y=1 by 30
rotate column x=48 by 1
rotate column x=47 by 5
rotate column x=46 by 5
rotate column x=45 by 1
rotate column x=43 by 1
rotate column x=38 by 3
rotate column x=37 by 3
rotate column x=36 by 5
rotate column x=35 by 1
rotate column x=33 by 1
rotate column x=32 by 5
rotate column x=31 by 5
rotate column x=30 by 1
rotate column x=23 by 4
rotate column x=22 by 3
rotate column x=21 by 3
rotate column x=20 by 1
rotate column x=12 by 2
rotate column x=11 by 2
rotate column x=3 by 5
rotate column x=2 by 5
rotate column x=1 by 3
rotate column x=0 by 4";

            return commands.Split('\r', '\n').Where(c => !string.IsNullOrWhiteSpace(c)).ToArray();
        }

        [Test]
        public void DAY_8_1()
        {
            var commands = GetCommands();
            var display = new TinyDisplay(6, 50);
            var litDisplay = display.LightDisplay(commands);

            Assert.That(litDisplay.Length, Is.EqualTo(6));
            Assert.That(litDisplay[0].Length, Is.EqualTo(50));
            Assert.That(litDisplay[1].Length, Is.EqualTo(50));
            Assert.That(litDisplay[2].Length, Is.EqualTo(50));
            Assert.That(litDisplay[3].Length, Is.EqualTo(50));
            Assert.That(litDisplay[4].Length, Is.EqualTo(50));
            Assert.That(litDisplay[5].Length, Is.EqualTo(50));
            Assert.That(litDisplay[0], Has.Some.True);
            Assert.That(litDisplay[1], Has.Some.True);
            Assert.That(litDisplay[2], Has.Some.True);
            Assert.That(litDisplay[3], Has.Some.True);
            Assert.That(litDisplay[4], Has.Some.True);
            Assert.That(litDisplay[5], Has.Some.True);

            var total = litDisplay.Sum(r => r.Count(c => c));
            Assert.That(total, Is.GreaterThan(89));
            Assert.That(total, Is.LessThan(300));
            Assert.Pass($"There are {total} pixels lit");
        }

        [Test]
        public void DAY_8_2()
        {
            var commands = GetCommands();
            var display = new TinyDisplay(6, 50);
            var litDisplay = display.LightDisplay(commands);

            Assert.That(litDisplay.Length, Is.EqualTo(6));
            Assert.That(litDisplay[0].Length, Is.EqualTo(50));
            Assert.That(litDisplay[1].Length, Is.EqualTo(50));
            Assert.That(litDisplay[2].Length, Is.EqualTo(50));
            Assert.That(litDisplay[3].Length, Is.EqualTo(50));
            Assert.That(litDisplay[4].Length, Is.EqualTo(50));
            Assert.That(litDisplay[5].Length, Is.EqualTo(50));
            Assert.That(litDisplay[0], Has.Some.True);
            Assert.That(litDisplay[1], Has.Some.True);
            Assert.That(litDisplay[2], Has.Some.True);
            Assert.That(litDisplay[3], Has.Some.True);
            Assert.That(litDisplay[4], Has.Some.True);
            Assert.That(litDisplay[5], Has.Some.True);

            var total = litDisplay.Sum(r => r.Count(c => c));
            Assert.That(total, Is.EqualTo(119));

            var code = "";

            foreach (var row in litDisplay)
            {
                foreach (var pixel in row)
                {
                    if (pixel)
                        code += "#";
                    else
                        code += ".";
                }

                code += "\r\n";
            }

            Assert.Pass($"The code is: \r\n{code}");
        }
    }
}
