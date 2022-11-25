using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LocalizationSystem
{
    [RequireComponent(typeof(Dropdown))]
    public class LocalizeDropdown : MonoBehaviour
    {
        private Dropdown dropdown;

        [SerializeField] private List<TranslationsTxt> keys = new List<TranslationsTxt>();
        private int selectedOptionIndex = 0;

        private void Awake()
        {
            dropdown = GetComponent<Dropdown>();
            dropdown.value = selectedOptionIndex;

            dropdown.onValueChanged.AddListener(UpdateSelectedOptionIndex);
            UpdateDropdown();
        }

        private void UpdateDropdown()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                string localizedText = LocalizationManager.GetLocalizedValue(keys[i]);
                dropdown.options[i].text = localizedText;

                if (i == dropdown.value)
                    UpdateSelectedText(localizedText);
            }
        }

        private void UpdateSelectedOptionIndex(int index) => selectedOptionIndex = index;

        private void UpdateSelectedText(string text)
        {
            if (dropdown.captionText == null) return;

            dropdown.captionText.text = text;
        }

        private void OnEnable() => LocalizationManager.onLanguageChanged += UpdateDropdown;
        private void OnDisable() => LocalizationManager.onLanguageChanged -= UpdateDropdown;
    }
}