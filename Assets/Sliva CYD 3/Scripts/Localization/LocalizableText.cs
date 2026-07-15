using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace SlivaCYD3.Localization
{
    public class LocalizableText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textComponent;
        [SerializeField] private LocalizedString localizedKey;

        private void Awake()
        {
            textComponent ??= GetComponent<TextMeshProUGUI>();
            
            UpdateText();
            
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
        }

        private void OnDestroy()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
        }

        private void OnLocaleChanged(Locale locale)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            textComponent.text = localizedKey.GetLocalizedString();
        }
    }
}