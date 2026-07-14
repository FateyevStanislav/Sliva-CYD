using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace SlivaCYD3.Clicker
{
    public class ClickerController : MonoBehaviour
    {
        [SerializeField] private ClickerView view;
    
        private ClickerModel model;
    
        private void Awake()
        {
            if (view == null)
                return;
        
            model = new ClickerModel();
            model.OnDataChanged += OnModelChanged;
            LocalizationSettings.SelectedLocaleChanged += OnLanguageChanged;
            UpdateFullUI();
        }
    
        private void OnModelChanged(ClickerModel _)
        {
            UpdateDataUI();
        }
    
        private void OnLanguageChanged(Locale locale)
        {
            UpdateFullUI();
        }
    
        private void UpdateDataUI()
        {
            view.SetClicksData(model.TotalClicks, model.CurrentCPS, model.AverageCPS);
        }
    
        private void UpdateFullUI()
        {
            UpdateDataUI();
            view.SetLanguageLabel();
        }
    
        private void OnDestroy()
        {
            if (model != null)
                model.OnDataChanged -= OnModelChanged;
        
            LocalizationSettings.SelectedLocaleChanged -= OnLanguageChanged;
        }
    
        public void OnClick()
        {
            model?.RegisterClick();
        }
    }
}