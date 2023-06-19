using UnityEngine;

namespace SinGala.Plugins.Localization
{
    public class LanguageUpdater : MonoBehaviour
    {
        [SerializeField] private Language _language;

        /// <summary>
        /// Updates the current language depending on the variable value set in the inspector
        /// </summary>
        public void UpdateLanguage()
        {
            LocalizationManager.SetLanguage(_language);
        }
    }
}