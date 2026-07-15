using UnityEngine;
using UnityEngine.Localization.Settings;

namespace SlivaCYD3.Clicker
{
    public class ClickerController : MonoBehaviour
    {
        private ClickerView view;
        private ClickerModel model;
        
        public void Initialize(ClickerModel model, ClickerView view)
        {
            this.model = model;
            this.view = view;
        }
        
        private void OnEnable()
        {
            model.OnDataChanged += OnModelChanged;
            LocalizationSettings.SelectedLocaleChanged += OnLanguageChanged;
            
            UpdateFullUI();
        }
        
        private void OnDisable()
        {
            model.OnDataChanged -= OnModelChanged;
            LocalizationSettings.SelectedLocaleChanged -= OnLanguageChanged;
        }
        
        private void OnModelChanged(ClickerModel _)
        {
            UpdateDataUI();
        }
        
        private void OnLanguageChanged(UnityEngine.Localization.Locale locale)
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
        
        public void OnClick()
        {
            model.RegisterClick();
        }
    }
}