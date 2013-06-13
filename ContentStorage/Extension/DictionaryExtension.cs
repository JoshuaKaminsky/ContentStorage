using System.Collections.Generic;

namespace ContentStorage.Extension
{
    internal static class DictionaryExtension
    {
        public static void SafeAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value, bool overwrite = false)
        {
            if (dictionary.ContainsKey(key))
            {
                if (overwrite)
                    dictionary[key] = value;

                return;
            }

            dictionary.Add(key, value);
        }

        public static bool SafeRemove<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return key == null || !dictionary.ContainsKey(key) || dictionary.Remove(key);
        }
    }
}
