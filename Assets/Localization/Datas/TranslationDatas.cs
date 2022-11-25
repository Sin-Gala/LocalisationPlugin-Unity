using UnityEngine;

namespace LocalizationSystem
{
    [System.Serializable]
    public class TranslationDatas
    {
        public TranslationDatas(Language language)
            => this.language = language;

        [field:SerializeField] public Language language { get; protected set; }
    }

    [System.Serializable]
    public class TextTranslationDatas : TranslationDatas
    {
        public TextTranslationDatas(Language language, string text) : base(language)
            => this.text = text;

        [field: SerializeField] [field:TextArea(2, 100)] public string text { get; private set; }
    }

    [System.Serializable]
    public class ImageTranslationDatas : TranslationDatas
    {
        public ImageTranslationDatas(Language language, Sprite img) : base(language)
            => this.img = img;

        [field: SerializeField] public Sprite img { get; private set; }
    }
}