// Script based on this video: https://www.youtube.com/watch?v=c-dzg4M20wY&t=129s

using System.Collections.Generic;

namespace TheanaProd.Plugins.Localization
{
    public class LocalizationSystem
    {
        public enum Languages
        {
            English,
            French
        }

        public Languages language;

        private Dictionary<string, string> localizedEN = new Dictionary<string, string>();
        private Dictionary<string, string> localizedFR = new Dictionary<string, string>();

        public bool isInit;

        private void Init()
        {
            CSVLoader csvLoader = new CSVLoader();
            csvLoader.LoadCSV();

            localizedEN = csvLoader.GetDictionaryValues("en");
            localizedFR = csvLoader.GetDictionaryValues("fr");

            isInit = true;
        }

		/// <summary>
		/// Get the localized value of the key
		/// </summary>
        public string GetLocalizedValue(string key)
        {
            if (!isInit)
                Init();

            string value = key;

            switch (language)
            {
                case Languages.English:
                    localizedEN.TryGetValue(key, out value);
                    break;
                case Languages.French:
                    localizedFR.TryGetValue(key, out value);
                    break;
            }

            return value;
        }
    }

}