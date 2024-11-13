using System.Diagnostics;

namespace ReserGO.Utils.DTO.Utils
{
    public class DictionaryTranslate<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public DictionaryTranslate()
        {
        }

        public DictionaryTranslate(Dictionary<TKey, TValue> dictionary) : base(dictionary) { }

        public new TValue this[TKey key]
        {
            get
            {
                if (base.TryGetValue(key, out TValue value))
                    return value;
                else
                {
                    string keyString = key.ToString();
                    string capitalizedString = CapitalizeFirstLetter(keyString);
                    Debug.WriteLine($"DA TRADURRE: {capitalizedString}");
                    return (TValue)(object)(capitalizedString + "*");
                }
            }
            set
            {
                base[key] = value;
            }
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
