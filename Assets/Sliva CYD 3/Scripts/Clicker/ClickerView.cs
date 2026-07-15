using TMPro;
using UnityEngine;

namespace SlivaCYD3.Clicker
{
    public class ClickerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI clicksValueText;
        [SerializeField] private TextMeshProUGUI cpsValueText;
        [SerializeField] private TextMeshProUGUI averageCpsValueText;

        public void SetClicksData(int totalClicks, float currentCPS, float averageCPS)
        {
            clicksValueText.text = totalClicks.ToString();
            cpsValueText.text = currentCPS.ToString("F1");
            averageCpsValueText.text = averageCPS.ToString("F2");
        }
    }
}