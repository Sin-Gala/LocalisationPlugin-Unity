using UnityEngine;
using UnityEngine.UI;

namespace LocalizationSystem
{
    [RequireComponent(typeof(Image))]
    public class ImageLocalizer : Localizer
    {
        private Image imgField;
        [SerializeField] private TranslationsImg translationImg;

        private void Awake() => imgField = GetComponentInChildren<Image>();

        public override void UpdateText() => imgField.sprite = LocalizationManager.GetLocalizedValue(translationImg);

        public override void SetNewTranslationsDatas(Translations translations)
        {
            translationImg = (TranslationsImg)translations;
            base.SetNewTranslationsDatas(translations);
        }
    }
}