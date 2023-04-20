namespace OldPhoneApp
{
    public class OldPhone : IMobilePhone
    {
        private readonly Dictionary<int, string> digitMap = new()
        {
            { 1, "" },
            { 2, "[abcABC]" },
            { 3, "[defDEF]" },
            { 4, "[ghiGHI]" },
            { 5, "[jklJKL]" },
            { 6, "[mnoMNO]" },
            { 7, "[pqrsPQRS]" },
            { 8, "[tuvTUV]" },
            { 9, "[qxyzQXYZ]" },
            { 0, "" },
        };

        public string Pad(string input)
        {
            IEnumerable<int> charsAsInts = input.ToCharArray().Select(x => int.Parse(x.ToString()));

            return input;
        }
    }
}
