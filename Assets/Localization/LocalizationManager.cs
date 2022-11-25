using System;
using UnityEngine;

namespace LocalizationSystem
{
    public static class LocalizationManager
    {
        public static Language language { get; private set; }

        public static event Action onLanguageChanged;
        public static void LanguageChanged() => onLanguageChanged?.Invoke();

        public static string GetLocalizedValue(TranslationsTxt translationTxt)
        {
            foreach (TextTranslationDatas datas in translationTxt.datas)
            {
                if (datas.language != language) continue;

                return datas.text;
            }

            Debug.LogError("No translation set - " + language + " | " + translationTxt.name);
            return null;
        }

        public static Sprite GetLocalizedValue(TranslationsImg translationImg)
        {
            foreach (ImageTranslationDatas datas in translationImg.datas)
            {
                if (datas.language != language) continue;

                return datas.img;
            }

            Debug.LogError("No translation set - " + language + " | " + translationImg.name);
            return null;
        }

        public static void SetBaseLanguage()
        {
            switch (Application.systemLanguage.ToString())
            {
                default:
                case "English":
                    SetLanguage(Language.English);
                    break;
            }
        }

        public static void SetLanguage(Language newLanguage)
        {
            language = newLanguage;
            LanguageChanged();
        }
    }
}