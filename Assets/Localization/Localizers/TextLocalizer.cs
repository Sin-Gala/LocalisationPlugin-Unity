using UnityEngine;
using TMPro;

namespace LocalizationSystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextLocalizer : Localizer
    {
        private TextMeshProUGUI txtField;
        [SerializeField] private TranslationsTxt translationTxt;

        private void Awake() => txtField = GetComponentInChildren<TextMeshProUGUI>();

        public override void UpdateText() => txtField.text = LocalizationManager.GetLocalizedValue(translationTxt);

        public override void SetNewTranslationsDatas(Translations translations)
        {
            translationTxt = (TranslationsTxt)translations;
            base.SetNewTranslationsDatas(translations);
        }
    }
}