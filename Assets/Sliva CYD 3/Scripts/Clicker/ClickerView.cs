using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class ClickerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clicksCountText;
    [SerializeField] private TextMeshProUGUI cpsText;
    [SerializeField] private TextMeshProUGUI averageCpsText;
    [SerializeField] private TextMeshProUGUI languageSettingsText;
    
    [SerializeField] private LocalizedString clicksCountKey;
    [SerializeField] private LocalizedString cpsKey;
    [SerializeField] private LocalizedString averageCpsKey;
    [SerializeField] private LocalizedString languageSettingsKey;

    public void SetClicksData(int totalClicks, float currentCPS, float averageCPS)
    {
        clicksCountText.text = $"{clicksCountKey.GetLocalizedString()}: {totalClicks}";
        cpsText.text = $"{cpsKey.GetLocalizedString()}: {currentCPS:F1}";
        averageCpsText.text = $"{averageCpsKey.GetLocalizedString()}: {averageCPS:F2}";
    }
    
    public void SetLanguageLabel()
    {
        languageSettingsText.text = languageSettingsKey.GetLocalizedString();
    }
}