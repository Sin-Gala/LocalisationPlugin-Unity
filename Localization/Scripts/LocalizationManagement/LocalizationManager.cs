using System;
using UnityEngine;

namespace SinGala.Plugins.Localization
{
    public static class LocalizationManager
    {
        public static Language Language { get; private set; }

        public static event Action OnLanguageChanged;

        /// <summary>
        /// Calls the OnLanguageChanged event
        /// </summary>
        public static void LanguageChanged() => OnLanguageChanged?.Invoke();

        /// <summary>
        /// Returns the correct Localized Value from the given Translations Datas 
        /// depending on the current language
        /// </summary>
        public static T GetLocalizedValue<T>(Translations<T> translationDatas)
        {
            if (translationDatas == null || translationDatas.Datas.Length == 0)
            {
#if UNITY_EDITOR
                Debug.LogError("No translation set - " + Language + " - " + translationDatas.name);
#endif

                return default(T);
            }

            foreach (TranslationDatas<T> datas in translationDatas.Datas)
            {
                if (datas.Language != Language) continue;

                return datas.LocalizedDatas;
            }

#if UNITY_EDITOR
            Debug.LogError("No translation set - " + Language + " - " + translationDatas.name);
#endif
            return default(T);
        }

        /// <summary>
        /// Returns the full translations datas corresponding with the current language
        /// </summary>
        public static TranslationDatas<T> GetLocalizedDatas<T>(Translations<T> translationDatas)
        {
            if (translationDatas == null || translationDatas.Datas.Length == 0)
            {
#if UNITY_EDITOR
                Debug.LogError("No translation datas set - " + Language + " - " + translationDatas.name);
#endif

                return null;
            }

            foreach (TranslationDatas<T> datas in translationDatas.Datas)
            {
                if (datas.Language != Language) continue;

                return datas;
            }

#if UNITY_EDITOR
            Debug.LogError("No translation datas set - " + Language + " - " + translationDatas.name);
#endif
            return null;
        }

        /// <summary>
        /// Set the current language to the Application.systemLanguage of the device
        /// </summary>
        public static Language SetBaseLanguage()
        {
            switch (Application.systemLanguage.ToString())
            {
                default:
                case "English":
                    SetLanguage(Language.English);
                    break;
                case "French":
                    SetLanguage(Language.French);
                    break;
            }

#if UNITY_EDITOR
            Debug.Log("Base Language set to: " + Application.systemLanguage.ToString());
#endif

            return Language;
        }

        /// <summary>
        /// Set the current language to the specified one
        /// </summary>
        public static void SetLanguage(Language newLanguage)
        {
            Language = newLanguage;
            LanguageChanged();

#if UNITY_EDITOR
            Debug.Log("Language set to: " + Application.systemLanguage.ToString());
#endif
        }
    }
}