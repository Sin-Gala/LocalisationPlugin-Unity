using UnityEngine;

namespace LocalizationSystem
{
    [CreateAssetMenu(menuName = "Localization/Image Translation")]
    public class TranslationsImg : Translations
    {
        [field: SerializeField] public ImageTranslationDatas[] datas { get; private set; }
    }
}