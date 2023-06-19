using System.Collections.Generic;
using UnityEngine;

namespace SinGala.Plugins.Localization
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "TheanaProd/Localization/Text Dropdown Translations")]
    public class TextDropdownTranslations : ScriptableObject
    {
        [field: SerializeField] public virtual List<Translations<string>> Datas { get; protected set; }
    }
}