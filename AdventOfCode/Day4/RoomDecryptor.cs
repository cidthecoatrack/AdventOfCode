using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class RoomDecryptor
    {
        public bool IsRealRoom(string name)
        {
            var checkSum = GetChecksum(name);
            var trimmedName = TrimName(name);

            var letterCounts = new Dictionary<char, int>();

            foreach (var character in trimmedName)
            {
                if (letterCounts.ContainsKey(character) == false)
                    letterCounts[character] = 0;

                letterCounts[character]++;
            }

            var orderedCharacters = letterCounts.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key);
            var actualCheckSum = string.Empty;

            foreach (var character in orderedCharacters.Take(5).Select(kvp => kvp.Key))
                actualCheckSum += character;

            return actualCheckSum == checkSum;
        }

        private string TrimName(string name, bool keepDashes = false)
        {
            var sectorIDStart = name.IndexOf('[') - 4;
            var trimmedName = name.Substring(0, sectorIDStart);

            if (keepDashes)
                return trimmedName;

            return trimmedName.Replace("-", string.Empty);
        }

        private string GetChecksum(string name)
        {
            var checkSumStart = name.IndexOf('[') + 1;
            return name.Substring(checkSumStart, 5);
        }

        public int GetSectorID(string name)
        {
            var sectorIDStart = name.IndexOf('[') - 3;
            var rawSectorID = name.Substring(sectorIDStart, 3);
            return Convert.ToInt32(rawSectorID);
        }

        public string DecryptName(string name)
        {
            var sectorID = GetSectorID(name);
            var trimmedName = TrimName(name, true);
            var decryptedName = string.Empty;

            for (var i = 0; i < trimmedName.Length; i++)
            {
                var decryptedCharacter = trimmedName[i];

                if (decryptedCharacter != '-')
                {
                    var targetLetterIndex = ConvertLetterToIndex(trimmedName[i]);
                    targetLetterIndex = (targetLetterIndex + sectorID) % 26;
                    decryptedCharacter = ConvertIndexToLetter(targetLetterIndex);
                }
                else
                {
                    decryptedCharacter = ' ';
                }

                decryptedName += decryptedCharacter;
            }

            return decryptedName;
        }

        private int ConvertLetterToIndex(char character)
        {
            return Convert.ToInt32(character) - 97;
        }

        private char ConvertIndexToLetter(int index)
        {
            return Convert.ToChar(index + 97);
        }
    }
}
