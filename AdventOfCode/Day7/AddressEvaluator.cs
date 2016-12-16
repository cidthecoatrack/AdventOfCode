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
            var sections = trimmedAddress.Split('-');
            var abas = new List<string>();

            foreach (var section in sections)
            {
                for (var i = 0; i + 3 <= section.Length; i++)
                {
                    var candidate = section.Substring(i, 3);
                    if (candidate[0] == candidate[2] && candidate[0] != candidate[1])
                        abas.Add(candidate);
                }
            }

            return abas;
        }

        private bool ContainsBAB(string address, string aba)
        {
            var hypernetSequences = hypernetRegex.Matches(address);

            foreach (Match sequence in hypernetSequences)
            {
                //INFO: skipping first and last character, as they are [ and ] respectively
                for (var i = 1; i + 4 <= sequence.Value.Length; i++)
                {
                    var candidate = sequence.Value.Substring(i, 3);
                    if (candidate[0] == candidate[2] && candidate[0] != candidate[1] && aba[0] == candidate[1] && aba[1] == candidate[0])
                        return true;
                }
            }

            return false;
        }
    }
}
