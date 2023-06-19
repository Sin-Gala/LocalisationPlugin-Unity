using UnityEngine;
using System.IO;

namespace SinGala.Plugins.Localization.SaveSystem
{
    public static class SaveFunctions
    {
        public static readonly string SAVE_MAIN = Application.persistentDataPath;

		///<summary>
		/// Initialize the save system
		///</summary>
        public static void Init()
        {
            if (!Directory.Exists(SAVE_MAIN))
                Directory.CreateDirectory(SAVE_MAIN);
        }

		///<summary>
		/// Save the saveString in a json file
		///</summary>
        public static void Save(string saveString)
        {
            File.WriteAllText(SAVE_MAIN + "/languageSaved.txt", saveString);
        }
		
		///<summary>
		/// Load a specific json file
		///</summary>
        public static string Load()
        {
            if (File.Exists(SAVE_MAIN + "/languageSaved.txt"))
            {
                string saveString = File.ReadAllText(SAVE_MAIN + "/languageSaved.txt");
                return saveString;
            }

            return null;
        }
    }
}