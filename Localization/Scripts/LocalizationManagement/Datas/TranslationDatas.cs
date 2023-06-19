using UnityEngine;

namespace SinGala.Plugins.Localization
{
    [System.Serializable]
    public class TranslationDatas<T>
    {
        public TranslationDatas(Language language, T localizedDatas)
        {
            Language = language;
            LocalizedDatas = localizedDatas;
        }

        [field:SerializeField] public Language Language { get; private set; }
        [field: SerializeField] public T LocalizedDatas { get; private set; }

        [Tooltip("Only used for text datas - Set whether the text is right-to-left writing or left-to-right")]
        [field: SerializeField] public bool IsRTL { get; private set; } = false;
    }
}