namespace OldPhoneApp
{
    public class OldPhone : IMobilePhone
    {
        private readonly Dictionary<char, string> digitMap = new()
        {
            { '1', "" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "QXYZ" },
            { '0', "" },
        };

        public string Pad(string input)
        {
            string output = string.Empty;
            IEnumerable<string> inputGroups = GroupInputs(input);

            foreach (string inputGroup in inputGroups)
            {
                if (IsEndOfInput(inputGroup))
                {
                    return output;
                }

                if (IsBackspace(inputGroup))
                {
                    output = output.Remove(output.Length - 1, 1);
                }

                output += GetAlphabets(inputGroup);
            }

            return output;
        }

        private string GetAlphabets(string inputGroup)
        {
            string alphabets = string.Empty;
            Dictionary<char, int> inputDigits = GroupByNumberOfCharacters(inputGroup);

            foreach (KeyValuePair<char, int> inputDigit in inputDigits)
            {
                if (!digitMap.TryGetValue(inputDigit.Key, out var text))
                {
                    continue;
                }

                char alphabet = text[inputDigit.Value - 1];

                alphabets += alphabet;
            }

            return alphabets;
        }

        private static IEnumerable<string> GroupInputs(string input)
        {
            return input.Replace("#", " # ").Replace("*", " * ").Split();
        }

        private static Dictionary<char, int> GroupByNumberOfCharacters(string inputGroup)
        {
            return inputGroup.ToCharArray().GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());
        }

        private static bool IsEndOfInput(string inputGroup)
        {
            return inputGroup == "#";
        }

        private static bool IsBackspace(string inputGroup)
        {
            return inputGroup == "*";
        }
    }
}
