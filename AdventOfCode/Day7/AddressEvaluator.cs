using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day7
{
    public class AddressEvaluator
    {
        private readonly Regex abbaRegex;
        private readonly Regex hypernetRegex;
        private readonly Regex abaRegex;

        public AddressEvaluator()
        {
            abbaRegex = new Regex("([a-z])([a-z])\\2\\1");
            hypernetRegex = new Regex("\\[[^\\[\\]]*\\]");
            abaRegex = new Regex("([a-z])([a-z])\\1");
        }

        public bool AllowsTLS(string address)
        {
            var hypernetSequences = hypernetRegex.Matches(address);
            var trimmedAddress = address;

            foreach (Match sequence in hypernetSequences)
                if (ContainsABBA(sequence.Value))
                    return false;

            return ContainsABBA(address);
        }

        private bool ContainsABBA(string address)
        {
            var matches = abbaRegex.Matches(address);

            foreach (Match match in matches)
            {
                if (match.Value[0] == match.Value[3] && match.Value[0] != match.Value[1])
                    return true;
            }

            return false;
        }

        public bool AllowsSSL(string address)
        {
            var abas = GetABAs(address);
            return abas.Any(a => ContainsBAB(address, a));
        }

        private IEnumerable<string> GetABAs(string address)
        {
            var trimmedAddress = hypernetRegex.Replace(address, "-");
            var matches = abaRegex.Matches(trimmedAddress);
            var abas = new List<string>();

            foreach (Match match in matches)
            {
                if (match.Value[0] == match.Value[2] && match.Value[0] != match.Value[1])
                    abas.Add(match.Value);
            }

            return abas;
        }

        private bool ContainsBAB(string address, string aba)
        {
            var hypernetSequences = hypernetRegex.Matches(address);

            foreach (Match sequence in hypernetSequences)
            {
                var matches = abaRegex.Matches(sequence.Value);

                foreach (Match match in matches)
                {
                    if (match.Value[0] == aba[1] && match.Value[1] == aba[0])
                        return true;
                }
            }

            return false;
        }
    }
}
