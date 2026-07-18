using TMPro;
using UnityEngine;
using VContainer;

namespace SlivaCYD3.Clicker
{
    public class ClickerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI clicksValueText;
        [SerializeField] private TextMeshProUGUI cpsValueText;
        [SerializeField] private TextMeshProUGUI averageCpsValueText;

        [Inject] private ClickerModel model;
        
        private void OnEnable()
        {
            model.OnDataChanged += OnModelChanged;
            UpdateUI();
        }
        
        private void OnDisable()
        {
            model.OnDataChanged -= OnModelChanged;
        }
        
        private void OnModelChanged(ClickerModel _)
        {
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            clicksValueText.text = model.TotalClicks.ToString();
            cpsValueText.text = model.CurrentCPS.ToString("F1");
            averageCpsValueText.text = model.AverageCPS.ToString("F2");
        }
    }
}