namespace ReserGO.Utils.DTO.ExtensionMethod
{
    public static class StringExtensions
    {
        public static string ToUpperFirstLetter(this string input, bool capitalize=true)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            if (capitalize)
            {
                return char.ToUpper(input[0]) + input.Substring(1);
            }
            else
            {
                return char.ToLower(input[0]) + input.Substring(1);
            }
        }
    }
}
