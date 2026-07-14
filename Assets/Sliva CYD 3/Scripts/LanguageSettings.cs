using UnityEngine;
using UnityEngine.Localization.Settings;

namespace SlivaCYD3.Settings
{
    public class LanguageSettings : MonoBehaviour
    {
        public void SetLanguage(string localeCode)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales
                .Find(l => l.Identifier.Code == localeCode);
            
            if (locale != null)
            {
                LocalizationSettings.SelectedLocale = locale;
                
            }
        }
        
        public void SetRussian()
        {
            SetLanguage("ru");
        }
        
        public void SetEnglish()
        {
            SetLanguage("en");
        }
    }
}