using UnityEngine;

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
            UpdateDataUI();
        }
        
        private void OnDisable()
        {
            model.OnDataChanged -= OnModelChanged;
        }
        
        private void OnModelChanged(ClickerModel _)
        {
            UpdateDataUI();
        }
        
        private void UpdateDataUI()
        {
            view.SetClicksData(model.TotalClicks, model.CurrentCPS, model.AverageCPS);
        }
        
        public void OnClick()
        {
            model.RegisterClick();
        }
    }
}