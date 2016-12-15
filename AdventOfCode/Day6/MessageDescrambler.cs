using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    public class MessageDescrambler
    {
        public string Descramble(string scrambledMessage)
        {
            var columns = RotateRowsToColumns(scrambledMessage);
            var modes = columns.Select(c => GetMode(c));
            var message = new StringBuilder();

            foreach (var mode in modes)
                message.Append(mode);

            return message.ToString();
        }

        private IEnumerable<string> RotateRowsToColumns(string source)
        {
            var rows = source.Split('\r', '\n').Where(r => !string.IsNullOrWhiteSpace(r)).ToArray();
            var columns = new List<string>();

            for (var columnIndex = 0; columnIndex < rows[0].Length; columnIndex++)
            {
                var column = new StringBuilder();

                for (var rowIndex = 0; rowIndex < rows.Count(); rowIndex++)
                    column.Append(rows[rowIndex][columnIndex]);

                columns.Add(column.ToString());
            }

            return columns;
        }

        private string GetMode(string source)
        {
            return source.GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .First().Key.ToString();
        }

        private string GetLeastCommon(string source)
        {
            return source.GroupBy(s => s)
                .OrderBy(g => g.Count())
                .First().Key.ToString();
        }

        public string DescrambleModified(string scrambledMessage)
        {
            var columns = RotateRowsToColumns(scrambledMessage);
            var modes = columns.Select(c => GetLeastCommon(c));
            var message = new StringBuilder();

            foreach (var mode in modes)
                message.Append(mode);

            return message.ToString();
        }
    }
}
