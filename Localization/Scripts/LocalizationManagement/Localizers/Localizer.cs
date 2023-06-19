using UnityEngine;

namespace SinGala.Plugins.Localization
{
    public abstract class Localizer<T> : MonoBehaviour
    {
        [SerializeField] protected Translations<T> _translationsDatas;

        /// <summary>
        /// Update the value of the needed component (Image, Sprite, TextMeshProUGUI, etc.)
        /// with the correct localized data
        /// </summary>
        public abstract void UpdateValue();

        /// <summary>
        /// Update the possible translations datas values of this specific localizer
        /// </summary>
        public void SetNewTranslationsDatas(Translations<T> translations)
        {
            _translationsDatas = translations;
            UpdateValue();
        }

        private void OnEnable()
        {
            LocalizationManager.OnLanguageChanged += UpdateValue;
            UpdateValue();
        }

        private void OnDisable() => LocalizationManager.OnLanguageChanged -= UpdateValue;
    }
}