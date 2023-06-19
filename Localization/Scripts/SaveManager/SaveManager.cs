using UnityEngine;

namespace SinGala.Plugins.Localization.SaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        #region SINGLETON
        public static SaveManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);

            SaveFunctions.Init();

            // For demo purposes - You may want to move this elsewhere
            LoadDatas();
        }

        #endregion

		///<summary>
		/// Reset all the languages datas
		///</summary>
        public void ResetDatas()
        {
            LocalizationManager.SetBaseLanguage();
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

                LocalizationManager.SetLanguage(saveObject.SavedLanguage);
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

            saveObject.SavedLanguage = LocalizationManager.Language;

            string json = JsonUtility.ToJson(saveObject);

            SaveFunctions.Save(json);
        }
    }
}