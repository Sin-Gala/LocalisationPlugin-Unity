// Script based on this video: https://www.youtube.com/watch?v=c-dzg4M20wY&t=129s

using UnityEngine;
using UnityEngine.UI;
using TheanaProd.Plugins.Localization.SaveSystem;

namespace TheanaProd.Plugins.Localization
{
    /// <summary>
    /// Add this to all your text gameObject that needs to be translated
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TextLocalizer : MonoBehaviour
    {
        private LanguageManager languageManager;
        private LocalizationSystem localizationSystem;
        Text textField;

        public string key;

        private void Start()
        {
            textField = GetComponent<Text>();
            UpdateText();
        }

        private void UpdateText()
        {
            if (languageManager == null)
                languageManager = SaveManager.instance.languageManager;

            if (localizationSystem == null)
                localizationSystem = languageManager.localizationSystem;

            string value = localizationSystem.GetLocalizedValue(key);
            textField.text = value;
        }

        private void OnEnable()
        {
            LocalizationEvents.instance.onLanguageChanged += UpdateText;
        }

        private void OnDisable()
        {
            LocalizationEvents.instance.onLanguageChanged -= UpdateText;
        }
    }
}
