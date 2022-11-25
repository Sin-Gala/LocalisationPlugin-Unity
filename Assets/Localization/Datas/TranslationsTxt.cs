using UnityEngine;

namespace LocalizationSystem
{
    [CreateAssetMenu(menuName = "Localization/Text Translation")]
    public class TranslationsTxt : Translations
    {
        [field: SerializeField] public TextTranslationDatas[] datas { get; private set; }
    }

}