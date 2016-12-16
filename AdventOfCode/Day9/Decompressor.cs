using System;
using System.Text;

namespace AdventOfCode.Day9
{
    public class Decompressor
    {
        public string Decompress(string compressedString)
        {
            var decompressed = compressedString;

            for (var i = 0; i < decompressed.Length; i++)
            {
                if (decompressed[i] != '(')
                    continue;

                var closingIndex = decompressed.IndexOf(')', i);
                var marker = decompressed.Substring(i + 1, closingIndex - i - 1);
                var sections = marker.Split('x');
                var characterCount = Convert.ToInt32(sections[0]);
                var repeats = Convert.ToInt32(sections[1]);

                var repeatableSegment = decompressed.Substring(closingIndex + 1, characterCount);
                var decompressedSegment = new StringBuilder();

                while (repeats-- > 0)
                    decompressedSegment.Append(repeatableSegment);

                var replaceableSegment = decompressed.Substring(i, closingIndex - i + characterCount + 1);
                decompressed = decompressed.Replace(replaceableSegment, decompressedSegment.ToString());

                i += decompressedSegment.Length;
            }

            return decompressed;
        }
    }
}
