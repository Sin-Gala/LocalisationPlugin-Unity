# LocalisationPlugin-Unity

## INSTALLING IN PROJECT:
- Place the Localization folder in your project's assets

- Update your localization.csv file (found in Resources folder) with the languages and texts you want
	- In the LocalizationSystem file add the languages you want to support in the Languages enum
		- Add a new dictionary for each language and initialize them in the Init() function
			- Add the new languages in the GetLocalizedValues() function

- Add an empty gameObject with "SaveManager", "SettingsManager" and "LocalizationEvents" components
	- In your project settings, go to the Script Execution Order tab and add the scripts in this order before the default time:
		* SaveManager
		* LocalizationEvents
		* SettingsManager

- Add the "TextLocalizer" component on each one of the Text components you wish to localize
	- Add the key as you wrote it on the localization.csv file (if you have issues with special characters, make sure the file is in UTF-8)
	
- Add the "LocalizeDropdown" component on each one of the Dropdown components you wish to localize
	- Add the dropdown string index of your choice in the Awake() switch of the "LocalizeDropdown" component script
		- Set the variable "Index Dropdown" in the inspector as the dropdown string index you chose for this dropdown
	- Add the keys as you wrote them on the localization.csv file
		- Add as much options in the dropdown as they are keys
	- Add the component in the "SettingsManager" inspector window (variable "Language Dropdown")
	- On the dropdown used to change the language go to "OnValueChanged" and add the "SettingsManager" dynamic function SetLanguageDropdown()
	
	
	
## CALL FROM SCRIPT:
- To call the localization scripts you need to use the namespace TheanaProd.Plugins.Localization. 
- For the saving scripts it's TheanaProd.Plugins.Localization.SaveSystem



## FUNCTIONS:
- LanguageManager:
	* GetBaseLanguage(): Return the system language of the device used by the user
	* SetLanguage(int indexDropdownNew): Set the language chosen and updates all texts by calling the LanguageChanged event
	
- LocalizationEvents
	* LanguageChanged(): Call the onLanguageChanged event
	* onLanguageChanged

- LocalizationSystem
	* GetLocalizedValues(string key): Get the localized value of the key
	
- SaveFunctions
	* Init(): Initialize the save system
	* Save(string saveString): Save the saveString in a json file
	* Load: Load a specific json file
	
- SaveManager
	* SaveDatas(): Save all the languages datas
	* LoadDatas(): Load all the languages datas
	* ResetDatas(): Reset all the languages datas

- SettingsManager
		* SetLanguageDropdown(int languageIndex): Set the language in the dropdown
	
	
	
## CREDITS:
This localization plugin was created based on scripts from:
- https://www.youtube.com/watch?v=c-dzg4M20wY&t=129s
- https://forum.unity.com/threads/localizing-ui-dropdown-options.896951/



## VERSIONS:
v1.0 : Current version
	- Simple localization system from a csv file
	- Simple saving and settings systems to easily switch the language at run-time
