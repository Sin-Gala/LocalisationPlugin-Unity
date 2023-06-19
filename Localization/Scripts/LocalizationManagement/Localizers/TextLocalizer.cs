using UnityEngine;
using TMPro;

namespace SinGala.Plugins.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextLocalizer : Localizer<string>
    {
        private TextMeshProUGUI txtField;

        private void Awake()
        {
            txtField = GetComponent<TextMeshProUGUI>();
            UpdateValue();
        }

        public override void UpdateValue()
        {
            if (txtField == null)
                return;

            TranslationDatas<string> datas = LocalizationManager.GetLocalizedDatas<string>(_translationsDatas);

            txtField.text = datas.LocalizedDatas;
            txtField.isRightToLeftText = datas.IsRTL;
        }
    }
}