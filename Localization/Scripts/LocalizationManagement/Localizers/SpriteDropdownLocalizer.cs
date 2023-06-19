using UnityEngine;
using TMPro;

namespace SinGala.Plugins.Localization
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class SpriteDropdownLocalizer : MonoBehaviour
    {
        private TMP_Dropdown dropdown;

        [SerializeField] private SpriteDropdownTranslations _dropdownTranslations;
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
                Sprite localizedImg = LocalizationManager.GetLocalizedValue(_dropdownTranslations.Datas[i]);

                if (i > dropdown.options.Count -1)
                    dropdown.options.Add(new TMP_Dropdown.OptionData());

                dropdown.options[i].image = localizedImg;

                if (i == dropdown.value)
                    UpdateSelectedImg(localizedImg);
            }
        }

        private void UpdateSelectedOptionIndex(int index) => selectedOptionIndex = index;

        private void UpdateSelectedImg(Sprite img)
        {
            if (dropdown.captionImage == null) return;

            dropdown.captionImage.sprite = img;
        }

        private void OnEnable() => LocalizationManager.OnLanguageChanged += UpdateDropdown;
        private void OnDisable() => LocalizationManager.OnLanguageChanged -= UpdateDropdown;
    }
}