using UnityEngine;

namespace TheanaProd.Plugins.Localization
{
    [System.Serializable]
    public class LanguageManager
    {
        private string currentLanguage;
        public string indexLanguage { get; set; }

        public LocalizationSystem localizationSystem { get; set; }

        /// <summary>
        /// Return the system language of the device used by the user
        /// </summary>
        public string GetBaseLanguage()
        {
            currentLanguage = Application.systemLanguage.ToString();

            return currentLanguage;
        }

        /// <summary>
        /// Set the language chosen and updates all texts by calling the LanguageChanged event
        /// </summary>
        public void SetLanguage(int indexDropdownNew)
        {
            if (localizationSystem == null)
                localizationSystem = new LocalizationSystem();

            switch (indexDropdownNew)
            {
                case 0:
                default:
                    indexLanguage = "en";
                    currentLanguage = "English";
                    localizationSystem.language = LocalizationSystem.Languages.English;
                    break;
                case 1:
                    indexLanguage = "fr";
                    currentLanguage = "French";
                    localizationSystem.language = LocalizationSystem.Languages.French;
                    break;
            }

            LocalizationEvents.instance.LanguageChanged();
        }
    }
}
