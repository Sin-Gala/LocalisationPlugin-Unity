using UnityEngine;

namespace LocalizationSystem
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteLocalizer : Localizer
    {
        private SpriteRenderer imgField;
        [SerializeField] private TranslationsImg translationImg;

        private void Awake() => imgField = GetComponentInChildren<SpriteRenderer>();

        public override void UpdateText() => imgField.sprite = LocalizationManager.GetLocalizedValue(translationImg);

        public override void SetNewTranslationsDatas(Translations translations)
        {
            translationImg = (TranslationsImg)translations;
            base.SetNewTranslationsDatas(translations);
        }
    }
}