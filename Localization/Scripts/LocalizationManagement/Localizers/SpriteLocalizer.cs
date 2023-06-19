using UnityEngine;

namespace SinGala.Plugins.Localization
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteLocalizer : Localizer<Sprite>
    {
        private SpriteRenderer imgField;

        private void Awake() => imgField = GetComponentInChildren<SpriteRenderer>();

        public override void UpdateValue()
        {
            if (imgField == null)
                return;

            imgField.sprite = LocalizationManager.GetLocalizedValue(_translationsDatas);
        }
    }
}