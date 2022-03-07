using UnityEngine;
using System;

namespace TheanaProd.Plugins.Localization
{
    public class LocalizationEvents : MonoBehaviour
    {
        #region SINGLETON
        public static LocalizationEvents instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        public event Action onLanguageChanged;

        /// <summary>
        /// Call the onLanguageChanged event
        /// </summary>
        public void LanguageChanged()
        {
            if (onLanguageChanged != null)
                onLanguageChanged();
        }
    }

}