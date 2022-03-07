// Code updated from: https://forum.unity.com/threads/localizing-ui-dropdown-options.896951/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheanaProd.Plugins.Localization.SaveSystem;

namespace TheanaProd.Plugins.Localization
{
    /// <summary>
    /// Put this on your dropdown gameObject
    /// Add a string in the Awake switch so the dropdown knows which index it's supposed to show
    /// </summary>
    public class LocalizeDropdown : MonoBehaviour
    {
        private Dropdown dropdown;

        [SerializeField] private List<string> keys = new List<string>();
        public int selectedOptionIndex = 0;

        private LanguageManager language;
        private LocalizationSystem localizationSystem;
        [SerializeField] private string indexDropdown;

        private void Awake()
        {
            dropdown = GetComponent<Dropdown>();

            switch (indexDropdown)
            {
                case "Language":
                    selectedOptionIndex = SettingsManager.instance.languageOption;
                    break;
            }

            dropdown.value = selectedOptionIndex;

            dropdown.onValueChanged.AddListener(UpdateSelectedOptionIndex);
            UpdateDropdown();
        }

        private void UpdateDropdown()
        {
            if (language == null)
                language = SaveManager.instance.languageManager;

            if (localizationSystem == null)
                localizationSystem = language.localizationSystem;

            for (int i = 0; i < keys.Count; i++)
            {
                string key = keys[i];
                string localizedText = string.Empty;

                if (!string.IsNullOrWhiteSpace(key))
                {
                    localizedText = localizationSystem.GetLocalizedValue(key);
                    dropdown.options[i].text = localizedText;
                }

                if (i == dropdown.value)
                    UpdateSelectedText(localizedText);
            }
        }

        private void UpdateSelectedOptionIndex(int index) => selectedOptionIndex = index;

        private void UpdateSelectedText(string text)
        {
            if (dropdown.captionText != null)
                dropdown.captionText.text = text;
        }

        private void OnEnable()
        {
            LocalizationEvents.instance.onLanguageChanged += UpdateDropdown;
        }

        private void OnDisable()
        {
            LocalizationEvents.instance.onLanguageChanged -= UpdateDropdown;
        }
    }
}