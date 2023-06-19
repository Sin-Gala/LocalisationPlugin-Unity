using System.Collections.Generic;
using UnityEngine;

namespace SinGala.Plugins.Localization
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "TheanaProd/Localization/Sprite Dropdown Translations")]
    public class SpriteDropdownTranslations : ScriptableObject
    {
        [field: SerializeField] public virtual List<Translations<Sprite>> Datas { get; protected set; }
    }
}