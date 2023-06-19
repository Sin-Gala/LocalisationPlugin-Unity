using UnityEngine;
using UnityEngine.UI;

namespace SinGala.Plugins.Localization
{
    [RequireComponent(typeof(Image))]
    public class ImageLocalizer : Localizer<Sprite>
    {
        private Image imgField;

        private void Awake() => imgField = GetComponentInChildren<Image>();

        public override void UpdateValue()
        {
            if (imgField == null) 
                return;

            imgField.sprite = LocalizationManager.GetLocalizedValue(_translationsDatas);
        }
    }
}