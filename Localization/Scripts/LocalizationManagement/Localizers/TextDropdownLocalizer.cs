using UnityEngine;
using TMPro;

namespace SinGala.Plugins.Localization
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class TextDropdownLocalizer : MonoBehaviour
    {
        private TMP_Dropdown dropdown;

        [SerializeField] private TextDropdownTranslations _dropdownTranslations;
        private int selectedOptionIndex = 0;

        private void Awake()
        {
            dropdown = GetComponent<TMP_Dropdown>();
            dropdown.value = selectedOptionIndex;

            dropdown.onValueChanged.AddListener(UpdateSelectedOptionIndex);
            UpdateDropdown();
        }

        private void UpdateDropdown()
        {
            for (int i = 0; i < _dropdownTranslations.Datas.Count; i++)
            {
                string localizedText = LocalizationManager.GetLocalizedValue(_dropdownTranslations.Datas[i]);

                if (i > dropdown.options.Count -1)
                    dropdown.options.Add(new TMP_Dropdown.OptionData());

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

        private void OnEnable() => LocalizationManager.OnLanguageChanged += UpdateDropdown;
        private void OnDisable() => LocalizationManager.OnLanguageChanged -= UpdateDropdown;
    }
}