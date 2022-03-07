using UnityEngine;
using UnityEngine.UI;
using TheanaProd.Plugins.Localization.SaveSystem;
using TheanaProd.Plugins.Localization;

public class SettingsManager : MonoBehaviour
{
    #region SINGLETON
    public static SettingsManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        languageManager = SaveManager.instance.languageManager;

        SaveManager.instance.LoadDatas();
    }
    #endregion

    [Header("Language")]
    [SerializeField] private Dropdown languageDropdown;
    private LanguageManager languageManager;
    public int languageOption;


    /// <summary>
    /// Set the language in the dropdown
    /// </summary>
    public void SetLanguageDropdown(int languageIndex)
    {
        languageOption = languageIndex;
        languageManager.SetLanguage(languageOption);
    }
}