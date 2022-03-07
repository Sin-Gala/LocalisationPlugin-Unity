using UnityEngine;

namespace TheanaProd.Plugins.Localization.SaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        #region SINGLETON
        public static SaveManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);

            SaveFunctions.Init();
        }

        #endregion

        public LanguageManager languageManager { get; private set; } = new LanguageManager();

		///<summary>
		/// Reset all the languages datas
		///</summary>
        public void ResetDatas()
        {
            string language = languageManager.GetBaseLanguage();
            int indexLanguage;

            switch (language)
            {
                case "English":
                default:
                    indexLanguage = 0;
                    break;
                case "French":
                    indexLanguage = 1;
                    break;
            }

            SettingsManager.instance.SetLanguageDropdown(indexLanguage);

            SaveDatas();
        }

		///<summary>
		/// Load all the languages datas
		///</summary>
        public void LoadDatas()
        {
            string saveString = SaveFunctions.Load();

            if (saveString != null)
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

                SettingsManager.instance.SetLanguageDropdown(saveObject.languageIndexDropdown);
            }
            else
                ResetDatas();
        }

		///<summary>
		/// Save all the languages datas
		///</summary>
        public void SaveDatas()
        {
            SaveObject saveObject = new SaveObject();

            saveObject.languageIndexDropdown = SettingsManager.instance.languageOption;

            string json = JsonUtility.ToJson(saveObject);

            SaveFunctions.Save(json);
        }
    }
}