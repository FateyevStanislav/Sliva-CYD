using UnityEngine;
using UnityEngine.Localization.Settings;

namespace SlivaCYD3.Settings
{
    public class LanguageSettings : MonoBehaviour
    {
        private const string RU_CODE = "ru";
        private const string EN_CODE = "en";
        
        public void SetLanguage(string localeCode)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales
                .Find(l => l.Identifier.Code == localeCode);
            
            if (locale != null)
                LocalizationSettings.SelectedLocale = locale;
        }
        
        public void SetRussian()
        {
            SetLanguage(RU_CODE);
        }
        
        public void SetEnglish()
        {
            SetLanguage(EN_CODE);
        }
    }
}