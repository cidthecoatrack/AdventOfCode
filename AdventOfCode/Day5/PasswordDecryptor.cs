using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Day5
{
    public class PasswordDecryptor
    {
        private readonly MD5 hasher;

        public PasswordDecryptor()
        {
            hasher = MD5.Create();
        }

        public string Decrypt(string doorID)
        {
            var password = new StringBuilder();
            var index = 0;

            while (password.Length < 8)
            {
                var input = doorID + index.ToString();
                var hash = GetTruncatedHash(input);

                if (hash.StartsWith("00000"))
                    password.Append(hash[5]);

                index++;
            }

            return password.ToString();
        }

        private string GetTruncatedHash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = hasher.ComputeHash(inputBytes);
            var hash = new StringBuilder();
            var index = 0;

            while (hash.Length < 7)
            {
                var hashCharacter = hashBytes[index++].ToString("x2");
                hash.Append(hashCharacter);
            }

            return hash.ToString();
        }

        public string FancyDecrypt(string doorID)
        {
            var index = 0;
            var passwordCharacters = new[]
            {
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
            };

            while (passwordCharacters.Any(c => c == ' '))
            {
                var input = doorID + index.ToString();
                var hash = GetTruncatedHash(input);
                var passwordIndex = (int)char.GetNumericValue(hash[5]);

                if (hash.StartsWith("00000") && passwordIndex < 8 && passwordIndex > -1 && passwordCharacters[passwordIndex] == ' ')
                    passwordCharacters[passwordIndex] = hash[6];

                index++;
            }

            var password = new StringBuilder();
            foreach (var passwordCharacter in passwordCharacters)
                password.Append(passwordCharacter);

            return password.ToString();
        }
    }
}
