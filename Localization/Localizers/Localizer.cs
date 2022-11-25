using UnityEngine;

namespace LocalizationSystem
{
    public abstract class Localizer : MonoBehaviour
    {
        public abstract void UpdateText();

        public virtual void SetNewTranslationsDatas(Translations translations)
            => UpdateText();

        private void OnEnable() => LocalizationManager.onLanguageChanged += UpdateText;
        private void OnDisable() => LocalizationManager.onLanguageChanged -= UpdateText;
    }
}