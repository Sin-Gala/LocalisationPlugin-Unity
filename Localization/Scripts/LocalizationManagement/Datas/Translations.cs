using UnityEngine;

namespace SinGala.Plugins.Localization
{
    public abstract class Translations<T> : ScriptableObject
    {
        [field: SerializeField] public virtual TranslationDatas<T>[] Datas { get; protected set; }
    }
}