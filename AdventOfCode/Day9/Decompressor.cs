using System;
using System.Text;

namespace AdventOfCode.Day9
{
    public class Decompressor
    {
        public string Decompress(string compressed)
        {
            var decompressed = new StringBuilder();

            for (var i = 0; i < compressed.Length; i++)
            {
                if (compressed[i] != '(')
                {
                    decompressed.Append(compressed[i]);
                    continue;
                }

                var closingIndex = compressed.IndexOf(')', i);
                var marker = compressed.Substring(i + 1, closingIndex - i - 1);
                var sections = marker.Split('x');
                var characterCount = Convert.ToInt32(sections[0]);
                var repeats = Convert.ToInt32(sections[1]);

                var repeatableSegment = compressed.Substring(closingIndex + 1, characterCount);

                while (repeats-- > 0)
                    decompressed.Append(repeatableSegment);

                i = closingIndex + repeatableSegment.Length;
            }

            return decompressed.ToString();
        }

        public string RecursiveDecompress(string compressed)
        {
            if (compressed.IndexOf('(') == -1)
                return compressed;

            var decompressed = Decompress(compressed);
            return RecursiveDecompress(decompressed);
        }

        public long RecursiveDecompressLength(string compressed)
        {
            var decompressedLength = 0L;
            var compressedWithoutMarkers = compressed;

            for (var i = 0; i < compressedWithoutMarkers.Length; i++)
            {
                if (compressedWithoutMarkers[i] != '(')
                {
                    decompressedLength++;
                    continue;
                }

                var closingIndex = compressedWithoutMarkers.IndexOf(')', i);
                var marker = compressedWithoutMarkers.Substring(i + 1, closingIndex - i - 1);
                var sections = marker.Split('x');
                var characterCount = Convert.ToInt32(sections[0]);
                var repeats = Convert.ToInt32(sections[1]);

                var repeatableSegment = compressedWithoutMarkers.Substring(closingIndex + 1, characterCount);
                var decompressedRepeatableSegmentLength = RecursiveDecompressLength(repeatableSegment);

                decompressedLength += decompressedRepeatableSegmentLength * repeats;
                compressedWithoutMarkers = compressedWithoutMarkers.Remove(i, closingIndex - i + 1 + repeatableSegment.Length);

                i--;
            }

            return decompressedLength;
        }
    }
}
